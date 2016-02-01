using Company.Example.CrossCutting;
using System.Collections.Generic;

namespace Company.Example.Core.Domain.Entities
{
	public partial class GlobalPermissionNameSet
    {
        public GlobalPermissionNameSet()
        {
            this.EmployeeToGlobalPermissions = new HashSet<EmployeeToGlobalPermission>();
        }

        public int GlobalPermissionNameSetId { get; set; }

        public GlobalActionType GlobalActionType { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<EmployeeToGlobalPermission> EmployeeToGlobalPermissions { get; set; }
    }
}