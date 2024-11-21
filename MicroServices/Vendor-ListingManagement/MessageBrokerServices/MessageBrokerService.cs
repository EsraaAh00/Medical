using SharedModels.Helpers;
using SharedModels.Models;
using Vendor_ListingManagement.Entities;
using Vendor_ListingManagement.RefModels;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Vendor_ListingManagement.MessageBrokerServices
{
    public static class MessageBrokerService
    {

        public static async Task<int?> GetBuissnesCatId(int? id)
        {
            VendorBuissnesModel? model = await BaseHttpContext.GetObject<VendorBuissnesModel>($"Vendor/VendorBusiness/GetById?id={id}");
            if(model != null)
            {
                int? bcid = model?.BusinessTypeCategoryId;
                return bcid;
            }
            return 0;
        }



         public static async Task<BaseResponse?> AddListingItem(dynamic? obj, int? bcid)
         {          
            switch (bcid)
              {
                case 1:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/Item/Save", obj);
                case 2:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Hotel/Item/Save", obj);
                case 3:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Rental/Item/Save", obj);
                case 4:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Activity/Item/Save", obj);
                default:
                    return new BaseResponse { IsError = true };
            }           
         }





        public static async Task<BaseResponse?> AddListingIemDetail(dynamic? obj, int? code)
        {
            switch (code)
            {
                case 111:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemSpecification/Save", obj);
                case 121:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemConfigration/Save", obj);
                case 122:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemItinerary/Save", obj);
                case 123:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemPickupAndDeparture/Save", obj);
                case 13:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemPoint/Save", obj);
                case 14:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Agency/ItemAccessabilityPoint/Save", obj);
                case 21:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Hotel/ItemConfigration/Save", obj);
                case 22:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Hotel/ItemFeatureOption/Save", obj);
                case 23:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Hotel/ItemAccessabilityPoint/Save", obj);
                case 31:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Rental/ItemHighlights/Save", obj);
                case 32:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Rental/ItemConfigration/Save", obj);
                case 33:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Rental/ItemFeatureOption/Save", obj);
                case 34:
                    return await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/gateway/Listing/Rental/ItemAccessabilityPoint/Save", obj);
                default:
                    return new BaseResponse { IsError = true };
            }
        }

    }
}
