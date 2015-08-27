using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myHomeWork.Startup))]
namespace myHomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
