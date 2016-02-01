using Company.Example.CrossCutting;

namespace Company.Example.Core.Domain.Entities
{
	public partial class EmployeeToProjectPermission
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public ProjectActionType PermissionId { get; set; }
        public bool PermissionValue { get; set; }
    
        public virtual Employee Employees { get; set; }
        public virtual ProjectPermissionNameSet PermissionName { get; set; }
        public virtual Project Projects { get; set; }
    }
}