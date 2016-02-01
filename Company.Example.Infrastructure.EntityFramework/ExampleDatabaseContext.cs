using Company.Example.Core.Domain.Entities;
using Company.Example.Infrastructure.EntityFramework.Configurations;
using System.Data.Entity;

namespace Company.Example.Infrastructure.EntityFramework
{
    public class ExampleDatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }

		public DbSet<Employee> EmployeeSet { get; set; }
		public DbSet<ProjectRole> ProjectRoleSet { get; set; }
		public DbSet<Department> DepartmentSet { get; set; }
		public DbSet<Project> ProjectSet { get; set; }
		public DbSet<ProjectToEmployee> ProjectToEmployeeSet { get; set; }
		public DbSet<Core.Domain.Entities.Task> TaskSet { get; set; }
		public DbSet<TimeEntry> TimeEntrySet { get; set; }
		public DbSet<User> UserSet { get; set; }
		public DbSet<EmployeeToGlobalPermission> EmployeeToGlobalPermissionSet { get; set; }
		public DbSet<EmployeeToProjectPermission> EmployeeToProjectPermissionSet { get; set; }
		public DbSet<GlobalPermissionNameSet> GlobalPermissionNameSet { get; set; }
		public DbSet<ProjectPermissionNameSet> ProjectPermissionNameSet { get; set; }
    }
}