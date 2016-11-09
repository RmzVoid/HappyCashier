namespace HappyCashier.View.Forms
{
	partial class SaleForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Panel panel1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Panel panel2;
			System.Windows.Forms.Panel panel3;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Panel panel4;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.goodNameLabel = new System.Windows.Forms.Label();
			this.positionTotalLabel = new System.Windows.Forms.Label();
			this.positionQuantityLabel = new System.Windows.Forms.Label();
			this.goodPriceLabel = new System.Windows.Forms.Label();
			this.goodIdLabel = new System.Windows.Forms.Label();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.documentPositionsCountLabel = new System.Windows.Forms.Label();
			this.documentIdLabel = new System.Windows.Forms.Label();
			this.documentTypeLabel = new System.Windows.Forms.Label();
			this.documentTotalLabel = new System.Windows.Forms.Label();
			this.currentTimeLabel = new System.Windows.Forms.Label();
			this.accountNameLabel = new System.Windows.Forms.Label();
			this.documentPositionsDataGrid = new System.Windows.Forms.DataGridView();
			this.saleItemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saleItemQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saleItemTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saleItemIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saleItemPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.currentTimeRefreshTimer = new System.Windows.Forms.Timer(this.components);
			panel1 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.documentPositionsDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = System.Drawing.Color.DodgerBlue;
			panel1.Controls.Add(this.goodNameLabel);
			panel1.Controls.Add(this.positionTotalLabel);
			panel1.Controls.Add(this.positionQuantityLabel);
			panel1.Controls.Add(this.goodPriceLabel);
			panel1.Controls.Add(this.goodIdLabel);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(13, 324);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(837, 76);
			panel1.TabIndex = 1;
			// 
			// goodNameLabel
			// 
			this.goodNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.goodNameLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.goodNameLabel.Location = new System.Drawing.Point(1, 25);
			this.goodNameLabel.Name = "goodNameLabel";
			this.goodNameLabel.Size = new System.Drawing.Size(822, 46);
			this.goodNameLabel.TabIndex = 8;
			this.goodNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// positionTotalLabel
			// 
			this.positionTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.positionTotalLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.positionTotalLabel.Location = new System.Drawing.Point(721, 2);
			this.positionTotalLabel.Name = "positionTotalLabel";
			this.positionTotalLabel.Size = new System.Drawing.Size(104, 23);
			this.positionTotalLabel.TabIndex = 7;
			this.positionTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// positionQuantityLabel
			// 
			this.positionQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.positionQuantityLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.positionQuantityLabel.Location = new System.Drawing.Point(497, 2);
			this.positionQuantityLabel.Name = "positionQuantityLabel";
			this.positionQuantityLabel.Size = new System.Drawing.Size(136, 23);
			this.positionQuantityLabel.TabIndex = 6;
			this.positionQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// goodPriceLabel
			// 
			this.goodPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.goodPriceLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.goodPriceLabel.Location = new System.Drawing.Point(270, 2);
			this.goodPriceLabel.Name = "goodPriceLabel";
			this.goodPriceLabel.Size = new System.Drawing.Size(136, 23);
			this.goodPriceLabel.TabIndex = 5;
			this.goodPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// goodIdLabel
			// 
			this.goodIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.goodIdLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.goodIdLabel.Location = new System.Drawing.Point(60, 2);
			this.goodIdLabel.Name = "goodIdLabel";
			this.goodIdLabel.Size = new System.Drawing.Size(136, 23);
			this.goodIdLabel.TabIndex = 4;
			this.goodIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label4.ForeColor = System.Drawing.SystemColors.Window;
			label4.Location = new System.Drawing.Point(639, 2);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(76, 23);
			label4.TabIndex = 3;
			label4.Text = "Сумма: ";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label3.ForeColor = System.Drawing.SystemColors.Window;
			label3.Location = new System.Drawing.Point(412, 2);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 23);
			label3.TabIndex = 2;
			label3.Text = "Кол-во: ";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label2.ForeColor = System.Drawing.SystemColors.Window;
			label2.Location = new System.Drawing.Point(202, 2);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 23);
			label2.TabIndex = 1;
			label2.Text = "Цена: ";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label1.ForeColor = System.Drawing.SystemColors.Window;
			label1.Location = new System.Drawing.Point(3, 2);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(51, 23);
			label1.TabIndex = 0;
			label1.Text = "Код: ";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			panel2.BackColor = System.Drawing.SystemColors.Window;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(this.inputTextBox);
			panel2.Location = new System.Drawing.Point(13, 406);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(837, 62);
			panel2.TabIndex = 3;
			// 
			// inputTextBox
			// 
			this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.inputTextBox.Location = new System.Drawing.Point(3, 3);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.Size = new System.Drawing.Size(821, 55);
			this.inputTextBox.TabIndex = 0;
			this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inputTextBox.WordWrap = false;
			this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
			// 
			// panel3
			// 
			panel3.BackColor = System.Drawing.Color.DodgerBlue;
			panel3.Controls.Add(this.documentPositionsCountLabel);
			panel3.Controls.Add(this.documentIdLabel);
			panel3.Controls.Add(this.documentTypeLabel);
			panel3.Controls.Add(this.documentTotalLabel);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(label7);
			panel3.Controls.Add(label6);
			panel3.Controls.Add(label5);
			panel3.Location = new System.Drawing.Point(13, 474);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(837, 124);
			panel3.TabIndex = 2;
			// 
			// documentPositionsCountLabel
			// 
			this.documentPositionsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.documentPositionsCountLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.documentPositionsCountLabel.Location = new System.Drawing.Point(166, 79);
			this.documentPositionsCountLabel.Name = "documentPositionsCountLabel";
			this.documentPositionsCountLabel.Size = new System.Drawing.Size(136, 23);
			this.documentPositionsCountLabel.TabIndex = 12;
			this.documentPositionsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentIdLabel
			// 
			this.documentIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.documentIdLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.documentIdLabel.Location = new System.Drawing.Point(166, 40);
			this.documentIdLabel.Name = "documentIdLabel";
			this.documentIdLabel.Size = new System.Drawing.Size(136, 23);
			this.documentIdLabel.TabIndex = 11;
			this.documentIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentTypeLabel
			// 
			this.documentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.documentTypeLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.documentTypeLabel.Location = new System.Drawing.Point(166, 1);
			this.documentTypeLabel.Name = "documentTypeLabel";
			this.documentTypeLabel.Size = new System.Drawing.Size(136, 23);
			this.documentTypeLabel.TabIndex = 10;
			this.documentTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentTotalLabel
			// 
			this.documentTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.documentTotalLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.documentTotalLabel.Location = new System.Drawing.Point(416, 34);
			this.documentTotalLabel.Name = "documentTotalLabel";
			this.documentTotalLabel.Size = new System.Drawing.Size(407, 68);
			this.documentTotalLabel.TabIndex = 9;
			this.documentTotalLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label8
			// 
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label8.ForeColor = System.Drawing.SystemColors.Window;
			label8.Location = new System.Drawing.Point(605, 1);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(218, 33);
			label8.TabIndex = 4;
			label8.Text = "Сумма документа: ";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label7.ForeColor = System.Drawing.SystemColors.Window;
			label7.Location = new System.Drawing.Point(3, 79);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(157, 23);
			label7.TabIndex = 3;
			label7.Text = "Позиций: ";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label6.ForeColor = System.Drawing.SystemColors.Window;
			label6.Location = new System.Drawing.Point(3, 40);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(157, 23);
			label6.TabIndex = 2;
			label6.Text = "№ документа: ";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			label5.ForeColor = System.Drawing.SystemColors.Window;
			label5.Location = new System.Drawing.Point(3, 1);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(157, 23);
			label5.TabIndex = 1;
			label5.Text = "Вид документа: ";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			panel4.BackColor = System.Drawing.Color.SkyBlue;
			panel4.Controls.Add(this.currentTimeLabel);
			panel4.Controls.Add(this.accountNameLabel);
			panel4.Location = new System.Drawing.Point(13, 604);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(837, 23);
			panel4.TabIndex = 3;
			// 
			// currentTimeLabel
			// 
			this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.currentTimeLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.currentTimeLabel.Location = new System.Drawing.Point(453, 3);
			this.currentTimeLabel.Name = "currentTimeLabel";
			this.currentTimeLabel.Size = new System.Drawing.Size(381, 17);
			this.currentTimeLabel.TabIndex = 11;
			this.currentTimeLabel.Text = "13.08.2013 11:42:33";
			this.currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// accountNameLabel
			// 
			this.accountNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.accountNameLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.accountNameLabel.Location = new System.Drawing.Point(4, 3);
			this.accountNameLabel.Name = "accountNameLabel";
			this.accountNameLabel.Size = new System.Drawing.Size(307, 17);
			this.accountNameLabel.TabIndex = 10;
			this.accountNameLabel.Text = "Администратор";
			this.accountNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentPositionsDataGrid
			// 
			this.documentPositionsDataGrid.AllowUserToAddRows = false;
			this.documentPositionsDataGrid.AllowUserToDeleteRows = false;
			this.documentPositionsDataGrid.AllowUserToResizeColumns = false;
			this.documentPositionsDataGrid.AllowUserToResizeRows = false;
			this.documentPositionsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.documentPositionsDataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
			this.documentPositionsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.documentPositionsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.documentPositionsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.documentPositionsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.documentPositionsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.saleItemNameColumn,
            this.saleItemQuantityColumn,
            this.saleItemTotalColumn,
            this.saleItemIdColumn,
            this.saleItemPriceColumn});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.documentPositionsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
			this.documentPositionsDataGrid.GridColor = System.Drawing.Color.AliceBlue;
			this.documentPositionsDataGrid.Location = new System.Drawing.Point(13, 13);
			this.documentPositionsDataGrid.MultiSelect = false;
			this.documentPositionsDataGrid.Name = "documentPositionsDataGrid";
			this.documentPositionsDataGrid.ReadOnly = true;
			this.documentPositionsDataGrid.RowHeadersVisible = false;
			this.documentPositionsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.documentPositionsDataGrid.Size = new System.Drawing.Size(837, 304);
			this.documentPositionsDataGrid.TabIndex = 1;
			this.documentPositionsDataGrid.SelectionChanged += new System.EventHandler(this.saleItemsDataGrid_SelectionChanged);
			// 
			// saleItemNameColumn
			// 
			this.saleItemNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.saleItemNameColumn.HeaderText = "Наименование";
			this.saleItemNameColumn.Name = "saleItemNameColumn";
			this.saleItemNameColumn.ReadOnly = true;
			// 
			// saleItemQuantityColumn
			// 
			this.saleItemQuantityColumn.HeaderText = "Количество";
			this.saleItemQuantityColumn.Name = "saleItemQuantityColumn";
			this.saleItemQuantityColumn.ReadOnly = true;
			this.saleItemQuantityColumn.Width = 150;
			// 
			// saleItemTotalColumn
			// 
			this.saleItemTotalColumn.HeaderText = "Сумма";
			this.saleItemTotalColumn.Name = "saleItemTotalColumn";
			this.saleItemTotalColumn.ReadOnly = true;
			this.saleItemTotalColumn.Width = 96;
			// 
			// saleItemIdColumn
			// 
			this.saleItemIdColumn.HeaderText = "Код";
			this.saleItemIdColumn.Name = "saleItemIdColumn";
			this.saleItemIdColumn.ReadOnly = true;
			this.saleItemIdColumn.Visible = false;
			this.saleItemIdColumn.Width = 71;
			// 
			// saleItemPriceColumn
			// 
			this.saleItemPriceColumn.HeaderText = "Цена";
			this.saleItemPriceColumn.Name = "saleItemPriceColumn";
			this.saleItemPriceColumn.ReadOnly = true;
			this.saleItemPriceColumn.Visible = false;
			this.saleItemPriceColumn.Width = 81;
			// 
			// currentTimeRefreshTimer
			// 
			this.currentTimeRefreshTimer.Enabled = true;
			this.currentTimeRefreshTimer.Interval = 1000;
			this.currentTimeRefreshTimer.Tick += new System.EventHandler(this.currentTimeRefreshTimer_Tick);
			// 
			// SaleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(862, 638);
			this.Controls.Add(panel4);
			this.Controls.Add(panel3);
			this.Controls.Add(panel2);
			this.Controls.Add(panel1);
			this.Controls.Add(this.documentPositionsDataGrid);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "SaleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Счастливый кассир 1.0";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.documentPositionsDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView documentPositionsDataGrid;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.Label goodNameLabel;
		private System.Windows.Forms.Label positionTotalLabel;
		private System.Windows.Forms.Label positionQuantityLabel;
		private System.Windows.Forms.Label goodPriceLabel;
		private System.Windows.Forms.Label goodIdLabel;
		private System.Windows.Forms.Label documentTotalLabel;
		private System.Windows.Forms.Label currentTimeLabel;
		private System.Windows.Forms.Label accountNameLabel;
		private System.Windows.Forms.Timer currentTimeRefreshTimer;
		private System.Windows.Forms.DataGridViewTextBoxColumn saleItemNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn saleItemQuantityColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn saleItemTotalColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn saleItemIdColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn saleItemPriceColumn;
		private System.Windows.Forms.Label documentPositionsCountLabel;
		private System.Windows.Forms.Label documentIdLabel;
		private System.Windows.Forms.Label documentTypeLabel;
	}
}

