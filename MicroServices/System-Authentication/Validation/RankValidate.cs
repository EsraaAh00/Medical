using SharedModels.Helpers;
using SharedModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System_Authentication.Models.Rank;

namespace System_Authentication.Validation
{
    public static class RankValidate
    {
        public static BaseResponse Validate(this RankFullDataModel model)
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
              
                if (model.Value == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "value",
                        Value = DicHelper.GetMessage("Value is Requird"),

                    });
                }
                if (model.SignupRank == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "signupRank",
                        Value = DicHelper.GetMessage("Signup Rank is Requird"),

                    });
                }
           



             
             
                if (string.IsNullOrEmpty(model.BaseName))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "BaseName",
                        Value = DicHelper.GetMessage("BaseName  is Requird"),
                    });
                }
               
                if (string.IsNullOrEmpty(model.LandScreen))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "landScreen",
                        Value = DicHelper.GetMessage("LandScreen is Requird"),

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
