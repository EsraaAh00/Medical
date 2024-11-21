using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared_GeneralSharedData.Entities.Logger
{
    public class Logger : LogModel
    {
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass)
        {
        }
    }
}
