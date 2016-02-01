using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Infrastructure
{
	public class UnityDependencyResolver : IDependencyResolver
	{
		private readonly IUnityContainer _container;

		public UnityDependencyResolver(IUnityContainer container)
		{
			_container = container;
		}

		#region Implementation of IDependencyResolver

		/// <summary>
		/// Resolves singly registered services that support arbitrary object creation.
		/// </summary>
		/// <returns>
		/// The requested service or object.
		/// </returns>
		/// <param name="serviceType">The type of the requested service or object.</param>
		public object GetService(Type serviceType)
		{
			if (serviceType.IsSubclassOf(typeof(Controller)))
			{
				return _container.Resolve(serviceType);
			}

			return null;
		}

		/// <summary>
		/// Resolves multiply registered services.
		/// </summary>
		/// <returns>
		/// The requested services.
		/// </returns>
		/// <param name="serviceType">The type of the requested services.</param>
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return new List<object>();
		}

		#endregion
	}
}