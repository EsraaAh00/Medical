using Nancy.Json;
using SharedModels.Models;
using System.Net;
namespace SharedModels.Helpers
{
    public class NotifactionHelper
    {  
        
            private static string serverKey = "AAAAZpUt6kw:APA91bFRSYE-XK2GgCDdv0SV5RAcC9bZnGbBZfWCH9hIS5VlQYVXaDsdIRljYMO6cQ4WFy6EvTaGIWCAZKNPpOLiwV3bqLuOU7LR_BYKHpyfNB9qYw22xMmXGoCUKbIvRPvheta8T6E5";
            private static string senderId = "440589478476";
            private static string webAddr = "https://fcm.googleapis.com/fcm/send";

            public static  string SendNotification(NotificationModel notificationModel)
            {
                var result = "-1";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                httpWebRequest.Method = "POST";
 
                var serializer = new JavaScriptSerializer();
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = serializer.Serialize(getPayload(notificationModel));
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }

            static object getPayload(NotificationModel notificationModel) {
            if (notificationModel.isNotificable) {
                return new
                {
                    to =   notificationModel.To,
                    priority = "high",
                    content_available = true
                    ,
                    data = new
                    {
                        title = notificationModel.TitleEn,
                        body = notificationModel.ContentEn,
                        dataId = notificationModel.dataId,
                        mobileRedirect = notificationModel.MobileRedirect,
                        notificationType = notificationModel.NotificationType,
                        isNotificable = true
                    },
                   /* notification = new
                    {
                        title = notificationModel.TitleEn,
                        body = notificationModel.ContentEn,
                        dataId = notificationModel.dataId,
                    }*/

                };
            }
            else {
                return new
                {
                    to = notificationModel.To,
                    priority = "high",
                    content_available = true
                    ,
                    data = new
                    {
                        title = notificationModel.Title,
                        body = notificationModel.Content,
                        dataId = notificationModel.dataId,
                        mobileRedirect = notificationModel.MobileRedirect,
                        notificationType = notificationModel.NotificationType
                    }

                };
            }
        }




        public static string CreateUserTopic(int ?UserId) {
            return "user_topic_"+UserId.ToString();
        }
      
    }
}
    

