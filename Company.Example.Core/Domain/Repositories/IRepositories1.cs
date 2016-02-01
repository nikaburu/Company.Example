
using Company.Example.Core.Domain.Entities;
namespace Company.Example.Core.Domain.Repositories
{
			public partial interface IDepartmentRepository : IRepository<Department>
		{
		}
		
			public partial interface IEmployeeRepository : IRepository<Employee>
		{
		}
		
			public partial interface IEmployeeToGlobalPermissionRepository : IRepository<EmployeeToGlobalPermission>
		{
		}
		
			public partial interface IEmployeeToProjectPermissionRepository : IRepository<EmployeeToProjectPermission>
		{
		}
		
			public partial interface IGlobalPermissionNameSetRepository : IRepository<GlobalPermissionNameSet>
		{
		}
		
			public partial interface IProjectRepository : IRepository<Project>
		{
		}
		
			public partial interface IProjectPermissionNameSetRepository : IRepository<ProjectPermissionNameSet>
		{
		}
		
			public partial interface IProjectRoleRepository : IRepository<ProjectRole>
		{
		}
		
			public partial interface IProjectToEmployeeRepository : IRepository<ProjectToEmployee>
		{
		}
		
			public partial interface ITaskRepository : IRepository<Task>
		{
		}
		
			public partial interface ITimeEntryRepository : IRepository<TimeEntry>
		{
		}
		
			public partial interface IUserRepository : IRepository<User>
		{
		}
		
	}
