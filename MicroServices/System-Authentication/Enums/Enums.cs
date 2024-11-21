using SharedModels.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace System_Authentication.Enums
{
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