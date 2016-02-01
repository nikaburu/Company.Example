using Company.Example.CrossCutting;
using Microsoft.Practices.ServiceLocation;

namespace Company.Example.Infrastructure.DependecyResolution.CrossCutting
{
    public static class RoleManager
	{
        public static IRoleManager Current
		{
			get
			{
                var result = ServiceLocator.Current.GetInstance<IRoleManager>();
				return result;
			}
		}
	}
}