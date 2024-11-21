using SharedModels.Helpers;
using SharedModels.Models;
using System_Authentication.Models.ActionRole;
using System_Authentication.Models.Rank;

namespace System_Authentication.Validation
{
    public static class ActionRoleValidate
    {
        public static BaseResponse Validate(this ActionRoleFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "name",
                        Value = DicHelper.GetMessage("Name is Requird"),

                    });
                }
                if (string.IsNullOrEmpty(model.NameLocalized))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "nameLocalized",
                        Value = DicHelper.GetMessage("Name Localized is Requird"),

                    });
                }

                if (model.RoleGroupId == null || model.RoleGroupId == 0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "roleGroupId",
                        Value = DicHelper.GetMessage("Role Group Id is Requird"),

                    });
                }
                
                if (string.IsNullOrEmpty(model.BaseName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "baseName",
                        Value = DicHelper.GetMessage("BaseName  is Requird"),
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
