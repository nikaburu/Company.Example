using Company.Example.CrossCutting;
using Company.Example.Infrastructure.DependecyResolution.CrossCutting;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Company.Example.Web.Ui.Extensions
{
	public static class HtmlHelperExtensions
	{
		public static bool GlobalActionAllowed(this HtmlHelper helper, GlobalActionType actionType)
		{
			IRoleManager roleManager = RoleManager.Current;
			return roleManager.IsGlobalActionAllowed(HttpContext.Current.User.Identity.Name, actionType);
		}

		public static bool ProjectActionAllowed(this HtmlHelper helper, int projectId, ProjectActionType actionType)
		{
			IRoleManager roleManager = RoleManager.Current;
			return roleManager.IsProjectActionAllowed(HttpContext.Current.User.Identity.Name, projectId, actionType);
		}

		public static MvcHtmlString GlobalActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, GlobalActionType actionType, object routeValues, object htmlAttributes)
		{
			return htmlHelper.GlobalActionAllowed(actionType) ?
				   htmlHelper.ActionLink(linkText, actionName, routeValues, htmlAttributes) :
				   null;
		}

		public static MvcHtmlString ProjectActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, int projectId, ProjectActionType actionType, object routeValues, object htmlAttributes)
		{
			return htmlHelper.ProjectActionAllowed(projectId, actionType) ?
				   htmlHelper.ActionLink(linkText, actionName, routeValues, htmlAttributes) :
				   null;
		}
	}
}