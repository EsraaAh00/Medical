using SharedModels.Models;
using Vendor_ProfileManagement.Models.BusinessTypeCategory;
using Vendor_ProfileManagement.Models.BusinessTypeFeature;

namespace Vendor_ProfileManagement.Validation
{
    public  static class BusinessTypeFeatureValidate
    {
        public static BaseResponse Validate(this BusinessTypeFeatureFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (!model.FeatureId.HasValue)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "featureId",
                        Value = "Feature  is Requird"
                    });


                }
                if (!model.BusinessTypeId.HasValue)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "businessTypeId",
                        Value = "BusinessTypeis Requird"
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
