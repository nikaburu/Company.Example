using Company.Example.CrossCutting;
using Microsoft.Practices.ServiceLocation;

namespace Company.Example.Infrastructure.DependecyResolution.CrossCutting
{
	public static class UserInfo
	{
		public static IUserInfo Current
		{
			get
			{
				var result = ServiceLocator.Current.GetInstance<IUserInfo>();
				return result;
			}
		}
	}
}