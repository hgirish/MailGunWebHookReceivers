using System.Web.Http;
using WebHooksReceiversMailGun.Extensions;

namespace GhWebHooks
{
    public static class WebHookConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.InitializeReceiveMailGunWebHooks();
        }
    }
}