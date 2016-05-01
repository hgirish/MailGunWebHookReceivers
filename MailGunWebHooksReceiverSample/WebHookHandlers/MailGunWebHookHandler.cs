using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GhWebHooks.Models;
using MailGunWebHooksReceiverSample.Models;
using Microsoft.AspNet.WebHooks;
using WebHooksReceiversMailGun.WebHooks;

namespace MailGunWebHooksReceiverSample.WebHookHandlers
{
    public class MailGunWebHookHandler : WebHookHandler
    {
        public MailGunWebHookHandler()
        {
            Receiver = MailGunWebHookReceiver.ReceiverName;
        }
        public override  Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {

             var data  = context.GetDataOrDefault<NameValueCollection>();
           

            string token = data["token"];
            string signature = data["signature"];
            string timestamp = data["timestamp"];
            var apiKey = ConfigurationManager.AppSettings["MS_WebHookReceiverSecret_MailGun_PrivateKey"];
            string  eventName =data["event"];
            string recipient = data["recipient"];
            var messageHeaders = data["message-headers"];
            var domain = data["domain"];
            var messageId = data["Message-Id"];
            var myvar1 = data["my_var_1"];
            var myvar2 = data["my-var-2"];
            var bodyPlain = data["body-plain"];
            var code = data["code"];
            var error = data["error"];
            var notification = data["notification"];
            var tag = data["tag"];
            var reason = data["reason"];
            var description = data["description"];
            var subject = messageHeaders.GetSubject();
            EmailTrackerModel model = new EmailTrackerModel
            {
                Created = DateTime.UtcNow,
                BodyPlain = bodyPlain,
                Code = code,
                Description = description,
                Domain = domain,
                Error = error,
                EventName = eventName,
                MessageHeaders = messageHeaders,
                MessageId = messageId,
                Myvar1 = myvar1,
                Myvar2 = myvar2,
                Notification = notification,
                Reason = reason,
                Recipient = recipient,
                Tag = tag,
                Timestamp = timestamp,
                Subject = subject
            };

            bool verified =  MailgunUtil.Verify(apiKey, token, timestamp, signature);
           
            if (verified)
            {
                using (var db = new AppDbContext())
                {
                    db.EmailTrackers.Add(model);
                    db.SaveChanges();
                }
                string reply1 =
                    $"Received event '{eventName}' for recipient '{recipient}' and code '{(string.IsNullOrWhiteSpace(code) ? "" : code)}'";
                
                context.Response = context.Request.CreateResponse(reply1);
               
            }
            else
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, "Received event but verification failed " + subject);
            }
            return Task.FromResult(true);
        }
    }
}