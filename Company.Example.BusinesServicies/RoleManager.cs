using Company.Example.CrossCutting;

namespace Company.Example.BusinesServices
{
	public class TestRoleManager : IRoleManager
	{
		#region constructor

		private readonly IPermissionManager _permissionManager;

		public TestRoleManager(IPermissionManager permissionManager)
		{
			_permissionManager = permissionManager;
		}

		#endregion constructor

		#region IsAllowed

		public bool IsGlobalActionAllowed(string userName, GlobalActionType actionType)
		{
			if (string.IsNullOrEmpty(userName)) return false;

			var login = GetLoginFromUserName(userName);
			var projectPermissions = _permissionManager.GetGlobalPermissions(login);
			if (projectPermissions.ContainsKey(actionType))
			{
				return projectPermissions[actionType];
			}

			return false;
		}

		public bool IsProjectActionAllowed(string userName, int projectId, ProjectActionType actionType)
		{
			if (string.IsNullOrEmpty(userName)) return false;

			var login = GetLoginFromUserName(userName);
			var projectPermissions = _permissionManager.GetProjectPermissions(login, projectId);
			if (projectPermissions.ContainsKey(actionType))
			{
				return projectPermissions[actionType];
			}

			return false;
		}

		#endregion IsAllowed

		#region private methods

		private string GetLoginFromUserName(string userName)
		{
			var parts = userName.Split(new char[] { '\\' });
			if (parts.Length > 1)
			{
				return parts[parts.Length - 1];
			}
			return userName;
		}

		#endregion private methods
	}
}