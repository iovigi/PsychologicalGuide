using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PsychologicalGuide.Web.Startup))]
namespace PsychologicalGuide.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
