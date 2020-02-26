using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiSelectCascading.Startup))]
namespace MultiSelectCascading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
