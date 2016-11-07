﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Practices.Unity;

using HappyCashier.Presenter;
using HappyCashier.Presenter.Views;

namespace HappyCashier.View.Forms
{
	public partial class LoginForm : Form, ILoginView
	{
		public LoginForm(IUnityContainer container, ApplicationContext context)
		{
			_container = container;
			_context = context;

			InitializeComponent();

			this.Shown += (sender, args) => Invoke(RecentAccountRequested);

			buttonCancel.Click += (sender, args) => this.Close();
			buttonLogin.Click += (sender, args) => Invoke(LoginRequested);
			accountNameInput.DropDown += (sender, args) => Invoke(AccountListRequested);
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
			set { accountNameInput.Text = value; }
		}

		public string AccountPassword
		{
			get { return passwordInput.Text; }
		}

		public IEnumerable<string> AccountList
		{
			get { return accountNameInput.Items.Cast<string>(); }
			set 
			{
				if(value == null)
					return;

				string text = accountNameInput.Text;
				accountNameInput.Items.Clear();
				accountNameInput.Items.AddRange(value.ToArray());
				accountNameInput.SelectedItem = text;
			}
		}

		public event Action RecentAccountRequested;
		public event Action AccountListRequested;
		public event Action LoginRequested;

		private IUnityContainer _container;
		private ApplicationContext _context;
	}
}
