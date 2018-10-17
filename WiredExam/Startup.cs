using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WiredExam.Startup))]
namespace WiredExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
