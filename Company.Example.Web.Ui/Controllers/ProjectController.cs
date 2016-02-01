using AutoMapper;
using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.CrossCutting;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Extensions;
using Company.Example.Web.Ui.Filters;
using Company.Example.Web.Ui.Models.InputModels;
using Company.Example.Web.Ui.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	public class ProjectController : DisposableBaseController
	{
		#region Dependencies

		private readonly IProjectRepository _projectRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ProjectController(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IDisposableCollection disposables)
			: base(disposables)
		{
			_projectRepository = projectRepository;
			_unitOfWork = unitOfWork;
		}
		
		#endregion

		#region Api

		[GlobalActionAuthorization(GlobalActionType.ViewProjects)]
		[HttpGet]
		public ActionResult List()
		{
			List<ProjectViewModel> projects = Mapper.Map<List<ProjectViewModel>>(_projectRepository.FetchAll());

			if (Request.IsAjaxRequest())
			{
				if (projects.Any())
					return this.JsonRespose(projects);
				else
					return this.JsonRespose("There is no projects yet.");
			}
			else
				return View(projects);
		}

		[HttpGet]
		public ActionResult Get(int id)
		{
			Project project = _projectRepository.Get(id);

			if (project != null)
			{
				ProjectInputModel model = Mapper.Map<ProjectInputModel>(project);
				model.Manager = project.Employees.Single(x => x.EmploeeRoleOnProject.Id == 4).Employee.LastName;

				return this.JsonRespose(model);
			}
			else
				return this.JsonRespose("Project was not found.");
		}

		[GlobalActionAuthorization(GlobalActionType.ModifyProjects)]
		[HttpPost]
		public ActionResult Add(ProjectInputModel model)
		{ 
			if (ModelState.IsValid)
			{
				Project project = Mapper.Map<Project>(model);
				_projectRepository.Add(project);
				_unitOfWork.Commit();

				return this.JsonRespose(Mapper.Map<ProjectViewModel>(project), "You add new project.");
			}

			return this.JsonRespose("Please, enter correct project information.");
		}

		#endregion
	}
}