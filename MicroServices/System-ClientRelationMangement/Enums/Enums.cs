using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SharedModels.Helpers;
namespace System_ClientRelationMangement.Enums
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