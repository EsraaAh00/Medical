using SharedModels.Models;
using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorBusinessFacilityValidate
    {
        public static BaseResponse Validate(this VendorBusinessFacilityFullDataModel model)
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
                if (model.FacilityId == null || model.FacilityId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "facilityId",
                        Value = "Facility Name  is Requird"
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
