namespace SharedModels.Models.Filter
{
    public class NumberRangePagedFilterModel : PagedFilterModel
    {
        public int? Start { get; set; }
        public int? End { get; set; }
    }
}
