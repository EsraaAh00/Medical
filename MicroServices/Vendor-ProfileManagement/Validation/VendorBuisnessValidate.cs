using SharedModels.Helpers;
using SharedModels.Models;
using Vendor_ProfileManagement.Models.VendorBusiness;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorBusinessValidate
    {
        public static  BaseResponse Validate(this VendorBusinessFullDataModel model)
        {
            BaseResponse Response = new BaseResponse();
            try
            {
                if (model.VendorId == null || model.VendorId == 0)
                {
                   
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "vendorName",
                        Value = "Vendor Name is Requird"
                    });


                }
                if (string.IsNullOrEmpty(model.Name))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "name",
                        Value = "Name is Requird"
                    });
                }
                if (string.IsNullOrEmpty(model.BusinessStatus))
                {
                    
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "businessStatus",
                        Value = "Business Status is Requird"
                    });
                }
                if (string.IsNullOrEmpty(model.BusinessTypeCategoryName))
                {
                    
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "businessStatus",
                        Value = "Business Status is Requird"
                    });
                }
                if (string.IsNullOrEmpty(model.LandLine)|| !int.TryParse(model.LandLine, out _))
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "landLine",
                        Value = "LandLine  is Requird and Should Be Number"
                    });
                }
           
                if (model.LoactionLatitude == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "loactionLatitude",
                        Value = "LoactionLatitude  is Requird"
                    });

                }
                if (model.LoactionLongitude == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "loactionLongitude",
                        Value = "LoactionLongitude  is Requird"
                    });
                }
                if (model.BusinessStatusCode == null)
                {
                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "businessStatusCode",
                        Value = "Business Status Code  is Requird"
                    });
                 }
                if (Response.Errors.Count > 0) {
                 Response.IsError = true;
                }

                
                return  Response;
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsError = true, Message = "StatusCode : 500 , An error occurred while processing the request." };


            }

        }

    }
}
