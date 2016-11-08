using System;
using System.Windows.Forms;

using HappyCashier.Presenter.DataTransferObjects;
using HappyCashier.Presenter.Views;
using HappyCashier.View.Dialogs;

using DocumentObject = HappyCashier.Presenter.DataTransferObjects.Document;

namespace HappyCashier.View.Forms
{
	public partial class SaleForm : Form, ISaleView
	{
		public SaleForm(ApplicationContext context, Account account)
		{
			InitializeComponent();

			// can't set up aligment of particular columns in designer
			saleItemQuantityColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemQuantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemTotalColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemTotalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			saleItemPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			Account = account;
			_context = context;
		}

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

		public string GoodNameRequested { get { return inputTextBox.Text; } }

		public event Action OpenSaleRequested;
		public event Action CloseSaleRequested;
		public event Action GoodInfoRequested;

		public void GoodInfoReturned(Goods goods)
		{
			if (_document == null)
				Invoke(OpenSaleRequested);

			GetDecimalDialog dialog = new GetDecimalDialog("Кол-во: ", 1);
			decimal? quantity = dialog.RequestUserValue();

			if (quantity.HasValue && quantity.Value > 0)
			{
				_document.Positions.Add(
					new Position()
					{
						Id = goods.Id,
						Name = goods.Name,
						Price = goods.Price,
						Quantity = quantity.Value
					});

				onDocumentUpdate();

				inputTextBox.Text = string.Empty;
			}
		}

		public void ShowError(string message)
		{
			MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMe()
		{
			_context.MainForm = this;
			Show();
		}

		public void CloseMe()
		{
			base.Close();
		}

		// Updates values of all controls with values from _document
		private void onDocumentUpdate()
		{
			if (_document == null)
				return;

			documentIdLabel.Text = _document.Id.ToString();
			documentTypeLabel.Text = "Продажа";

			// save selected item index in goods list
			int selectedSaleItemIndex = saleItemsDataGrid.SelectedRows.Count > 0 ? saleItemsDataGrid.SelectedRows[0].Index : int.MaxValue;
			saleItemsDataGrid.Rows.Clear();

			foreach(var item in _document.Positions)
			{
				saleItemsDataGrid.Rows.Add(
					item.Name,
					item.Quantity.ToString("N3"),
					item.Total.ToString("N2"),
					item.Id.ToString(),
					item.Price.ToString("N2"));
			}

			if (selectedSaleItemIndex < saleItemsDataGrid.Rows.Count)
				saleItemsDataGrid.Rows[selectedSaleItemIndex].Selected = true;

			saleTotalLabel.Text = _document.Total.ToString("N2");

			saleItemsCountLabel.Text = _document.Positions.Count.ToString();
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
				saleItemQuantityLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[1].Value.ToString();
				saleItemTotalLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[2].Value.ToString();
				goodIdLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[3].Value.ToString();
				goodPriceLabel.Text = saleItemsDataGrid.SelectedRows[0].Cells[4].Value.ToString();
			}
		}

		private readonly ApplicationContext _context;
		private Account _account = null;
		private Document _document = null;
	}
}
