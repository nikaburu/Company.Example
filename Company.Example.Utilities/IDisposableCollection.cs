using System;
using System.Collections.Generic;

namespace Company.Example.Utilities
{
	public interface IDisposableCollection
	{
		ICollection<IDisposable> Disposables { get; }
	}
}