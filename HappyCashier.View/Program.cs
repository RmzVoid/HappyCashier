using System;
using System.Windows.Forms;

using HappyCashier.View.Forms;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Domain.Models;
using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataSources;

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

			AccountModel model = new AccountModel(new DatabaseAccountDataSource(new DatabaseContext()));
			LoginPresenter presenter = new LoginPresenter(new LoginForm(), model);

			presenter.Run();
		}
	}
}
