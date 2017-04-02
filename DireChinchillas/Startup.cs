using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DireChinchillas.Startup))]
namespace DireChinchillas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
