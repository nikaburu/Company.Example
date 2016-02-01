using Company.Example.Core;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui;
using Company.Example.Web.Ui.Controllers;
using Company.Example.Web.Ui.Models.InputModels;
using Company.Example.Web.Ui.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Company.Example.Tests.Unit.Web.Ui
{
	public class ProjectConrollerTests
	{

		public ProjectConrollerTests()
		{
			AutomapperConfig.RegisterMapping();
		}

		[Fact]
		public void ProjectList_WhenListOfProjects_ThenSomeListOfProjectsReturned()
		{
			//Assign
			Mock<IDisposableCollection> disposables = new Mock<IDisposableCollection>();
			Mock<IProjectRepository> mockedIProjectRepository = new Mock<IProjectRepository>();
			mockedIProjectRepository.Setup(x => x.FetchAll()).Returns(new List<Project>
				{
					new Project(),
					new Project(),
					new Project(),
					new Project(),
					new Project()
				});
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();

			ProjectController projectController = new ProjectController(mockedIProjectRepository.Object, mockedUoW.Object, disposables.Object);

			//Act
			ViewResult result = (ViewResult)projectController.List();

			//Assert
			Assert.Equal(5, ((List<ProjectViewModel>)result.Model).Count);
		}

		[Fact]
		public void AddNewProject_WhenValidInput_ThenSavesItInRepository()
		{
			//Assign
			Mock<IDisposableCollection> disposables = new Mock<IDisposableCollection>();
			Mock<IProjectRepository> mockedIProjectRepository = new Mock<IProjectRepository>();
			mockedIProjectRepository.Setup(x => x.Add(It.Is<Project>(_ => true)));
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();
			mockedUoW.Setup(uow => uow.Commit());

			ProjectInputModel input = new ProjectInputModel();
			ProjectController projectController = new ProjectController(mockedIProjectRepository.Object, mockedUoW.Object, disposables.Object);

			//Act
			ActionResult result = projectController.Add(input);

			//Assert
			Assert.NotNull(result);
			mockedIProjectRepository.VerifyAll();
		}

		[Fact]
		public void AddNewProject_WhenInputIsNull_ThenReturnsSuccessFalse()
		{
			//Assign
			Mock<IDisposableCollection> disposables = new Mock<IDisposableCollection>();
			Mock<IProjectRepository> mockedIProjectRepository = new Mock<IProjectRepository>();
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();

			ProjectController projectController = new ProjectController(mockedIProjectRepository.Object, mockedUoW.Object, disposables.Object);

			//Act
			ActionResult result = projectController.Add(null);

			//Assert
			Assert.NotNull(result);
			bool success = (bool)((JsonResult)result).Data.GetType().GetProperty("success").GetValue(((JsonResult)result).Data);
			Assert.True(success == false);
		}

		[Fact]
		public void JSONGetProjectById_WhenCalled_ThenUsesId226()
		{
			//Assign
			Mock<IDisposableCollection> disposables = new Mock<IDisposableCollection>();
			Project project = new Project() { Id = 226 };
			project.Employees.Add(new ProjectToEmployee() { EmploeeRoleOnProject = new ProjectRole() { Id = 4 }, Employee = new Employee() { LastName = "John" } });
			Mock<IProjectRepository> mockedIProjectRepository = new Mock<IProjectRepository>();
			mockedIProjectRepository.Setup(repository => repository.Get(It.Is<int>(i => i == project.Id))).Returns(project);
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();

			ProjectController projectController = new ProjectController(mockedIProjectRepository.Object, mockedUoW.Object, disposables.Object);

			//Act
			ActionResult result = projectController.Get(project.Id);

			//Assert
			Assert.NotNull(result);
			mockedIProjectRepository.VerifyAll();
		}

		[Fact]
		public void JSONGetProjectById_When226NotExists_ThenReturnSuccessIsFalse()
		{
			//Assign
			Mock<IDisposableCollection> disposables = new Mock<IDisposableCollection>();
			Mock<IProjectRepository> mockedIProjectRepository = new Mock<IProjectRepository>();
			Mock<IUnitOfWork> mockedUoW = new Mock<IUnitOfWork>();

			ProjectController projectController = new ProjectController(mockedIProjectRepository.Object, mockedUoW.Object, disposables.Object);

			//Act
			ActionResult result = projectController.Get(100);

			//Assert
			Assert.NotNull(result);
			bool success = (bool)((JsonResult)result).Data.GetType().GetProperty("success").GetValue(((JsonResult)result).Data);
			Assert.True(success == false);
		}
	}
}