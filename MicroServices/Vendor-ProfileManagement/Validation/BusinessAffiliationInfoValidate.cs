using Microsoft.IdentityModel.Tokens;
using SharedModels.Models;
using Vendor_ProfileManagement.Models.BusinessAffiliationInfo;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;

namespace Vendor_ProfileManagement.Validation
{
    public static class BusinessAffiliationInfoValidate
    {
        public static BaseResponse Validate(this BusinessAffiliationInfoFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.VendorBusinessId==null|| model.VendorBusinessId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "vendorBusinessId",
                        Value = "VendorBusiness is Requird"
                    });


                }
                if (model.AwardPhotoFile!=null&&!model.AwardPhoto.IsNullOrEmpty())
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "awardPhotoFile",
                        Value = "AwardPhotoFile  is Requird"
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
