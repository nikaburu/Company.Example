using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Extensions;
using Company.Example.Web.Ui.Models.InputModels;
using Company.Example.Web.Ui.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	public class TaskController : DisposableBaseController
	{
		#region Dependencies

		private readonly ITaskRepository _taskRepository;
		private readonly IProjectRepository _projectRepository;
		private readonly IUnitOfWork _unitOfWork;

		public TaskController(IUnitOfWork unitOfWork, ITaskRepository taskRepository, IProjectRepository projectRepository, IDisposableCollection disposables)
			: base(disposables)
		{
			_taskRepository = taskRepository;
			_projectRepository = projectRepository;
			_unitOfWork = unitOfWork;
		}

		#endregion

		#region Api

		[HttpGet]
		public ActionResult List()
		{
			List<TaskViewModel> tasks =
				_taskRepository.FetchAll().Select(Map).ToList();

			if (Request.IsAjaxRequest())
			{
				if (tasks.Any())
					return this.JsonRespose(tasks);
				else
					return this.JsonRespose("There is no departments yet.");
			}
			else
				return View(tasks);
		}

		[HttpPost]
		public ActionResult Add(TaskInputModel model)
		{
			if (ModelState.IsValid)
			{
				Task task = new Task()
				{
					Name = model.Name,
					Description = model.Description,
					Project = _projectRepository.Get(model.SelectedProject.Id),
					State = model.SelectedState.Id
				};

				_taskRepository.Add(task);
				_unitOfWork.Commit();

				return this.JsonRespose(Map(task), "You add new task.");
			}

			return this.JsonRespose("Please, enter correct task information.");
		}

		#endregion

		#region Mappers

		private static Func<Task, TaskViewModel> Map
		{
			get
			{
				return x => new TaskViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					State = TaskViewModel.TaskState[x.State],
					Description = x.Description ?? "No description",
					ProjectName = x.Project.Name
				};
			}
		}

		#endregion
	}
}