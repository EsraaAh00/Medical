using SharedModels.Helpers;
using SharedModels.Models;
using System.Net.Http;
using Vendor_ProfileManagement.Enums;
using Vendor_ProfileManagement.Models.Vendor;
using Vendor_ProfileManagement.Models.VendorBusiness;
using Vendor_ProfileManagement.Models.VendorRequest;
using Vendor_ProfileManagement.RefrenceModels.VendorRequest;

namespace Vendor_ProfileManagement.MessageBrokerServices
{
    public static class  MessageBrokerService
    {

       public static async Task<BaseResponse?> GetGuestToken (int requestid)
       {
            var token = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/System/authentication/GenerateGuestToken", requestid);
            if(token?.IsError == false)
            {
                return new BaseResponse { IsError =  false , ReturnedValue = token };
            }
            return new BaseResponse { IsError = true };
        }


        public static async Task<BaseResponse?> RegisterVendor(VendorRequestFullDataModel model)
        {

            var authUser = new UserFullDataModel
            {
                Name = model.Name?.ToLower(),
                Email = model.Email?.ToLower(),
                PhoneNumber = model.Phone,
                UserName = model.Name?.Trim().ToLower(),
                Password = model.Password
            };

            var authUserResponse = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/System/User/Save", authUser);

            if (authUserResponse?.IsError == false)
            {
                var userId = authUserResponse.ReturnedValue;

                var newVendor = new VendorFullDataModel
                {
                    UserId = (int?)userId,
                    Name = model.Name,
                    Logo = model.Logo,
                    Cover = model.Cover,
                    NameLocalized = model.NameLocalized,
                    Email = model.Email,
                    Phone = model.Phone,
                    ManagerFirstName = model.ManagerFirstName,
                    ManagerFirstNameLocalized = model.ManagerFirstNameLocalized,
                    ManagerLastName = model.ManagerLastName,
                    ManagerLastNameLocalized = model.ManagerLastNameLocalized
                };

                try
                {
                    var newVendorResponse = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/Vendor/Vendor/Save", newVendor);
                    if (newVendorResponse?.IsError == false)
                    {
                        var vendorId = newVendorResponse.ReturnedValue;

                        var newVendorBusiness = new VendorBusinessFullDataModel
                        {
                            VendorId = (int?)vendorId,
                            Logo = model.BusinessLogo,
                            Cover = model.BusinessCover,
                            BusinessTypeCategoryId = model.BusinessTypeCategoryId,
                            LandLine = model.BusinessLandLine,
                            LoactionLatitude = model.Lat,
                            LoactionLongitude = model.Lng,
                            BusinessStatusCode = 1
                        };

                        try
                        {
                            var newVendorBusinessResponse = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/Vendor/VendorBusiness/Save", newVendorBusiness);
                            if (newVendorBusinessResponse?.IsError == true)
                            {
                                return new BaseResponse { IsError = true, Message = "Failed to save vendor business." };
                            }
                        }
                        catch (Exception ex)
                        {
                            return new BaseResponse { IsError = true, Message = $"Exception during saving vendor business: {ex.Message}" };
                        }
                    }
                    else
                    {
                        return new BaseResponse { IsError = true, Message = "Failed to save new vendor." };
                    }
                }
                catch (Exception ex)
                {
                    return new BaseResponse { IsError = true, Message = $"Exception during saving new vendor: {ex.Message}" };
                }
            }
            else
            {
                return new BaseResponse { IsError = true, Message = "Failed to save auth user." };
            }

            return new BaseResponse { IsError = false };

        }
        
        public static async Task<BaseResponse?> CreateUserForVendorRequest(  ) {
            return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("system/user/save", new { });

        }
        public static async Task<BaseResponse?> AuthenticateGuest(string ? Language, string ?DeviceToken ) {
            return await BaseHttpContext.GetReturnBaseResponse(action: $"system/Authentication/AuthenticateGuest?Language={Language}&&DeviceToken={DeviceToken}");

        }
        public static async Task<BaseResponse?> CheckForRepetitationEmailAndPhone(string ? Email, string ?Phone ) {
            return await BaseHttpContext.GetReturnBaseResponse(action: $"system/User/CheckForRepetitationEmailAndPhone?Email={Email}&&Phone={Phone}");

        }
    }
}