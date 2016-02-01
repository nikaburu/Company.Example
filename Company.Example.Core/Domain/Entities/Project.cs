using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class Project
    {
		public Project()
		{
			this.Employees = new HashSet<ProjectToEmployee>();
			this.Tasks = new HashSet<Task>();
			this.ProjectPermissions = new HashSet<EmployeeToProjectPermission>();
		}

		public int Id { get; set; }
		public bool IsClosed { get; set; }
		public Nullable<System.DateTime> DateOfCreation { get; set; }
		public string Name { get; set; }
		public Nullable<System.DateTime> StartDate { get; set; }

		public virtual ICollection<ProjectToEmployee> Employees { get; set; }
		public virtual ICollection<Task> Tasks { get; set; }
		public virtual ICollection<EmployeeToProjectPermission> ProjectPermissions { get; set; }
    }
}