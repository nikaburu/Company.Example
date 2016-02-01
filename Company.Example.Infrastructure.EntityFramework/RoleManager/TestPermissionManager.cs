using Company.Example.BusinesServices;
using Company.Example.CrossCutting;
using System;
using System.Collections.Generic;

namespace Company.Example.Infrastructure.EntityFramework.RoleManager
{
	/// <summary>
	/// Test class
	/// </summary>
	public class TestPermissionManager : IPermissionManager
	{
		public Dictionary<GlobalActionType, bool> GetGlobalPermissions(string userName)
		{
			return GetDefaultGlobalPermissions();
		}

		public Dictionary<ProjectActionType, bool> GetProjectPermissions(string userName, int projectId)
		{
			return new Dictionary<ProjectActionType, bool>
				{
					{ProjectActionType.ViewProject, true},
					
					{ProjectActionType.ViewTasks, true},
					{ProjectActionType.ModifyTasks, true},
					
					{ProjectActionType.ViewEmployees, true},
					{ProjectActionType.ModifyEmployees, true},
					
					{ProjectActionType.ViewBilling, true},
					{ProjectActionType.ViewStatistics, true},
					{ProjectActionType.Export, true},
					{ProjectActionType.ViewTimeReports, true},
				};
		}

		public Dictionary<ProjectActionType, bool> GetDefaultProjectPermissions(EmployeeRole employeeRole)
		{
			return new Dictionary<ProjectActionType, bool>
				{
					{ProjectActionType.ViewProject, true},
					
					{ProjectActionType.ViewTasks, true},
					{ProjectActionType.ModifyTasks, true},
					
					{ProjectActionType.ViewEmployees, true},
					{ProjectActionType.ModifyEmployees, true},
					
					{ProjectActionType.ViewBilling, true},
					{ProjectActionType.ViewStatistics, true},
					{ProjectActionType.Export, true},
					{ProjectActionType.ViewTimeReports, true},
				};
		}

		public Dictionary<GlobalActionType, bool> GetDefaultGlobalPermissions()
		{
			return new Dictionary<GlobalActionType, bool>
				{
					{GlobalActionType.ViewProjects, true},
					{GlobalActionType.ModifyProjects, true},
				};
		}

		public Dictionary<ProjectActionType, bool> GetDefaultProjectPermissions(string userName)
		{
			return GetDefaultProjectPermissions(EmployeeRole.Developer);
		}

		#region GetEmployeeRole

		public EmployeeRole GetEmployeeRoleFromId(int roleId)
		{
			switch (roleId)
			{
				case 4: return EmployeeRole.ProjectManager;
				case 3: return EmployeeRole.Leader;
				case 1: return EmployeeRole.Developer;
				case 2: return EmployeeRole.Tester;
			}
			throw new ArgumentException("Unknown employee role");
		}

		public EmployeeRole GetEmployeeRoleFromString(string roleName)
		{
			switch (roleName)
			{
				case "Project Manager": return EmployeeRole.ProjectManager;
				case "Leader": return EmployeeRole.Leader;
				case "Developer": return EmployeeRole.Developer;
				case "Tester": return EmployeeRole.Tester;
			}
			throw new ArgumentException("Unknown employee role");
		}

		#endregion GetEmployeeRole
	}
}