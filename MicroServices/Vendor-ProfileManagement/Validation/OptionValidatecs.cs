using SharedModels.Models;
using Vendor_ProfileManagement.Models.Feature;
using Vendor_ProfileManagement.Models.Option;

namespace Vendor_ProfileManagement.Validation
{
    public static class OptionValidatecs
    {
        public static BaseResponse Validate(this OptionFullDataModel model)
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
                if (model.FeatureId == null|| model.FeatureId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "featureId",
                        Value = "Feature Name is Requird"
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
