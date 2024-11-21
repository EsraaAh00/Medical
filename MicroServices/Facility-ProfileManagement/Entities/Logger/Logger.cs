using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facility_FacilityProfileManagement.Entities.Logger
{
    public class Logger : LogModel
    {
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass)
        {
        }
    }
}
