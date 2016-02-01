using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class Task
    {
        public Task()
        {
            this.TimeEntries = new HashSet<TimeEntry>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Assignee { get; set; }
    }
} 