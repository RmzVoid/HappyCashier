using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using HappyCashier.Presenter.Views;

namespace HappyCashier.View.Forms
{
	public partial class LoginForm : Form, ILoginView
	{
		public LoginForm(ApplicationContext context)
		{
			_context = context;

			InitializeComponent();

			this.Shown += (sender, args) => Invoke(RecentAccountRequested);

			buttonCancel.Click += (sender, args) => this.Close();
			buttonLogin.Click += (sender, args) => Invoke(LoginRequested);
			accountNameInput.DropDown += (sender, args) => Invoke(AccountListRequested);
			accountNameInput.SelectedIndexChanged += (sender, args) => passwordInput.Focus();
		}

		public void ShowError(string message)
		{
			errorText.Text = message;
		}

		private void Invoke(Action action)
		{
			if (action != null) action();
		}

		public void ShowMe()
		{
			_context.MainForm = this;
			Application.Run(_context);
		}

		public void CloseMe()
		{
			Close();
		}

		public string AccountName
		{
			get { return accountNameInput.Text; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					accountNameInput.Text = string.Empty;
					accountNameInput.Focus();
				}
				else
				{
					accountNameInput.Text = value;
					passwordInput.Focus();
				}
			}
		}

		public string AccountPassword
		{
			get { return passwordInput.Text; }
		}

		public ISet<string> AccountList
		{
			get { return _accounts; }
			set
			{
				if (value == null || (_accounts != null && _accounts.SetEquals(value)))
					return;

				_accounts = value;

				string text = accountNameInput.Text;
				accountNameInput.Items.Clear();
				accountNameInput.Items.AddRange(value.ToArray());
				accountNameInput.SelectedItem = text;
			}
		}

		public event Action RecentAccountRequested;
		public event Action AccountListRequested;
		public event Action LoginRequested;

		private ApplicationContext _context;
		private ISet<string> _accounts;
	}
}
