using Company.Example.BusinesServices;
using Company.Example.Core.Domain.Repositories;
using Company.Example.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.Example.Infrastructure.EntityFramework.RoleManager
{
	public class DbPermissionManager : IPermissionManager
	{
		#region constructor

		private readonly IEmployeeRepository _employeeRepository;

		public DbPermissionManager(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		} 

		#endregion constructor

		#region Get permissions

		/// <summary>
		/// Returns user's global permissions if in database or empty dictionary otherwise.
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public Dictionary<GlobalActionType, bool> GetGlobalPermissions(string userName)
		{
			var result = new Dictionary<GlobalActionType, bool>();

			if (string.IsNullOrEmpty(userName)) return result;

			var employee = _employeeRepository.FetchAll().FirstOrDefault(e => e.Login == userName); // TODO: Compare strings ignoring case
			if (employee != null)
			{
				result = employee.GlobalPermissions.ToDictionary(p => p.PermissionId, p => p.PermissionValue);
			}

			return result;
		}

		/// <summary>
		/// Returns user's project permissions if in database or empty dictionary otherwise.
		/// </summary>
		/// <param name="userName"></param>
		/// /// <param name="projectId"></param>
		/// <returns></returns>
		public Dictionary<ProjectActionType, bool> GetProjectPermissions(string userName, int projectId)
		{
			var result = new Dictionary<ProjectActionType, bool>();

			if (string.IsNullOrEmpty(userName) || projectId < 1) return result;

			var employee = _employeeRepository.FetchAll().FirstOrDefault(e => e.Login == userName); // TODO: Compare strings ignoring case
			if (employee != null)
			{
				result = employee.ProjectPermissions.Where(p => p.ProjectId == projectId)
													.ToDictionary(p => p.PermissionId, p => p.PermissionValue);
			}

			return result;
		}

		#endregion Get permissions

		#region Get DEFAULT permissions

		public Dictionary<GlobalActionType, bool> GetDefaultGlobalPermissions()
		{
			return new Dictionary<GlobalActionType, bool> {
				{ GlobalActionType.ViewProjects, true },
				{ GlobalActionType.ModifyProjects, false }};
		}

		public Dictionary<ProjectActionType, bool> GetDefaultProjectPermissions(EmployeeRole employeeRole)
		{
			switch (employeeRole)
			{
				case EmployeeRole.ProjectManager:
					return new Dictionary<ProjectActionType, bool>
						{
							{ ProjectActionType.ViewProject, true},
							{ ProjectActionType.ViewTasks, true},
							{ ProjectActionType.ModifyTasks, true},
							{ ProjectActionType.ViewEmployees, true},
							{ ProjectActionType.ModifyEmployees, true},
							{ ProjectActionType.ViewTimeReports, true},
							{ ProjectActionType.ViewBilling, true},
							{ ProjectActionType.ViewStatistics, true},
							{ ProjectActionType.Export, true}
						};
				case EmployeeRole.Leader:
					return new Dictionary<ProjectActionType, bool>
						{
							{ ProjectActionType.ViewProject, true},
							{ ProjectActionType.ViewTasks, true},
							{ ProjectActionType.ModifyTasks, true},
							{ ProjectActionType.ViewEmployees, true},
							{ ProjectActionType.ModifyEmployees, true},
							{ ProjectActionType.ViewTimeReports, true},
							{ ProjectActionType.ViewBilling, true},
							{ ProjectActionType.ViewStatistics, true},
							{ ProjectActionType.Export, true}
						};
				case EmployeeRole.Developer:
					return new Dictionary<ProjectActionType, bool>
						{
							{ ProjectActionType.ViewProject, true},
							{ ProjectActionType.ViewTasks, true},
							{ ProjectActionType.ModifyTasks, true},
							{ ProjectActionType.ViewEmployees, true},
							{ ProjectActionType.ModifyEmployees, true},
							{ ProjectActionType.ViewBilling, true},
							{ ProjectActionType.ViewTimeReports, true},
							{ ProjectActionType.ViewStatistics, true},
							{ ProjectActionType.Export, true}
						};
				case EmployeeRole.Tester:
					return new Dictionary<ProjectActionType, bool>
						{
							{ ProjectActionType.ViewProject, true},
							{ ProjectActionType.ViewTasks, true},
							{ ProjectActionType.ModifyTasks, true},
							{ ProjectActionType.ViewEmployees, true},
							{ ProjectActionType.ModifyEmployees, true},
							{ ProjectActionType.ViewBilling, true},
							{ ProjectActionType.ViewTimeReports, true},
							{ ProjectActionType.ViewStatistics, true},
							{ ProjectActionType.Export, true}
						};
				default:
					return new Dictionary<ProjectActionType, bool>();
			}
		}

		#endregion Get DEFAULT permissions

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
