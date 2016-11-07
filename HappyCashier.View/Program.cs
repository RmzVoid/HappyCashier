using System;
using System.Windows.Forms;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataSources;
using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Presenter.Views;
using HappyCashier.View.Forms;

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

			IApplicationController controller = new ApplicationController()
				.RegisterType<DatabaseContext, SampleDatabaseContext>()
				.RegisterType<IAccountDataSource, DatabaseAccountDataSource>()
				.RegisterType<ISaleDataSource, DatabaseSaleDataSource>()
				.RegisterType<IAccountModel, AccountModel>()
				.RegisterType<ISaleModel, SaleModel>()
				.RegisterType<ILoginView, LoginForm>()
				.RegisterType<ISaleView, SaleForm>()
				.RegisterInstance<ApplicationContext>(new ApplicationContext());

			controller.Run<LoginPresenter>();
		}
	}
}
