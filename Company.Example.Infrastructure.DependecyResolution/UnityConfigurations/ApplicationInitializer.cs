using Microsoft.Practices.Unity;

namespace Company.Example.Infrastructure.DependecyResolution.UnityConfigurations
{
    internal class ApplicationInitializer : UnityContainerExtension
    {
        #region Overrides of UnityContainerExtension

        protected override void Initialize()
        {
            //Container.RegisterType<ProductPrensenter>(
            //new ContainerControlledLifetimeManager(),
            //new InjectionFactory(c => new ProductPresenter(c.Resolve<IProductView>())));
        }

        #endregion
    }
}