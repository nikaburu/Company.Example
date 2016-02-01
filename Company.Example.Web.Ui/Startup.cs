using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Company.Example.Web.Ui.Startup))]

namespace Company.Example.Web.Ui
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
