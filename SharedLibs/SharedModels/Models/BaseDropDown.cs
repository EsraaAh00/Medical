

namespace SharedModels.Models
{
    public class BaseDropDown
    {
        public int? Id { get; set; }
        public string? Name { get; set; } = "";
        public string? value { get; set; } = "";
        public int? ParentId { get; set; }
        public bool? IsEnd { get; set; }
        public int? OrderInList { get; set; }
    }
}
