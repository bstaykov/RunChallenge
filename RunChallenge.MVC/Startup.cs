using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunChallenge.MVC.Startup))]
namespace RunChallenge.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
