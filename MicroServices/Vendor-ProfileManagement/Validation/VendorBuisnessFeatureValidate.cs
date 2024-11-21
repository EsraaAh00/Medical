using SharedModels.Models;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorBusinessFeatureValidate
    {
        public static BaseResponse Validate(this VendorBusinessFeatureFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.VendorBusinessId == null || model.VendorBusinessId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "vendorBusinessId",
                        Value = "Vendor Business Name   is Requird"
                    });
                }
                if (model.FeatureId == null || model.FeatureId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "featureId",
                        Value = "Feature Name  is Requird"
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
