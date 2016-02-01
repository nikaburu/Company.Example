using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}