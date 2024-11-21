using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SharedModels.Helpers;
namespace Shared_GeneralSharedData.Enums
{
    public enum ActiveEnum
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "InActive")]
        InActive = 2,
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