using Company.Example.Web.Ui.Models;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Extensions
{
	public static class ControllerExtensions
	{
		public static ActionResult JsonRespose(this Controller controller, object data)
		{
			return new JsonResult() { Data = new { success = true, data = data }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		public static ActionResult JsonRespose(this Controller controller, object data, string message)
		{
			return new JsonResult() { Data = new { success = true, data = data, msg = message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		public static ActionResult JsonRespose(this Controller controller, string error)
		{
			return new JsonResult() { Data = new { success = false, msg = error }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
	}
}