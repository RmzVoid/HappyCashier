using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Views;

namespace HappyCashier.Presenter.Presenters
{
	public class LoginPresenter : IPresenter
	{
		public LoginPresenter(ILoginView view, IAccountModel model)
		{
			_view = view;
			_model = model;

			_view.RecentAccountRequested += () => GetRecentAccount();
			_view.AccountListRequested += () => GetAccountsList();
			_view.LoginRequested += () => Login();
		}

		private void GetRecentAccount()
		{
			_view.AccountName = _model.GetRecentActive();
		}

		private void GetAccountsList()
		{
			_view.AccountList = _model.GetAccountList();
		}

		private void Login()
		{
			if (_model.Login(_view.AccountName, _view.AccountPassword))
				_view.ShowError("Вход успешно выполнен");
			else
				_view.ShowError("Вход неуспешен");
		}

		public void Run()
		{
			_view.ShowMe();
		}

		private ILoginView _view;
		private IAccountModel _model;
	}
}
