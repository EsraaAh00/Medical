using SharedModels.Helpers;
using SharedModels.Models;
using System_Authentication.Models.ActionRole;
using System_Authentication.Models.UserActionRole;

namespace System_Authentication.Validation
{
    public static class UserActionRoleValidate
    {
        public static BaseResponse Validate(this UserActionRoleFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(model.ActionRoleName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "actionRoleName",
                        Value = DicHelper.GetMessage("Action Role Name is Requird"),

                    });
                }

                if (model.ActionRoleId == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "actionRoleId",
                        Value = DicHelper.GetMessage("Action Role Id is Requird"),

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
