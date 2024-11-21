using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Client_ClientRelationMangement.Entities.Logger
{
    public class Logger : LogModel
    {
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass)
        {
        }
    }
}
