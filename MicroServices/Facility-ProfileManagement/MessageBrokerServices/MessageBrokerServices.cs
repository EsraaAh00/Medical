using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
using Facility_FacilityProfileManagement.RefrenceModels;
using SharedModels.Helpers;
using SharedModels.Models;

namespace Facility_FacilityProfileManagement.MessageBrokerServices
{
    public static class MessageBrokerService
    {

        public static async Task<BaseResponse?> RegisterUser(FacilityRequestFullDataModel model)
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

                var newVendor = new FacilityFullDataModel
                {
                    UserId = (int?)userId,
                    Name = model.Name,
                    NameLocalized = model.NameLocalized,
                    Logo = model.Logo,
                    Email = model.Email,
                    Phone = model.Phone,
                    Password = model.Password,
                    About = model.About,
                    AboutLocalized = model.AboutLocalized,
                    LandLine = model.LandLine,
                    Address = model.Address,
                    AddressLocalized = model.AddressLocalized,
                    FacilityType = model.FacilityType,
                    CommercialRecordNumber = model.CommercialRecordNumber,
                    CommercialRecordAttachment = model.CommercialRecordAttachment,
                    MinistryOfHealthlicenseNumber = model.MinistryOfHealthlicenseNumber,
                    MinistryOfHealthlicenseAttachment = model.MinistryOfHealthlicenseAttachment,
                    Country = model.Country,
                    CoveredArea = model.CoveredArea,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    StateCode = 1,
                    State = "Pending Completion"
                };

                var newVendorResponse = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/Facility/Facility/Save", newVendor);
                if (newVendorResponse?.IsError == false)
                {
                    return new BaseResponse { IsError = false, Message = "Facility Regesitration Succesful" };
                }
                else
                {
                    return new BaseResponse { IsError = true, Message = "Facility Regesitration Failed" };
                }
            }
            else
            {
                return new BaseResponse { IsError = true, Message = "User Regesitration Failed" };
            }
        }

    }
}