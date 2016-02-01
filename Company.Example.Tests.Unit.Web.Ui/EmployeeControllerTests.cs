using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Controllers;
using Company.Example.Web.Ui.Models.InputModels;
using Company.Example.Web.Ui.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Company.Example.Tests.Unit.Web.Ui
{
	public class EmployeeControllerTests
	{

		[Fact]
		public void EmployeeList_WhenListOfEmployees_ThenSomeListOfEmployeesReturned()
		{
			//Assign
			Mock<IEmployeeRepository> mockedIEmployeeRepository = new Mock<IEmployeeRepository>();
			mockedIEmployeeRepository.Setup(x => x.FetchAll()).Returns(new List<Employee>
				{
					new Employee(),
					new Employee(),
					new Employee(),
					new Employee(),
					new Employee()
				});
			Mock<IDepartmentRepository> mockedIDepartmentRepository = new Mock<IDepartmentRepository>();
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();
			Mock<IDisposableCollection> mockedDisposables = new Mock<IDisposableCollection>();

			mockedIDepartmentRepository.Setup(x => x.Get(1)).Returns(new Department());

			EmployeeController EmployeeController = new EmployeeController(mockedIEmployeeRepository.Object, mockedIDepartmentRepository.Object, mockedUoW.Object, mockedDisposables.Object);

			//Act
			ViewResult result = (ViewResult)EmployeeController.List();

			//Assert
			Assert.Equal(5, ((List<EmployeeViewModel>)result.Model).Count);
		}

		[Fact]
		public void AddNewEmployee_WhenInputIsNull_ThenReturnsSuccessFalse()
		{
			//Assign
			Mock<IEmployeeRepository> mockedIEmployeeRepository = new Mock<IEmployeeRepository>();
			Mock<IDepartmentRepository> mockedIDepartmentRepository = new Mock<IDepartmentRepository>();
			mockedIEmployeeRepository.Setup(x => x.Add(It.Is<Employee>(y => true)));
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();
			Mock<IDisposableCollection> mockedDisposables = new Mock<IDisposableCollection>();

			EmployeeController EmployeeController = new EmployeeController(mockedIEmployeeRepository.Object, mockedIDepartmentRepository.Object, mockedUoW.Object, mockedDisposables.Object);

			//Act
			var result = EmployeeController.Add(new EmployeeInputModel());

			//Assert
			Assert.NotNull(result);
			bool success = (bool)((JsonResult)result).Data.GetType().GetProperty("success").GetValue(((JsonResult)result).Data);
			Assert.True(success == false);
		}
	}
}