using System;
using System.Windows.Forms;

namespace HappyCashier.View.Dialogs
{
	// Creates modal dialog requesting some value from user
	public partial class GetDecimalDialog : Form, IValueDialog<decimal?>
	{
		public GetDecimalDialog(string caption, decimal defaultValue)
		{
			InitializeComponent();

			captionLabel.Text = caption;
			valueTextBox.Text = defaultValue.ToString();

			// bad flexible layout
			this.Width = 8 + captionLabel.Width + 8 + valueTextBox.Width + 8;
			this.Height = 8 + Math.Max(captionLabel.Height, valueTextBox.Height) + 8;
			valueTextBox.Left = captionLabel.Right + 8;
		}

		#region IValueDialog implementation

		public decimal? RequestUserValue()
		{
			this.ShowDialog();

			decimal value;

			try
			{
				value = decimal.Parse(valueTextBox.Text);
				return new Nullable<decimal>(value);
			}
			catch
			{
				return null;
			}

		}

		#endregion

		#region Internal logic

		private void GetDecimalDialog_KeyPress(object sender, KeyPressEventArgs e)
		{
			decimal value;

			if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
				return;

			string text = valueTextBox.Text + e.KeyChar;

			if (decimal.TryParse(text, out value))
			{
				return;
			}

			e.Handled = true;
		}

		private void GetDecimalDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				Close();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				valueTextBox.Text = string.Empty;
				Close();
			}
		}

		#endregion
	}
}
