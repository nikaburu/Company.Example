namespace Company.Example.Web.Ui.Models.ViewModels
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }
		
		public string Login { get; set; }

		public string LastLoginDate { get; set; }

		public string Department { get; set; }

		public string IsAllowedToLogin { get; set; }

		public string IsActive { get; set; }
	}
}