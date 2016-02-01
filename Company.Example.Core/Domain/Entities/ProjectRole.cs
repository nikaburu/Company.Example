using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class ProjectRole
	{
		public ProjectRole()
		{
			this.EmployeesToProjects = new HashSet<ProjectToEmployee>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<ProjectToEmployee> EmployeesToProjects { get; set; }
	}
}