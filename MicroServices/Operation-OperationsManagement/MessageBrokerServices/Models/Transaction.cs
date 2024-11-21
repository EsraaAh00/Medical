namespace Operation_OperationsManagement.MessageBrokerServices.Models
{
    public class Transaction
    {
        public int? ClientWalletId { get; set; }
        public int? VendorWalletId { get; set; }
        public int? ServiceProviderWalletId { get; set; }
        public string? AccountNumber { get; set; }
        public int? OrderId { get; set; }
        public int? TicketId { get; set; }
        public int? CaseId { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public int? TypeCode { get; set; }
        public string? Type { get; set; }
    }
}
