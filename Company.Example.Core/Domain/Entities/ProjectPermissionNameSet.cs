using Company.Example.CrossCutting;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class ProjectPermissionNameSet
    {
        public ProjectPermissionNameSet()
        {
            this.EmployeeToProjectPermissions = new HashSet<EmployeeToProjectPermission>();
        }

        public int ProjectPermissionNameSetId { get; set; }

        public ProjectActionType ProjectActionType { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<EmployeeToProjectPermission> EmployeeToProjectPermissions { get; set; }
    }
}