namespace Company.Example.Web.Ui.Models.InputModels
{
	public class TaskInputModel
	{
		public string Name { get; set; }

		public TaskState SelectedState { get; set; }

		public string Description { get; set; }

		public TaskProject SelectedProject { get; set; }
	}

	public class TaskState
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

	public class TaskProject
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}