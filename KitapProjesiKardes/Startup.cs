using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KitapProjesiKardes.Startup))]
namespace KitapProjesiKardes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
