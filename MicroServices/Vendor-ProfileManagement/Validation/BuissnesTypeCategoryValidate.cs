using SharedModels.Models;
using Vendor_ProfileManagement.Models.BusinessTypeCategory;
using Vendor_ProfileManagement.Models.VendorBusiness;

namespace Vendor_ProfileManagement.Validation
{
    public static class BusinessTypeCategoryValidate
    {
        public static BaseResponse Validate(this BusinessTypeCategoryFullDataModel model)
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
                if (model.BusinessTypeId == null || model.BusinessTypeId == 0)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "businessTypeId",
                        Value = "Business Type  is Requird"
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
