using System;
using System.Collections.Generic;

namespace HappyCashier.Presenter.Views
{
	public interface ILoginView : IView
	{
		string AccountName { get; set; }
		string AccountPassword { get; }
		IEnumerable<string> AccountList { get; set; }

		void ShowError(string message);

		event Action RecentAccountRequested;
		event Action AccountListRequested;
		event Action LoginRequested;
	}
}
