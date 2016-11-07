namespace HappyCashier.View.Dialogs
{
	partial class GetDecimalDialog
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
			System.Windows.Forms.Panel panel1;
			this.captionLabel = new System.Windows.Forms.Label();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			panel1 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(this.captionLabel);
			panel1.Controls.Add(this.valueTextBox);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(342, 326);
			panel1.TabIndex = 2;
			// 
			// captionLabel
			// 
			this.captionLabel.AutoSize = true;
			this.captionLabel.Location = new System.Drawing.Point(12, 9);
			this.captionLabel.Name = "captionLabel";
			this.captionLabel.Size = new System.Drawing.Size(141, 25);
			this.captionLabel.TabIndex = 1;
			this.captionLabel.Text = "Количество: ";
			this.captionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// valueTextBox
			// 
			this.valueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.valueTextBox.Location = new System.Drawing.Point(159, 7);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(141, 31);
			this.valueTextBox.TabIndex = 0;
			// 
			// GetDecimalDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(342, 326);
			this.ControlBox = false;
			this.Controls.Add(panel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ForeColor = System.Drawing.Color.DodgerBlue;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "GetDecimalDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ChooseAmountDialog";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetDecimalDialog_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GetDecimalDialog_KeyPress);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.Label captionLabel;


	}
}