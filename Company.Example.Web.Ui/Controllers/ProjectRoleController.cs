using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Extensions;
using Company.Example.Web.Ui.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	public class ProjectRoleController : DisposableBaseController
	{
		#region Dependencies

		private readonly IProjectRoleRepository _projectRoleRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ProjectRoleController(IProjectRoleRepository projectRoleRepository, IUnitOfWork unitOfWork, IDisposableCollection disposables)
			: base(disposables)
		{
			_projectRoleRepository = projectRoleRepository;
			_unitOfWork = unitOfWork;
		}

		#endregion

		#region Api

		[HttpGet]
		public ActionResult List()
		{
			List<ProjectRoleViewModel> projectRoles =
				_projectRoleRepository.FetchAll().Select(Map).ToList();

			if (Request.IsAjaxRequest())
			{
				if (projectRoles.Any())
					return this.JsonRespose(projectRoles);
				else
					return this.JsonRespose("There is no project roles yet.");
			}
			else
				return View(projectRoles);
		}

		[HttpPost]
		public ActionResult Add(string roleName)
		{
			if (ModelState.IsValid)
			{
				ProjectRole role = new ProjectRole() { Name = roleName };
				_projectRoleRepository.Add(role);
				_unitOfWork.Commit();

				return this.JsonRespose(Map(role), "You add new department.");
			}

			return this.JsonRespose("Please, enter correct role name.");
		}

		#endregion

		#region Mappers

		private static Func<ProjectRole, ProjectRoleViewModel> Map
		{
			get
			{
				return x => new ProjectRoleViewModel()
				   {
					   Id = x.Id,
					   Name = x.Name
				   };
			}
		}

		#endregion
	}
}