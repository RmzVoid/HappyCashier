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

			_view.RecentAccountRequested += () => getRecentAccount();
			_view.AccountListRequested += () => getAccountsList();
			_view.LoginRequested += () => login();
		}

		#region Internal logic

		private void getRecentAccount()
		{
			_view.AccountName = _model.GetRecentActive();
		}

		private void getAccountsList()
		{
			_view.AccountList = _model.GetAccountList();
		}

		private void login()
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

		#endregion

		#region Private fields

		private IAccountModel _model;

		#endregion
	}
}
