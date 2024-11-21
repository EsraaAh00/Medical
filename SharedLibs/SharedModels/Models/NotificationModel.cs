using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string ContentAr { set; get; } = "";
        public string ContentEn { set; get; } = "";
        public string TitleEn { set; get; } = "";
        public string TitleAr { set; get; } = "";
        public string Title { set; get; } = "";
        public string Content { set; get; } = "";
        public int? UserId { get; set; }
        public string? Image { get; set; }
        public int? SenderUserId { get; set; }
        public int? dataId { set; get; }
        public string MobileRedirect { set; get; } = "";
        public int NotificationType { set; get; }
        public string NotificationTypeString { set; get; } = "";
        public DateTime createdDate { set; get; }
        [JsonIgnore]
        public string ?DeviceToken { get; set; } 
        [JsonIgnore]
        public string ?Topic { get; set; } 
        [JsonIgnore]
        public string ?To { get {
                return DeviceToken ?? $"/topics/{Topic}";
            
            } }
        [JsonIgnore]
        public bool isNotificable { set; get; } = true;
        public bool ?Seen { set; get; } = true;
    }
}
