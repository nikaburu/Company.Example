using Company.Example.CrossCutting;
using System.Collections.Generic;

namespace Company.Example.BusinesServicies
{
	public interface IPermissionManager
	{
		Dictionary<GlobalActionType, bool> GetGlobalPermissions(string userName);
		Dictionary<ProjectActionType, bool> GetProjectPermissions(string userName, int projectId);
	}
}