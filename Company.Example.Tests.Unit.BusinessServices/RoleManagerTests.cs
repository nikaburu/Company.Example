using Company.Example.BusinesServices;
using Company.Example.CrossCutting;
using Xunit;

namespace Company.Example.Tests.Unit.BusinessServices
{
	public class RoleManagerTests
	{
		[Fact]
		public void GlobalActionAllowed_WhenUserNameNull_ThenFalse()
		{
			var roleManager = new TestRoleManager(null);
			string userName = null;
			var expected = false;
			
			var actual = roleManager.IsGlobalActionAllowed(userName, GlobalActionType.ViewProjects);
			
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GlobalActionAllowed_WhenUserNameEmpty_ThenFalse()
		{
			var roleManager = new TestRoleManager(null);
			string userName = string.Empty;
			var expected = false;
			
			var actual = roleManager.IsGlobalActionAllowed(userName, GlobalActionType.ViewProjects);
			
			Assert.Equal(expected, actual);
		}
	}
}