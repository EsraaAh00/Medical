using SharedModels.Models;
using Vendor_ProfileManagement.Models.Facility;
using Vendor_ProfileManagement.Models.Feature;

namespace Vendor_ProfileManagement.Validation
{
    public static class FeatureValidate
    {
        public static BaseResponse Validate(this FeatureFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "name",
                        Value = "Name is Requird"
                    });


                }
                if (model.IconFile == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "icon",
                        Value = "Icon is Requird"
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
                return new BaseResponse { IsError = true, Message = "StatusCode : 500 , An error occurred while processing the request." };


            }

        }

    }
}
