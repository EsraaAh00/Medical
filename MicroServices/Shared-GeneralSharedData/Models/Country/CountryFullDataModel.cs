using SharedModels.Models;
namespace Shared_GeneralSharedData.Models.Country
{
    public class CountryFullDataModel : FullyBaseModel
    {
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Code { get; set; }
        public int? PhoneNumberDigetsCount { get; set; }
        public string? ShortName { get; set; }
        public string? Active { get; set; }
        public int? ActiveCode { get; set; }
    }
}
