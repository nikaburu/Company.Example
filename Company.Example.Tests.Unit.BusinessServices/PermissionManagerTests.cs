using Company.Example.BusinesServices;
using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.CrossCutting;
using Company.Example.Infrastructure.EntityFramework.RoleManager;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Company.Example.Tests.Unit.BusinessServices
{
	public class PermissionManagerTests
	{
		#region constructor

		private readonly IEmployeeRepository _employeeRepository;

		public PermissionManagerTests()
		{
			var moqEmployeeRepository = new Mock<IEmployeeRepository>();
			moqEmployeeRepository
				.Setup(r => r.FetchAll())
				.Returns(new List<Employee>());

			_employeeRepository = moqEmployeeRepository.Object;
		} 

		#endregion constructor

		#region Global permissions

		#region GetGlobalPermissions

		[Fact]
		public void GetGlobalPermissions_WhenUserNameNull_ThenEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			string userName = null;

			var actual = permissionManager.GetGlobalPermissions(userName);

			Assert.NotNull(actual);
			Assert.Equal(0, actual.Count);
		}

		[Fact]
		public void GetGlobalPermissions_WhenUserNameEmpty_ThenEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			string userName = string.Empty;

			var actual = permissionManager.GetGlobalPermissions(userName);

			Assert.NotNull(actual);
			Assert.Equal(0, actual.Count);
		}

		#endregion GetGlobalPermissions

		#region GetDefaultGlobalPermissions

		[Fact]
		public void GetDefaultGlobalPermissions_ReturnsNonEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var expectedCount = Enum.GetNames(typeof(GlobalActionType)).Length;

			var actual = permissionManager.GetDefaultGlobalPermissions();

			Assert.NotNull(actual);
			Assert.Equal(expectedCount, actual.Count);
		}

		#endregion GetDefaultGlobalPermissions

		#endregion Global permissions

		#region Project permissions

		#region GetProjectPermissions

		[Fact]
		public void GetProjectPermissions_WhenUserNameNull_ThenEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			string userName = null;

			var actual = permissionManager.GetProjectPermissions(userName, 1);

			Assert.NotNull(actual);
			Assert.Equal(0, actual.Count);
		}

		[Fact]
		public void GetProjectPermissions_WhenUserNameEmpty_ThenEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			string userName = null;

			var actual = permissionManager.GetProjectPermissions(userName, 1);

			Assert.NotNull(actual);
			Assert.Equal(0, actual.Count);
		}

		#endregion GetProjectPermissions

		#region GetDefaultProjectPermissions

		[Fact]
		public void GetDefaultProjectPermissions_ReturnsNonEmptySet()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var expectedCount = Enum.GetNames(typeof (ProjectActionType)).Length;

			foreach (var item in Enum.GetValues(typeof(EmployeeRole)))
			{
				var actual = permissionManager.GetDefaultProjectPermissions((EmployeeRole)item);

				Assert.NotNull(actual);
				Assert.Equal(expectedCount, actual.Count);
			}
		}

		#endregion GetProjectPermissions

		#endregion Project permissions

		#region GetEmployeeRoleFromId

		[Fact]
		public void GetEmployeeRoleFromId_WhenInvalidId_Smaller_ThenThrowsException()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var id = 0;

			Assert.Throws<ArgumentException>(() =>
			{
				permissionManager.GetEmployeeRoleFromId(id);
			});
		}

		[Fact]
		public void GetEmployeeRoleFromId_WhenInvalidId_Bigger_ThenThrowsException()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var id = Enum.GetNames(typeof (EmployeeRole)).Length + 1;

			Assert.Throws<ArgumentException>(() =>
				{
					permissionManager.GetEmployeeRoleFromId(id);
				});
		}

		[Fact]
		public void GetEmployeeRoleFromId_WhenCorrectId_ThenCorrectEnum()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var expected = EmployeeRole.Developer;
			var id = (int)expected;
			var actual = permissionManager.GetEmployeeRoleFromId(id);

			Assert.Equal(expected, actual);
		}

		#endregion GetEmployeeRoleFromId

		#region GetEmployeeRoleFromString

		[Fact]
		public void GetEmployeeRoleFromString_WhenStringNull_ThenThrowsException()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			string name = null;

			Assert.Throws<ArgumentException>(() =>
			{
				permissionManager.GetEmployeeRoleFromString(name);
			});
		}

		[Fact]
		public void GetEmployeeRoleFromString_WhenStringEmpty_ThenThrowsException()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var name = string.Empty;

			Assert.Throws<ArgumentException>(() =>
			{
				permissionManager.GetEmployeeRoleFromString(name);
			});
		}

		[Fact]
		public void GetEmployeeRoleFromString_WhenIncorrectName_ThenThrowsException()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var name = "Hello";

			Assert.Throws<ArgumentException>(() =>
			{
				permissionManager.GetEmployeeRoleFromString(name);
			});
		}

		[Fact]
		public void GetEmployeeRoleFromId_WhenCorrectName_ThenReturnsCorrectEnum()
		{
			var permissionManager = new DbPermissionManager(_employeeRepository);
			var expected = EmployeeRole.Developer;
			var name = EmployeeRole.Developer.ToString();

			var actual = permissionManager.GetEmployeeRoleFromString(name);

			Assert.Equal(expected, actual);
		}

		#endregion GetEmployeeRoleFromString
	}
}
