using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Operation_OperationsManagement.Entities.Logger{
public class Logger: LogModel{
        public Logger() { }
        public Logger(LogModel baseClass) : base(baseClass) {
        }
}}
