using SharedModels.Entities;
namespace Vendor_ProfileManagement.Entities
{
    public class Feature : FullyBaseEnity
    {
        public string? Icon { get; set; }
        public List<Option>? Options { get; set; }
    }
}
