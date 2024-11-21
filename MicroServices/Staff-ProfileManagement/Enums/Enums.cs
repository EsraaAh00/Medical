using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SharedModels.Helpers;
namespace Staff_StaffProfileManagement.Enums
{
    public enum RequestStatusEnum
    {
        [Display(Name = "New")]
        New = 1,
        [Display(Name = "Accepted")]
        Accepted = 2,
        [Display(Name = "Rejected")]
        Rejected = 3,
    }
    public enum RejectionReasonEnum
    {
        [Display(Name = "Account Setup")]
        AccountSetup = 1,
        [Display(Name = "Manager Data")]
        ManagerData = 2,
        [Display(Name = "Bussiness Identification")]
        BussinessIdentification = 3,
        [Display(Name = "Vendor Documentation")]
        VendorDocumentation = 4,
        [Display(Name = "Vendor Bussiness Location")]
        VendorBussinessLocation = 5,
    }
    public enum StateEnum
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Inactive")]
        Inactive = 2,
        [Display(Name = "Blocked")]
        Blocked = 3,
    }
    public enum BusinessStatusEnum
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Inactive")]
        Inactive = 2,
    }
    public enum DistanceUnitEnum
    {
        [Display(Name = "Meter")]
        Meter = 1,
        [Display(Name = "Kilometer")]
        Kilometer = 2,
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return DicHelper.GetMessage(enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()?
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName() ?? "");
        }
    }
}