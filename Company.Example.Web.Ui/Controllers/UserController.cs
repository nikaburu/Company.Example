using Company.Example.Core.Domain.Entities;
using Company.Example.Core.Domain.Repositories;
using Company.Example.Utilities;
using Company.Example.Web.Ui.Extensions;
using Company.Example.Web.Ui.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Company.Example.Web.Ui.Controllers
{
	public class UserController : DisposableBaseController
	{
		#region Dependencies

		private IUserRepository _userRepository;

		public UserController(IUserRepository userRepository, IDisposableCollection disposables)
			: base(disposables)
		{
			_userRepository = userRepository;
		}

		#endregion

		#region Api

		[HttpGet]
		public ActionResult List()
		{
			List<UserViewModel> users =
				_userRepository.FetchAll().Select(Map).ToList();

			if (Request.IsAjaxRequest())
			{
				if (users.Any())
					return this.JsonRespose(users);
				else
					return this.JsonRespose("There is no users yet.");
			}
			else
				return View(users);
		}

		#endregion

		#region Mappers

		private static Func<User, UserViewModel> Map
		{
			get
			{
				return x => new UserViewModel()
				{
					Id = x.Id,
					DomainLogin = x.Login,
				};
			}
		}

		#endregion
	}
}