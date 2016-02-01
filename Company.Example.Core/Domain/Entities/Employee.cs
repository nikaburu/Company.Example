using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class Employee
	{
		public Employee()
		{
			this.Projects = new HashSet<ProjectToEmployee>();
			this.TimeEntries = new HashSet<TimeEntry>();
			this.AssignedTasks = new HashSet<Task>();
			this.GlobalPermissions = new HashSet<EmployeeToGlobalPermission>();
			this.ProjectPermissions = new HashSet<EmployeeToProjectPermission>();
		}

		public int Id { get; set; }
		public string Login { get; set; }

		public string LastName { get; set; }
		public string FirstName { get; set; }

		public DateTime? LastLoginDate { get; set; }
		public bool IsAllowedToLogin { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<ProjectToEmployee> Projects { get; set; }
		public virtual Department Department { get; set; }
		public virtual ICollection<TimeEntry> TimeEntries { get; set; }
		public virtual ICollection<Task> AssignedTasks { get; set; }
		public virtual ICollection<EmployeeToGlobalPermission> GlobalPermissions { get; set; }
		public virtual ICollection<EmployeeToProjectPermission> ProjectPermissions { get; set; }
	}
}