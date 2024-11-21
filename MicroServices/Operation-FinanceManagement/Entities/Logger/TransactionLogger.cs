using SharedModels.Models;

namespace Operation_FinanceManagement.Entities.Logger
{
    public class TransactionLogger : LogModel
    {
        public TransactionLogger() { }
        public TransactionLogger(LogModel baseClass) : base(baseClass)
        {
        }
    }
}
