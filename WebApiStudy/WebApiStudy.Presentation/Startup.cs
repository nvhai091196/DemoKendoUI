using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiStudy.Presentation.Startup))]
namespace WebApiStudy.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
