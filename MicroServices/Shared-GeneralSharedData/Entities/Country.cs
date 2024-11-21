using SharedModels.Entities;
namespace Shared_GeneralSharedData.Entities
{
    public class Country : FullyBaseEnity
    {
        public string? Image { get; set; }
        public string? Code { get; set; }
        public int? PhoneNumberDigetsCount { get; set; }
        public string? ShortName { get; set; }
        public string? Active { get; set; }
        public int? ActiveCode { get; set; }
    }
}
