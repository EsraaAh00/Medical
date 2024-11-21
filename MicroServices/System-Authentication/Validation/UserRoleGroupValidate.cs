using SharedModels.Helpers;
using SharedModels.Models;
using System_Authentication.Models.UserActionRole;
using System_Authentication.Models.UserRoleGroup;

namespace System_Authentication.Validation
{
    public static class UserRoleGroupValidate
    {
        public static BaseResponse Validate(this UserRoleGroupFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
               
                if (model.RoleGroupId == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "roleGroupId",
                        Value = DicHelper.GetMessage("Role Group Id is Requird"),

                    });
                }
                if (model.UserId == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "userId",
                        Value = DicHelper.GetMessage("User Id is Requird"),

                    });
                }


                if (Response.Errors.Count > 0)
                {
                    Response.IsError = true;
                }


                return Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "An error occurred while processing the request." };


            }
        }
    }
}
