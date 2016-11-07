using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Views;
using Microsoft.Practices.Unity;

using AccountEntity = HappyCashier.Domain.Entities.Account;

namespace HappyCashier.Presenter.Presenters
{
	public class LoginPresenter : IPresenter
	{
		public LoginPresenter(IUnityContainer container, ILoginView view, IAccountModel model)
		{
			_view = view;
			_model = model;
			_container = container;

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
			AccountEntity account = _model.GetAccount(_view.AccountName, _view.AccountPassword);

			if (account != null)
			{
				SalePresenter salePresenter = new SalePresenter(
					_container.Resolve<ISaleView>(new ParameterOverride("account", new Account() { Id = account.Id, Name = account.Name })),
					_container.Resolve<ISaleModel>());

				salePresenter.Run();

				_view.CloseMe();
			}
			else
				_view.ShowError("Вход неуспешен");
		}

		public void Run()
		{
			_view.ShowMe();
		}

		private ILoginView _view;
		private IAccountModel _model;
		private IUnityContainer _container;
	}
}
