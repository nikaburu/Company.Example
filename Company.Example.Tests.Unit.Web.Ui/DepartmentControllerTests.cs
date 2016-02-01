using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui;
using Company.Example.Web.Ui.Controllers;
using Company.Example.Web.Ui.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Company.Example.Tests.Unit.Web.Ui
{
	public class DepartmentConrollerTests
	{

		public DepartmentConrollerTests()
		{
			AutomapperConfig.RegisterMapping();
		}

		[Fact]
		public void DepartmentList_WhenListOfDepartments_ThenSomeListOfDepartmentsReturned()
		{
			//Assign
			Mock<IDepartmentRepository> mockedIDepartmentRepository = new Mock<IDepartmentRepository>();
			mockedIDepartmentRepository.Setup(x => x.FetchAll()).Returns(new List<Department>
				{
					new Department(),
					new Department(),
					new Department(),
					new Department(),
					new Department()
				});
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();
			Mock<IDisposableCollection> mockedDisposables = new Mock<IDisposableCollection>();

			DepartmentController DepartmentController = new DepartmentController(mockedIDepartmentRepository.Object, mockedUoW.Object, mockedDisposables.Object);

			//Act
			ViewResult result = (ViewResult)DepartmentController.List();

			//Assert
			Assert.Equal(5, ((List<DepartmentViewModel>)result.Model).Count);
		}
	}
}