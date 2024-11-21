using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace System_ClientRelationMangement.Entities.Logger{
public class Logger: LogModel{
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass) {
        }
}}
