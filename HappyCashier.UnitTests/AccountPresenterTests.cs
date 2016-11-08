using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NSubstitute;
using NUnit.Framework;
using Microsoft.Practices.Unity;

using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Views;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Domain.Entities;
using HappyCashier.View.Forms;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataSources;
using HappyCashier.Presenter.Common;

using AccountEntity = HappyCashier.Domain.Entities.Account;
using AccountObject = HappyCashier.Presenter.DataTransferObjects.Account;

namespace HappyCashier.Test
{
	[TestFixture]
	public class AccountPresenterTests
	{
		[SetUp]
		public void SetUp()
		{
			_view = Substitute.For<ILoginView>();
			_model = Substitute.For<IAccountModel>();
			_controller = Substitute.For<IApplicationController>();

			_model.GetAccount(Arg.Any<string>(), Arg.Any<string>())
				.Returns(arg => 
					(string)arg[0] == "Даша" && (string)arg[1] == "11111" ? 
					new AccountEntity() { Id = 1, Name = "Даша", Password = "11111" } : null);

			_model.GetAccountList()
				.ReturnsForAnyArgs(x => new HashSet<string>() { "Даша", "Паша", "Володя" });

			_model.GetRecentActive()
				.ReturnsForAnyArgs(x => "Володя");

			var presenter = new LoginPresenter(_controller, _view, _model);
			presenter.Run();
		}

		[Test]
		public void AccountPresenter_LogonUnsuccessful()
		{
			_view.AccountName.Returns("Володя");
			_view.AccountPassword.Returns("617933");
			_view.LoginRequested += Raise.Event<Action>();
			_view.Received().ShowError(Arg.Any<string>());
		}

		[Test]
		public void AccountPresenter_LogonSuccessful()
		{
			_view.AccountName.Returns("Даша");
			_view.AccountPassword.Returns("11111");

			_view.LoginRequested += Raise.Event<Action>();

			_controller.Received().Run<SalePresenter, AccountObject>(Arg.Any<AccountObject>());

			_view.DidNotReceive().ShowError(Arg.Any<string>());
		}

		[Test]
		public void AccountPresenter_GetAccountList()
		{
			_view.AccountListRequested += Raise.Event<Action>();
			CollectionAssert.AreEqual(new List<string>() { "Даша", "Паша", "Володя" }, _view.AccountList);
		}

		[Test]
		public void AccountPresenter_GetRecentActive()
		{
			_view.RecentAccountRequested += Raise.Event<Action>();
			Assert.AreEqual("Володя", _view.AccountName);
		}

		private ILoginView _view;
		private IAccountModel _model;
		private IApplicationController _controller;
	}
}
