using SharedModels.Models;
namespace Shared_GeneralSharedData.Models.Currency
{
    public class CurrencyFullDataModel : FullyBaseModel
    {
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? Prefix { get; set; }
        public string? PrefixLocalized { get; set; }
        public string? Symbol { get; set; }
    }
}
