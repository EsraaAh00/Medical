using SharedModels.Entities;

namespace Operation_FinanceManagement.Models.Transaction
{
    public class TransactionFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public int? ProviderId { get; set; }
        public int? TransactionId { get; set; }
        public int? TicketId { get; set; }
        public int? CaseId { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public int? TypeCode { get; set; }
        public string? Type { get; set; }
    }
}
