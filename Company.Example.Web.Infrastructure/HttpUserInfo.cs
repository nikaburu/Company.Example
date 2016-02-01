using System.Web;
using Company.Example.CrossCutting;

namespace Company.Example.Web.Infrastructure
{
	public class HttpUserInfo : IUserInfo
	{
		public string UserName { get { return HttpContext.Current.User.Identity.Name; } }
		public bool IsAuthenticated { get { return HttpContext.Current.Request.IsAuthenticated; } }
	}
}