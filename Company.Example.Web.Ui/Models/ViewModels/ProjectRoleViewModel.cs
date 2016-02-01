using System.ComponentModel.DataAnnotations;

namespace Company.Example.Web.Ui.Models.ViewModels
{
	public class ProjectRoleViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }
	}
}