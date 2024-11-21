using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Operation_OperationsManagement.Models.Ticket
{
    public class TicketFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientNameLocalized { get; set; }
        public int? ServiceProviderId { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? ServiceProviderNameLocalized { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceNameLocalized { get; set; }
        public string? MeetingEnviroment { get; set; }
        public double? ProviderFair { get; set; }
        public double? SubTotal { get; set; }
        public double? Tax { get; set; }
        public double? SystemFair { get; set; }
        public double? NetTotal { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
        public int? TransactionId { get; set; }
        public string? StatusCode { get; set; }
        public int? StatusCodeId { get; set; }
    }
}
