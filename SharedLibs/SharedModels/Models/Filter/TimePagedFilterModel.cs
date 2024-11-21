namespace SharedModels.Models.Filter
{
    public class TimePagedFilterModel : PagedFilterModel
    {
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }
    }
}
