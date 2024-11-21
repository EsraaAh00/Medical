using SharedModels.Entities;

namespace System_ClientRelationMangement.Entities
{
    public class Complaint : FullyBaseEnity
    {
        public int? ClientId { get; set; }
        public int? VendorBuissnesId { get; set; }
        public int? OrderId { get; set; }
        public int? TicketId { get; set; }
        public int? HandledBy { get; set; }
        public string? ComplaintTypeCode { get; set; }
        public int? ComplaintTypeCodeId { get; set; }
        public string? ComplaintDescription { get; set; }
        public string? ComplaintDescriptionLocalized { get; set; }
        public bool? Resolved { get; set; }
        public DateOnly? IssuedIn { get; set; }
        public DateOnly? ClosedIn { get; set; }
        public string? StatusCode { get; set; }
        public int? StatusCodeId { get; set; }
    }
}
