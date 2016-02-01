

using Company.Example.Core.Domain.Entities;

using Company.Example.Core.Domain.Repositories;

namespace Company.Example.Infrastructure.EntityFramework.Repositories
{
		sealed public partial class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class EmployeeToGlobalPermissionRepository : RepositoryBase<EmployeeToGlobalPermission>, IEmployeeToGlobalPermissionRepository
    {
        public EmployeeToGlobalPermissionRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class EmployeeToProjectPermissionRepository : RepositoryBase<EmployeeToProjectPermission>, IEmployeeToProjectPermissionRepository
    {
        public EmployeeToProjectPermissionRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class ProjectRoleRepository : RepositoryBase<ProjectRole>, IProjectRoleRepository
    {
        public ProjectRoleRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class ProjectToEmployeeRepository : RepositoryBase<ProjectToEmployee>, IProjectToEmployeeRepository
    {
        public ProjectToEmployeeRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class TimeEntryRepository : RepositoryBase<TimeEntry>, ITimeEntryRepository
    {
        public TimeEntryRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExampleDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
	}
