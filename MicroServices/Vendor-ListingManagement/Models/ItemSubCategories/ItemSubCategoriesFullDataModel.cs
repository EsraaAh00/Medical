using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendor_ListingManagement.Models.ItemSubCategories
{
    public class ItemSubCategoriesFullDataModel : FullyBaseModel
    {
        public int? ItemCategoriesId { get; set; }
        public string? ItemCategoriesName { get; set; }
    }
}
