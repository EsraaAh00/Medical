using Microsoft.AspNetCore.Components.Web.Virtualization;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace SharedModels.Models
{
    public class LogModel
    {
        public int Id { set; get; }
        public int? UserId { set; get; }
        public string? UserName { set; get; }
        public int? RecordId { set; get; }
        public string? EntityName { set; get; }
        public string? Description { set; get; }
        public int? LogType { set; get; } = (int)LogTypeEnum.Add;
        public string? JsonBefore { set; get; }
        public string? JsonAfter { set; get; }
        public DateTime? TransactionDate { set; get; } = DateTime.Now;
        public LogModel() { }
        public LogModel(LogModel baseClass)
        {
            Id = baseClass.Id;
            UserId = baseClass.UserId;
            UserName = baseClass.UserName;
            RecordId = baseClass.RecordId;
            EntityName = baseClass.EntityName;
            Description = baseClass.Description;
            LogType = baseClass.LogType;
            JsonBefore = baseClass.JsonBefore;
            JsonAfter = baseClass.JsonAfter;
            TransactionDate = baseClass.TransactionDate;
        }
        public T? GetModelFromJsonBefore<T>()
        {
            T? model = JsonConvert.DeserializeObject<T>(JsonBefore ?? "");
            return model;

        }

    }

    public enum LogTypeEnum
    {
        Add = 1,
        Delete = 2,
        Edit = 3,
        Activate = 4,
    }
}
