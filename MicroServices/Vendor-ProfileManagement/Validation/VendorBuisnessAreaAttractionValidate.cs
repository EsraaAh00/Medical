using SharedModels.Models;
using Vendor_ProfileManagement.Models.Option;
using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorBusinessAreaAttractionValidate
    {
        public static BaseResponse Validate(this VendorBusinessAreaAttractionFullDataModel model)
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
                if (string.IsNullOrEmpty(model.Description))
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "description",
                        Value = "Description  is Requird"
                    });


                }
                if (string.IsNullOrEmpty(model.DistanceUnit))
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "distanceUnit",
                        Value = "Distance Unit  is Requird"
                    });
                }
                if (model.VendorBusinessId == null || model.VendorBusinessId == 0)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "vendorBusinessId",
                        Value = "Vendor Business Name   is Requird"
                    });
                }
                if (model.DistanceUnitCode == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "distanceUnitCode",
                        Value = "Distance Unit Code is Requird"
                    });
                }
                if (model.ImageFile == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "imageFile",
                        Value = "Image File is Requird"
                    });
                }
                if (model.DistanceUnitCode == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "distanceUnitCode",
                        Value = "Distance Unit Code is Requird"
                    });
                }
                if (model.DistanceValue == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "distanceValue",
                        Value = "Distance Value is Requird"
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
