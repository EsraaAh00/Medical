using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SharedModels.Helpers;
namespace Vendor_ListingManagement.Enums
{
    public enum TypeEnum
    {
        [Display(Name = "Numerical")]
        Numerical = 1,
        [Display(Name = "Text")]
        Text = 2,   
        [Display(Name = "Location")]
        Location = 3,
        [Display(Name = "TimeRange")]
        TimeRange = 4,
        [Display(Name = "ListPoints")]
        ListPoints = 5,
        [Display(Name = "ListPointsVector")]
        ListPointsVector = 6,
        [Display(Name = "ListPointsTitleDescription")]
        ListPointsTitleDescription = 7,
        [Display(Name = "TripItinerary")]
        TripItinerary = 8,
        [Display(Name = "Aminities")]
        Aminities = 9,
        [Display(Name = "Bool")]
        Bool = 10,
        [Display(Name = "DateTime")]
        DateTime = 11,
        [Display(Name = "Rooms")]
        Rooms = 12,
    }
    public enum StateEnum
    {
        [Display(Name = "ItemActivate")]
        ItemActivate = 1,
        [Display(Name = "ItemDeactivate")]
        ItemDeactivate = 2,
    }
    public enum ChargeFrequencyType
    {
        [Display(Name = "Km")]
        PerKm = 1,
        [Display(Name = "PerNight")]
        PerNight = 2,
        [Display(Name = "PerHour")]
        PerHour = 3,
        [Display(Name = "PerDay")]
        PerDay = 4,
    }
    public enum ApplicableType
    {
        [Display(Name = "PerGroup")]
        PerGroup = 1,
        [Display(Name = "PerPerson")]
        PerPerson = 2
    }
    public enum DetailSettingCode
    {
        [Display(Name = "VehicleItemSpecification")]
        VehicleItemSpecification = 111,
        [Display(Name = "TripItemConfigration")]
        TripItemConfigration = 121,
        [Display(Name = "TripItemItemItinerary")]
        TripItemItemItinerary = 122,
        [Display(Name = "TripItemPickupAndDeparture")]
        TripItemPickupAndDeparture = 123,
        [Display(Name = "AgencyItemPoint")]
        AgencyItemPoint = 13,
        [Display(Name = "AgencyItemAccessabilityPoint")]
        AgencyItemAccessabilityPoint = 14,
        [Display(Name = "HotelItemConfigration")]
        HotelItemConfigration = 21,
        [Display(Name = "HotelItemFeatureOption")]
        HotelItemFeatureOption = 22,
        [Display(Name = "HotelItemAccessabilityPoint")]
        HotelItemAccessabilityPoint = 23, 
        [Display(Name = "RentalItemHighlights")]
        RentalItemHighlights = 31,
        [Display(Name = "RentalItemConfigration")]
        RentalItemConfigration = 32,
        [Display(Name = "RentalItemFeatureOption")]
        RentalItemFeatureOption = 33,
        [Display(Name = "RentalItemAccessabilityPoint")]
        RentalItemAccessabilityPoint = 34
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