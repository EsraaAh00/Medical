namespace SharedModels.Models.Filter
{
    public class PagedFilterModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; } = 50;
    }
}
