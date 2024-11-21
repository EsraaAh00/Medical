using SharedModels.Helpers;
using SharedModels.Models;
using System_Authentication.Models.ActionRole;
using System_Authentication.Models.RoleGroup;

namespace System_Authentication.Validation
{
    public static class RoleGroupValidate
    {
        public static BaseResponse Validate(this RoleGroupFullDataModel model)
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

           

                if (string.IsNullOrEmpty(model.NormalizedName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "normalizedName",
                        Value = DicHelper.GetMessage("Normalized Name  is Requird"),
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
