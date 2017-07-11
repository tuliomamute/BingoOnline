using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BingoOnline.Startup))]
namespace BingoOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
