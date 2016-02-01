using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Controllers;
using Company.Example.Web.Ui.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace Company.Example.Tests.Unit.Web.Ui
{
	public class TestGetAllUsers
	{
		[Fact]
		public void GetUsers_WhenListAllUsers_ThenSomeUsersReturned()
		{
			//Assign
			Mock<IUserRepository> mocked = new Mock<IUserRepository>();
			mocked.Setup(x => x.FetchAll()).Returns(
				new List<User>
					{
						new User(),
						new User(),
						new User(),
						new User(),
						new User()
					}
				);
			Mock<IDisposableCollection> mockedDisposables = new Mock<IDisposableCollection>();

			UserController userController = new UserController(mocked.Object, mockedDisposables.Object);			

			//Act
			ViewResult result = (ViewResult)userController.List();

			//Assert
			Assert.Equal(5, ((List<UserViewModel>)result.Model).Count);
		}
	}
}