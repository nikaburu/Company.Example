using Company.Example.Infrastructure.DependecyResolution.UnityConfigurations;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Company.Example.Infrastructure.DependecyResolution
{
    public static class CompositionRoot
    {
        public static IUnityContainer Compose()
        {
            var container = new UnityContainer()
                .AddNewExtension<ApplicationInitializer>()
                .AddNewExtension<CoreInitializer>()
				.AddNewExtension<ServicesInitializer>();
			
			UnityServiceLocator locator = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => locator);
            return container;
        }
    }
}