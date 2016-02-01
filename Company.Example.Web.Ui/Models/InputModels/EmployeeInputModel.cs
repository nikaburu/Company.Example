using Company.Example.Web.Ui.Models.ViewModels;

namespace Company.Example.Web.Ui.Models.InputModels
{
	public class EmployeeInputModel
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string Login { get; set; }

		public DepartmentViewModel SelectedDepartment { get; set; }

		public bool IsAllowedToLogin { get; set; }

		public bool IsActive { get; set; }
	}
}