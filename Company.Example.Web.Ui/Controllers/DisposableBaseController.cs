using Company.Example.Utilities;
using System;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	public abstract class DisposableBaseController : Controller
	{
		private readonly IDisposableCollection _disposableCollection;

		protected DisposableBaseController(IDisposableCollection disposables)
		{
			_disposableCollection = disposables;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (IDisposable disposable in _disposableCollection.Disposables)
				{
					disposable.Dispose();
				}
			}
			base.Dispose(disposing);
		}
	}
}