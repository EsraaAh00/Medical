namespace Operation_OperationsManagement.MessageBrokerServices.Models
{
    public class Wallet
    {
        public int? PartyId { get; set; }
        public int? RegistredBankId { get; set; }
        public string? RegistredBankName { get; set; }
        public int? RegistredServiceId { get; set; }
        public string? RegistredServiceName { get; set; }
        public string? Number { get; set; }
    }
}
