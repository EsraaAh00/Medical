namespace SharedModels.Models.Filter
{
    public class DatePagedFilterModel : PagedFilterModel
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
