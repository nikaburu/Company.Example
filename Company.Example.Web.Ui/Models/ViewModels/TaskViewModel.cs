namespace Company.Example.Web.Ui.Models.ViewModels
{
	public class TaskViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string State { get; set; }

		public string Description { get; set; }

		public string ProjectName { get; set; }

		public static string[] TaskState =
			{
				"Opened",
				"InProgress",
				"Finished",
				"Closed"
			};
	}
}