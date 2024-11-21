using SharedModels.Helpers;
using SharedModels.Models;

namespace System_Authentication.MessageBrokerServices
{
    public class MessageBrokerService
    {

        public static async Task<BaseResponse?> GetRequestStatus(int? RequestId)
        {
            return await BaseHttpContext.GetReturnBaseResponse(action: $"Vendor/VendorRequest/GetById?Id={RequestId}");
        }

    }
}
