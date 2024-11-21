using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Helpers
{
    public static class EmailHelper
    {
        private static readonly string? _sendGridApiKey="";
        private static readonly string? SystemMail="";
        private static readonly string? SystemName="";

        
        public static async Task<BaseResponse> SendEmail(string toEmail, string subject, string body)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress(SystemMail, SystemName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new BaseResponse { IsError = false };
            }

            return new BaseResponse { IsError = true };
        }


    }
}
