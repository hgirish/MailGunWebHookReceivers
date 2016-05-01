using System.ComponentModel;
using System.Web.Http;
using Microsoft.AspNet.WebHooks.Config;

namespace WebHooksReceiversMailGun.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="HttpConfiguration"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class MailChimpHttpConfigurationExtensions
    {
        /// <summary>
        /// Initializes support for receiving MailGun WebHooks. 
        /// A sample WebHook URI is '<c>https://&lt;host&gt;/api/webhooks/incoming/mailgun/{id}?code=83699ec7c1d794c0c780e49a5c72972590571fd8</c>'.
        /// For security reasons the WebHook URI must be an <c>https</c> URI and contain a 'code' query parameter with the
        /// same value as configured in the '<c>MS_WebHookReceiverSecret_MailChimp</c>' application setting.
        /// The 'code' parameter must be between 32 and 128 characters long.
        /// For details about MailGun WebHooks, see <c>https://documentation.mailgun.com/user_manual.html#webhooks</c>. 
        /// </summary>
        /// <param name="config">The current <see cref="HttpConfiguration"/>config.</param>
        public static void InitializeReceiveMailGunWebHooks(this HttpConfiguration config)
        {
            WebHooksConfig.Initialize(config);
        }
        
    }
}