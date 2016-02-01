using System;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class ProjectToEmployee
    {
        public int Id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ProjectRole EmploeeRoleOnProject { get; set; }
        public virtual Project Project { get; set; }
    }
}	 