using Company.Example.BusinesServices;
using Company.Example.CrossCutting;
using Company.Example.Infrastructure.EntityFramework.RoleManager;
using Microsoft.Practices.Unity;

namespace Company.Example.Infrastructure.DependecyResolution.UnityConfigurations
{
    internal class ServicesInitializer : UnityContainerExtension
    {
        #region Overrides of UnityContainerExtension

        protected override void Initialize()
        {
			Container.RegisterType<IPermissionManager, TestPermissionManager>();
			//Container.RegisterType<IPermissionManager, DbPermissionManager>();
			Container.RegisterType<IRoleManager, TestRoleManager>(new HttpContextLifetimeManager<IRoleManager>());
        }

        #endregion
    }
}