using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
            this.TimeEntries = new HashSet<TimeEntry>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
