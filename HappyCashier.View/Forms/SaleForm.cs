using System;
using System.Linq;
using System.Collections.Generic;
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
			set { _document = value; onDocumentUpdate(); }
		}
		
		public Account Account
		{ 
			get { return _account; } 
			set { _account = value; accountNameLabel.Text = value.Name; }
		}

		public string GoodsNameRequested { get { return inputTextBox.Text; } }

		public event Action OpenSaleRequested;
		public event Action CloseSaleRequested;
		public event Action GoodsInfoRequested;

		public void GoodsInfoReturned(Goods goods)
		{
			decimal? quantity = new GetDecimalDialog("Кол-во: ", 1).RequestUserValue();

			if (quantity.HasValue && quantity.Value > 0)
			{
				if (_document == null)
					Invoke(OpenSaleRequested);

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
			{
				documentIdLabel.Text = string.Empty;
				documentTypeLabel.Text = string.Empty;
				documentTotalLabel.Text = string.Empty;
				documentPositionsCountLabel.Text = string.Empty;

				documentPositionsDataGrid.Rows.Clear();

				goodNameLabel.Text = string.Empty;
				positionQuantityLabel.Text = string.Empty;
				positionTotalLabel.Text = string.Empty;
				goodIdLabel.Text = string.Empty;
				goodPriceLabel.Text = string.Empty;

				return;
			}

			documentIdLabel.Text = _document.Id.ToString();
			documentTypeLabel.Text = "Продажа";

			// save selected item index in goods list
			int selectedSaleItemIndex = documentPositionsDataGrid.SelectedRows.Count > 0 ? documentPositionsDataGrid.SelectedRows[0].Index : int.MaxValue;
			documentPositionsDataGrid.Rows.Clear();

			foreach(var item in _document.Positions)
			{
				documentPositionsDataGrid.Rows.Add(
					item.Name,
					item.Quantity.ToString("N3"),
					item.Total.ToString("N2"),
					item.Id.ToString(),
					item.Price.ToString("N2"));
			}

			if (selectedSaleItemIndex < documentPositionsDataGrid.Rows.Count)
				documentPositionsDataGrid.Rows[selectedSaleItemIndex].Selected = true;

			documentTotalLabel.Text = _document.Total.ToString("N2");

			documentPositionsCountLabel.Text = _document.Positions.Count.ToString();
		}

		private void closeSale()
		{
			if (_document != null && _document.Positions.Count > 0)
			{
				// we can recieve null or some value
				// if null - user leave empty input field or cancel dialog
				decimal? cash = new GetDecimalDialog("Наличные: ", 0.00m).RequestUserValue();

				// do if null, just leave all as is
				if (!cash.HasValue)
					return;

				if (cash.Value >= _document.Total)
				{
					_document.CloseTime = DateTime.Now;
					decimal documentTotal = _document.Total; // cuz _document will be nulled in next string

					Invoke(CloseSaleRequested);

					MessageBox.Show(string.Format(
						"Здесь мы выводим размер сдачи, печатаем чек, счет или накладную. Кстати сдача {0} у.е.",
						documentTotal - cash.Value));
				}
			}
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
				{
					closeSale();
				}
				else
					Invoke(GoodsInfoRequested);

			}
			else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				if (documentPositionsDataGrid.SelectedRows.Count > 0)
				{
					int increment = e.KeyCode == Keys.Up ? -1 : 1;
					int currentRowIndex = documentPositionsDataGrid.SelectedRows[0].Index;
					int rowsCount = documentPositionsDataGrid.Rows.Count;

					int rowToSelectIndex = (currentRowIndex + increment) % rowsCount;

					if (rowToSelectIndex < 0) rowToSelectIndex = rowsCount - 1;

					documentPositionsDataGrid.Rows[rowToSelectIndex].Selected = true;
				}
			}
		}

		private void currentTimeRefreshTimer_Tick(object sender, EventArgs e)
		{
			currentTimeLabel.Text = DateTime.Now.ToString();
		}

		private void saleItemsDataGrid_SelectionChanged(object sender, EventArgs e)
		{
			if (documentPositionsDataGrid.SelectedRows.Count > 0)
			{
				goodNameLabel.Text = documentPositionsDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				positionQuantityLabel.Text = documentPositionsDataGrid.SelectedRows[0].Cells[1].Value.ToString();
				positionTotalLabel.Text = documentPositionsDataGrid.SelectedRows[0].Cells[2].Value.ToString();
				goodIdLabel.Text = documentPositionsDataGrid.SelectedRows[0].Cells[3].Value.ToString();
				goodPriceLabel.Text = documentPositionsDataGrid.SelectedRows[0].Cells[4].Value.ToString();
			}
		}

		private readonly ApplicationContext _context;
		private Account _account = null;
		private Document _document = null;
	}
}
