using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureOAuth(app);
            ConfigureJwt(app);

            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
