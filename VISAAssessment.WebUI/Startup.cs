using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VISAAssessment.WebUI.Startup))]
namespace VISAAssessment.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
