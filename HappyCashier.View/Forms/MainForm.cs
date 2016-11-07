using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Presenter;
using HappyCashier.Presenter.Views;
using HappyCashier.View.Dialogs;
using Microsoft.Practices.Unity;

namespace HappyCashier.View.Forms
{
	public partial class MainForm : Form, ISaleView
	{
		public Document Document
		{
			get { return _document; }
			set { _document = value; }
		}
		
		public Account Account
		{ 
			get { return _account; } 
			set { _account = value; accountNameLabel.Text = value.Name; }
		}

		public int SaleId { get; set; }
		public string GoodNameRequested { get { return inputTextBox.Text; } }

		public event Action OpenSaleRequested;
		public event Action CloseSaleRequested;
		public event Action GoodInfoRequested;

		public MainForm(IUnityContainer container, ApplicationContext context, Account account)
		{
			_container = container;
			_context = context;

			InitializeComponent();

			// can't set up aligment of particular columns in designer
			saleItemAmountColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemAmountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemTotalColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemTotalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			Account = account;
		}

		public void GoodInfoReturned(GoodDto good)
		{
			GetDecimalDialog dialog = new GetDecimalDialog("Кол-во: ", 1);
			decimal? amount = dialog.RequestUserValue();

			if (amount.HasValue)
			{
				// here we able to check if good already present in datagrid and modify row
				saleItemsDataGrid.Rows.Add(
					good.Name,
					amount.Value.ToString("N3"),
					Math.Round(amount.Value * good.Price, 2).ToString("N2"),
					good.Id.ToString(),
					good.Price.ToString("N2"));

				saleTotalLabel.Text = saleItemsDataGrid
					.Rows
					.Cast<DataGridViewRow>()
					.Sum(row => decimal.Parse(row.Cells["saleItemTotalColumn"].Value.ToString())).ToString("N2");

				saleItemsCountLabel.Text = saleItemsDataGrid.Rows.Count.ToString();

				inputTextBox.Text = string.Empty;
			}
		}

		public void ShowError(string message)
		{
			MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMe()
		{
			// open new sale document right before show form
			Invoke(OpenSaleRequested);

			_context.MainForm = this;

			Show();
		}

		public void CloseMe()
		{
			Close();
		}

		private void Invoke(Action action)
		{
			if (action != null) action();
		}

		private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar)) && !inputTextBox.Focused)
			{
				inputTextBox.Text += e.KeyChar;
				inputTextBox.Focus();
				inputTextBox.SelectionStart = int.MaxValue;
				e.Handled = true;
			}
		}

		private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return)
			{
				if (string.IsNullOrWhiteSpace(inputTextBox.Text))
					Invoke(CloseSaleRequested);
				else
					Invoke(GoodInfoRequested);

			}
			else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				if (saleItemsDataGrid.SelectedRows.Count > 0)
				{
					int increment = e.KeyCode == Keys.Up ? -1 : 1;
					int currentRowIndex = saleItemsDataGrid.SelectedRows[0].Index;
					int rowsCount = saleItemsDataGrid.Rows.Count;

					int rowToSelectIndex = (currentRowIndex + increment) % rowsCount;

					if (rowToSelectIndex < 0) rowToSelectIndex = rowsCount - 1;

					saleItemsDataGrid.Rows[rowToSelectIndex].Selected = true;
				}
			}
		}

		private void currentTimeRefreshTimer_Tick(object sender, EventArgs e)
		{
			currentTimeLabel.Text = DateTime.Now.ToString();
		}

		private void saleItemsDataGrid_SelectionChanged(object sender, EventArgs e)
		{
			if (saleItemsDataGrid.SelectedRows.Count > 0)
			{
				goodNameLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				saleItemAmountLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[1].Value.ToString();
				saleItemTotalLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[2].Value.ToString();
				goodIdLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[3].Value.ToString();
				goodPriceLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[4].Value.ToString();
			}
		}

		private IUnityContainer _container;
		private ApplicationContext _context;
		private Account _account;
		private Document _document;
	}
}
