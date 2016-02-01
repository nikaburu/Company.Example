using Company.Example.CrossCutting;
using Company.Example.Infrastructure.DependecyResolution.CrossCutting;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Filters
{
	public class GlobalActionAuthorizationAttribute : FilterAttribute, IActionFilter
	{
		#region constructor

		private readonly GlobalActionType _actionType;

		public GlobalActionAuthorizationAttribute(GlobalActionType actionType)
		{
			_actionType = actionType;
		}

		#endregion constructor

		#region methods

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var roleManager = RoleManager.Current;

			var allowed = false;

			if (filterContext.HttpContext.User != null)
			{
				allowed = roleManager.IsGlobalActionAllowed(filterContext.HttpContext.User.Identity.Name, _actionType);
			}

			if (!allowed)
			{
				filterContext.Result = new HttpUnauthorizedResult(string.Format("You don't have enough permissions to perform [{0}] action.", _actionType));
			}
		}

		#endregion methods
	}
}