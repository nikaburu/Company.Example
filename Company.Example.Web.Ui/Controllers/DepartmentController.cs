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
	public class DepartmentController : DisposableBaseController
	{
		#region Dependencies

		private readonly IDepartmentRepository _departmentRepository;
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentController(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IDisposableCollection disposables)
			: base(disposables)
		{
			_departmentRepository = departmentRepository;
			_unitOfWork = unitOfWork;
		}

		#endregion

		#region Api

		[HttpGet]
		public ActionResult List()
		{
			List<DepartmentViewModel> departments =
				_departmentRepository.FetchAll().Select(Map).ToList();

			if (Request.IsAjaxRequest())
			{
				if (departments.Any())
					return this.JsonRespose(departments);
				else
					return this.JsonRespose("There is no departments yet.");
			}
			else
				return View(departments);
		}

		[HttpPost]
		public ActionResult Add(string departmentName)
		{
			if (ModelState.IsValid)
			{
				Department department = new Department() { Name = departmentName };
				_departmentRepository.Add(department);
				_unitOfWork.Commit();

				return this.JsonRespose(Map(department), "You add new department.");
			}

			return this.JsonRespose("Please, enter correct department name.");
		}

		#endregion

		#region Mappers

		private static Func<Department, DepartmentViewModel> Map
		{
			get
			{
				return x => new DepartmentViewModel()
				{
					Id = x.Id,
					Name = x.Name
				};
			}
		}

		#endregion
	}
}