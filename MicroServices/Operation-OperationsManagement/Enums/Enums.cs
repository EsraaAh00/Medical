using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SharedModels.Helpers;
namespace Operation_OperationsManagement.Enums
{
    public static class EnumExtensions
    {
        public enum PaymentStatusEnum
        {
            [Display(Name = "Paid")]
            Payed = 1,
            [Display(Name = "Pending")]
            Pending = 2,
            [Display(Name = "Failed")]
            Failed = 3
        }

        public enum OrderItemStatusEnum
        {
            [Display(Name = "Confirmed")]
            Confirmed = 1,
            [Display(Name = "Canceled")]
            Canceled = 2
        }

        public enum TicketStatusEnum
        {
            [Display(Name = "Issued")]
            Issued = 1,
            [Display(Name = "Received")]
            Received = 2,
            [Display(Name = "Expired")]
            Expired = 3,
            [Display(Name = "Canceled")]
            Canceled = 4
        }


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