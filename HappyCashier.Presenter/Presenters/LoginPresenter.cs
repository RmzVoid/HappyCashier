using System;

using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.DataTransferObjects;
using HappyCashier.Presenter.Views;

using AccountModel = HappyCashier.Domain.Entities.Account;

namespace HappyCashier.Presenter.Presenters
{
	public class LoginPresenter : BasePresenter<ILoginView>
	{
		public LoginPresenter(IApplicationController controller, ILoginView view, IAccountModel model)
			: base(controller, view)
		{
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
			AccountModel account = _model.GetAccount(_view.AccountName, _view.AccountPassword);

			if (account != null)
			{
				account.LastActivity = DateTime.Now;
				_model.UpdateAccountInfo(account);

				_controller.Run<SalePresenter, Account>(new Account() 
				{ 
					Id = account.Id, 
					Name = account.Name 
				});

				_view.CloseMe();
			}
			else
				_view.ShowError("Вход неуспешен");
		}

		private IAccountModel _model;
	}
}
