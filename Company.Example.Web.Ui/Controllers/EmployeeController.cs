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
	public class EmployeeController : DisposableBaseController
	{
		#region Dependencies

		private readonly IEmployeeRepository _employeeRepository;
		private readonly IDepartmentRepository _departmentRepository;
		private readonly IUnitOfWork _unitOfWork;

		public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork,
			IDisposableCollection disposables)
			: base(disposables)
		{
			_employeeRepository = employeeRepository;
			_departmentRepository = departmentRepository;
			_unitOfWork = unitOfWork;
		}

		#endregion

		#region Api

		[HttpGet]
		public ActionResult List()
		{
			List<EmployeeViewModel> employees =
				_employeeRepository.FetchAll().Select(Map).ToList();

			if (Request.IsAjaxRequest())
			{
				if (employees.Any())
					return this.JsonRespose(employees);
				else
					return this.JsonRespose("There is no employees yet.");
			}
			else
				return View(employees);
		}

		[HttpPost]
		public ActionResult Add(EmployeeInputModel model)
		{
			if (ModelState.IsValid)
			{
				Employee employee = new Employee()
				{
					FirstName = model.Name,
					LastName = model.Surname,
					Login = model.Login,
					Department = model.SelectedDepartment != null ? _departmentRepository.Get(model.SelectedDepartment.Id) : null,
					IsActive = model.IsActive,
					IsAllowedToLogin = model.IsAllowedToLogin
				};

				_employeeRepository.Add(employee);
				_unitOfWork.Commit();

				return this.JsonRespose(Map(employee), "You add new employee.");
			}

			return this.JsonRespose("Please, enter correct employee information.");
		}

		#endregion

		#region Mappers

		private static Func<Employee, EmployeeViewModel> Map
		{
			get
			{
				return x => new EmployeeViewModel()
				{
					Id = x.Id,
					Name = x.FirstName,
					Surname = x.LastName,
					Login = x.Login,
					LastLoginDate = x.LastLoginDate != null ? x.LastLoginDate.Value.Date.ToString() : "Never",
					Department = x.Department != null ? x.Department.Name : "Has no Department assigned.",
					IsAllowedToLogin = x.IsAllowedToLogin ? "Yes" : "No",
					IsActive = x.IsActive ? "Yes" : "No"
				};
			}
		}

		#endregion
	}
}