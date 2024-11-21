using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_StaffProfileManagement.Entities.Logger
{
    public class Logger : LogModel
    {
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass)
        {
        }
    }
}
