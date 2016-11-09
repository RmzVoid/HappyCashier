using System;
using System.Windows.Forms;

namespace HappyCashier.View.Dialogs
{
	public partial class GetDecimalDialog : Form, INumberDialog<decimal?>
	{
		public GetDecimalDialog(string caption, decimal defaultValue)
		{
			InitializeComponent();

			captionLabel.Text = caption;
			valueTextBox.Text = defaultValue.ToString();

			this.Width = 8 + captionLabel.Width + 8 + valueTextBox.Width + 8;
			this.Height = 8 + Math.Max(captionLabel.Height, valueTextBox.Height) + 8;
			valueTextBox.Left = captionLabel.Right + 8;
		}

		public decimal? Value
		{
			get
			{
				decimal? value = null;

				try
				{
					value = decimal.Parse(valueTextBox.Text);
				}
				catch
				{
				}

				return value;
			}
			set
			{
				valueTextBox.Text = value.HasValue ? value.Value.ToString() : string.Empty;
			}
		}

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
				this.Close();

			if (e.KeyCode == Keys.Escape)
			{
				valueTextBox.Text = string.Empty;
				this.Close();
			}
		}
	}
}
