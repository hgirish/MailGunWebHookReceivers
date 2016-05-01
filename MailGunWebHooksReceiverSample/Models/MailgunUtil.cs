using System;
using System.Security.Cryptography;
using System.Text;

namespace MailGunWebHooksReceiverSample.Models
{
    public class MailgunUtil
    {
        /// <summary>
        /// Authenticates incoming requests to a Mailgun webhook (https://documentation.mailgun.com/user_manual.html#webhooks).
        /// </summary>
        /// <example>
        /// <code>bool verified = MailgunUtil.Verify(API_KEY, Request.Form["token"], Request.Form["timestamp"], Request.Form["signature"])</code>
        /// </example>
        public static bool Verify(string apikey, string token, string timestamp, string signature)
        {
            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(apikey));
            var sigBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(timestamp + token));
            string sigString = BitConverter.ToString(sigBytes).Replace("-", "");
            return signature.Equals(sigString, StringComparison.OrdinalIgnoreCase);
        }
    }
}