using SharedModels.Helpers;
using Operation_OperationsManagement.MessageBrokerServices.Models;
namespace Operation_OperationsManagement.MessageBrokerServices
{
    public class MessageBrokerServices
    {
        public static async Task<Wallet?> GetWalletdata(int? Clientid)
        {

             Wallet? Wallet = await BaseHttpContext.GetObject<Wallet?>($"Operation/Finance/GetByProperty?propertyName={"ClientId"}&&value={Clientid}");

            if (Wallet != null)
            {
                 return Wallet;
            }

            return null;
        }


        //public static async Task<Wallet?> OrderPayment(int? Clientid , decimal NetTotal)
        //{

        //    Transaction? transaction = new Transaction
        //    {
        //        client
        //    }

        //    var authUserResponse = await BaseHttpContext.PostObjectReturnBaseResponse<dynamic>("/System/User/Save", authUser);

        //     = await BaseHttpContext.GetObject<Wallet?>($"Operation/Finance/GetByProperty?propertyName={"ClientId"}&&value={id}");

        //    if (Wallet != null)
        //    {
        //        return Wallet;
        //    }

        //    return null;
        //}


    }
}