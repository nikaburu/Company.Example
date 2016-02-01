namespace Company.Example.CrossCutting
{
	public enum GlobalActionType : byte
	{
		ViewProjects = 1,
		ModifyProjects = 2
	}

	public enum ProjectActionType : byte
	{
		ViewProject = 1,

		ViewTasks = 2,
		ModifyTasks = 3,

		ViewEmployees = 4,
		ModifyEmployees = 5,

		ViewBilling = 6,
		ViewStatistics = 7,
		Export = 8,
		ViewTimeReports = 9
	}
}
