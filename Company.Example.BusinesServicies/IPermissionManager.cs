using Company.Example.CrossCutting;
using System.Collections.Generic;

namespace Company.Example.BusinesServices
{
	public interface IPermissionManager
	{
		Dictionary<GlobalActionType, bool> GetGlobalPermissions(string userName);
		Dictionary<ProjectActionType, bool> GetProjectPermissions(string userName, int projectId);

		Dictionary<GlobalActionType, bool> GetDefaultGlobalPermissions();
		Dictionary<ProjectActionType, bool> GetDefaultProjectPermissions(EmployeeRole employeeRole);

		EmployeeRole GetEmployeeRoleFromId(int roleId);
		EmployeeRole GetEmployeeRoleFromString(string roleName);
	}
}