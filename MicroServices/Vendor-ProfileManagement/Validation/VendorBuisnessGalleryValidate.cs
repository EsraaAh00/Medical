using SharedModels.Models;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;
using Vendor_ProfileManagement.Models.VendorBusinessGallery;

namespace Vendor_ProfileManagement.Validation
{
    public static class VendorBusinessGalleryValidate
    {
        public static BaseResponse Validate(this VendorBusinessGalleryFullDataModel model)
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
                if (model.GalleryImageFile == null)
                {

                    Response.Errors.Add(new ReposneError()
                    {
                        Key = "galleryImageFile",
                        Value = "Gallery Image File   is Requird"
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
