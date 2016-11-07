using System;
using System.Windows.Forms;

using Microsoft.Practices.Unity;

using HappyCashier.View.Forms;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Domain.Models;
using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataSources;
using HappyCashier.View.Dialogs;
using HappyCashier.Presenter.Views;
using HappyCashier.Presenter;

namespace HappyCashier.View
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			UnityContainer uc = new UnityContainer();

			uc.RegisterType<DatabaseContext, SampleDatabaseContext>();
			uc.RegisterType<IAccountDataSource, DatabaseAccountDataSource>();
			uc.RegisterType<ISaleDataSource, DatabaseSaleDataSource>();
			uc.RegisterType<IAccountModel, AccountModel>();
			uc.RegisterType<ISaleModel, SaleModel>();
			uc.RegisterType<ILoginView, LoginForm>();
			uc.RegisterType<ISaleView, MainForm>();
			uc.RegisterInstance<ApplicationContext>(new ApplicationContext());

			LoginPresenter loginPresenter = new LoginPresenter(uc, uc.Resolve<ILoginView>(), uc.Resolve<IAccountModel>());

			loginPresenter.Run();
		}
	}
}
