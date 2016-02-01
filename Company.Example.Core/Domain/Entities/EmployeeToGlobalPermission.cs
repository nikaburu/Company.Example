using Company.Example.CrossCutting;

namespace Company.Example.Core.Domain.Entities
{
	public partial class EmployeeToGlobalPermission
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public GlobalActionType PermissionId { get; set; }
        public bool PermissionValue { get; set; }
    
        public virtual Employee Employees { get; set; }
        public virtual GlobalPermissionNameSet PermissionName { get; set; }
    }
}