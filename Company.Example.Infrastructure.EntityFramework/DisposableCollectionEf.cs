using Company.Example.Utilities;
using System;
using System.Collections.Generic;

namespace Company.Example.Infrastructure.EntityFramework
{
	public class DisposableCollectionEf : IDisposableCollection
	{
		private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public DisposableCollectionEf(ExampleDatabaseContext efUnitOfWork)
		{
			_disposables.Add(efUnitOfWork);
		}

		public ICollection<IDisposable> Disposables
		{
			get { return _disposables; }
		}
	}
}