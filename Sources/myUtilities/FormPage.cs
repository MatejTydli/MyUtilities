using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace myUtilities
{
	public class FormPage
	{
		private Dictionary<Form, FormProperties> SavedForms = new Dictionary<Form, FormProperties>();
		public Control[] Controls { get; private set; }
		public List<Form> Forms { get; private set; }
		public Color BackColor { get; private set; }
		public string Text { get; private set; }
		public bool ShowIcon { get; private set; }

		public FormPage(Control[] controls, Color backColor, string text, bool showIcon)
		{
			this.Controls = controls;
			this.BackColor = backColor;
			this.Text = text;
			this.ShowIcon = showIcon;

			Forms = new List<Form>();
		}

		public void ChangeControls(Control[] controls)
		{
			this.Controls = controls;
		}

		public void LoadToForm(Form form)
		{
			Forms.Add(form);
			SavedForms.Add(form, new FormProperties(form.BackColor, form.Text, form.ShowIcon));

			form.BackColor = this.BackColor;
			form.Text = this.Text;
			form.ShowIcon = this.ShowIcon;

			form.Controls.AddRange(this.Controls);
		}

		public void LoadToFormInstedCurrent(Form form, FormPage currentPage)
		{
			currentPage.RemoveFromForm(form);
			this.LoadToForm(form);
		}

		public void RemoveFromForm(Form form)
		{
			foreach (var control in Controls.Cast<Control>().ToArray())
			{
				if (this.Controls.Contains(control))
				{
					form.Controls.Remove(control);
				}
			}

			form.BackColor = SavedForms[form].BackColor;
			form.Text = SavedForms[form].Text;
			form.ShowIcon = SavedForms[form].ShowIcon;

			SavedForms.Remove(form);
		}

		private struct FormProperties
		{
			public readonly Color BackColor;
			public readonly string Text;
			public readonly bool ShowIcon;

			public FormProperties(Color backColor, string text, bool showIcon)
			{
				this.BackColor = backColor;
				this.Text = text;
				this.ShowIcon = showIcon;
			}
		}
	}
}