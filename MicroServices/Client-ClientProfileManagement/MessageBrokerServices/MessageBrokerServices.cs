using SharedModels.Helpers;
using SharedModels.Models;

namespace Client_ClientProfileManagement.MessageBrokerServices
{
    public class MessageBrokerServices
    {
        public static async Task<BaseResponse?> GetGuestToken(int requestid)
        {
            var token = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/System/authentication/GenerateGuestToken", requestid);
            if (token?.IsError == false)
            {
                return new BaseResponse { IsError = false, ReturnedValue = token };
            }
            return new BaseResponse { IsError = true };
        }
    }
}