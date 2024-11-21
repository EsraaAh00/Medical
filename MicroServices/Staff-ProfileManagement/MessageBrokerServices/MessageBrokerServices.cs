using SharedModels.Helpers;
using SharedModels.Models;
using Staff_StaffProfileManagement.Models.Staff;
using Staff_StaffProfileManagement.Models.StaffRequest;
using Staff_StaffProfileManagement.RefrenceModels;


namespace Staff_StaffProfileManagement.MessageBrokerServices
{
    public static class MessageBrokerService
    {
        public static async Task<BaseResponse?> RegisterUser(StaffRequestFullDataModel model)
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

                var newVendor = new StaffFullDataModel
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
                    Gender = model.Gender,
                    Nationality = model.Nationality,
                    NationalId = model.NationalId,
                    MedicallicenseNumber = model.MedicallicenseNumber,
                    MedicallicenseAttachment = model.MedicallicenseAttachment,
                    MedicallicenseExpiryDate = model.MedicallicenseExpiryDate,
                    Speciality = model.Speciality,
                    Classification = model.Classification,
                    SubSpeciality = model.SubSpeciality,
                    Degree = model.Degree,
                    OfflineSessionFair = model.OfflineSessionFair,
                    OnlineSessionFair = model.OnlineSessionFair,
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