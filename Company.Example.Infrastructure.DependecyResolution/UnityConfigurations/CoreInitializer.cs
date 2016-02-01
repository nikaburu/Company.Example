using Company.Example.Core;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Infrastructure.EntityFramework;
using Company.Example.Infrastructure.EntityFramework.Repositories;
using Company.Example.Infrastructure.EntityFramework.UnitOfWorkAware;
using Company.Example.Utilities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Company.Example.Infrastructure.DependecyResolution.UnityConfigurations
{
    internal class CoreInitializer : UnityContainerExtension
    {
        #region Overrides of UnityContainerExtension

        protected override void Initialize()
        {
			Container.RegisterType<ExampleDatabaseContext, ExampleDatabaseContext>(new HttpContextLifetimeManager<ExampleDatabaseContext>());
			// register UnitOfWork
			Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerResolveLifetimeManager());

            IEnumerable<Type> reposInterfaces =
                Assembly.GetAssembly(typeof(IRepository<>)).GetExportedTypes().Where(
                    rec => rec.GetInterface("IRepository`1") != null && rec.IsInterface && !rec.IsGenericType);

            IEnumerable<Type> reposImplementation = Assembly.GetAssembly(typeof(RepositoryBase<>)).GetExportedTypes().Where(
                    rec => rec.BaseType != null && rec.BaseType.Name == typeof(RepositoryBase<>).Name && rec.IsClass).ToList();

            foreach (Type intrface in reposInterfaces)
            {
                Type type = reposImplementation.FirstOrDefault(rec => rec.GetInterface(intrface.Name) != null);
                if (type != null) Container.RegisterType(intrface, type);
            }

	        Container.RegisterType<IDisposableCollection, DisposableCollectionEf>();
	        //Container.RegisterType<IUserInfo, HttpUserInfo>(new ContainerControlledLifetimeManager());
        }

        #endregion
    }
}