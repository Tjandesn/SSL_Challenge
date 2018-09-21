using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSL_API.Startup))]
namespace SSL_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
