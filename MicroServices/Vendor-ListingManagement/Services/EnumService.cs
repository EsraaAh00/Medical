using SharedModels.Models;
using Vendor_ListingManagement.Enums;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Interfaces.Services;

namespace Vendor_ListingManagement.Services
{
    public class EnumService  : IEnumService
    {
        public List<BaseDropDown>? GetTypeEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(TypeEnum)).Cast<TypeEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
        public List<BaseDropDown>? GetStateEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(StateEnum)).Cast<StateEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
        public List<BaseDropDown>? GetChargeFrequencyTypeEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(ChargeFrequencyType)).Cast<ChargeFrequencyType>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
        public List<BaseDropDown>? GetApplicableTypeEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(ApplicableType)).Cast<ApplicableType>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
    }
}
