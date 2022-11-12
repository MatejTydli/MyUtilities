using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace myUtilities
{
	public class FormPage
	{
		private Dictionary<Form, FormProperties> FormSavedProperties = new Dictionary<Form, FormProperties>();
		public Control[] Controls { get; private set; }
		public List<Form> Forms { get; private set; }
		public object Tag { get; private set; }
		public Color BackColor { get; private set; }
		public string Text { get; private set; }
		public bool ShowIcon { get; private set; }

		public FormPage(Control[] controls, Color backColor, string text, bool showIcon, object tag)
		{
			this.Controls = controls;
			this.Tag = tag;
			this.BackColor = backColor;
			this.Text = text;
			this.ShowIcon = showIcon;

			Forms = new List<Form>();

			foreach (Control control in this.Controls)
			{
				control.Tag = tag;
			}
		}

		public void changeControls(Control[] controls)
		{
			this.Controls = controls;

			foreach (Control control in this.Controls)
			{
				control.Tag = this.Tag;
			}
		}

		public void LoadToForm(Form form)
		{
			bool newForm = true;
			foreach (Form Form in Forms)
			{
				if (Form == form)
				{
					newForm = false;
					break;
				}
			}

			if (newForm)
			{
				Forms.Add(form);
				FormSavedProperties.Add(form, new FormProperties(form.BackColor, form.Text, form.ShowIcon));
			}

			form.BackColor = this.BackColor;
			form.Text = this.Text;
			form.ShowIcon = this.ShowIcon;

			form.AddControls(this.Controls);
		}

		public void LoadToFormInstedCurrent(Form form, FormPage currentPage)
		{
			currentPage.RemoveFromForm(form);
			this.LoadToForm(form);
		}

		public void RemoveFromForm(Form form)
		{
			bool remove;
			do
			{
				remove = false;

				foreach (Control control in form.Controls)
				{
					if (this.Controls.Contains(control))
					{
						form.Controls.Remove(control);
					}
				}

				foreach (Control control in form.Controls)
				{
					if (this.Controls.Contains(control))
					{
						remove = true;
					}
				}
			} while (remove);

			form.BackColor = FormSavedProperties[form].BackColor;
			form.Text = FormSavedProperties[form].Text;
			form.ShowIcon = FormSavedProperties[form].ShowIcon;

			FormSavedProperties.Remove(form);
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