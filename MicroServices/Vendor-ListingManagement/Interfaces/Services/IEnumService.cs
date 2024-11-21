using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IEnumService
    {
        #region CURD
        List<BaseDropDown>? GetTypeEnumDropDownList();
        List<BaseDropDown>? GetStateEnumDropDownList();
        List<BaseDropDown>? GetChargeFrequencyTypeEnumDropDownList();       
        List<BaseDropDown>? GetApplicableTypeEnumDropDownList();

        #endregion
    }
}
