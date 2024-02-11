using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Utils.Windows.Forms
{
	public class FormPage
	{
		private Dictionary<Form, FormProperties> SavedForms = new Dictionary<Form, FormProperties>();
		public List<Control> Controls { get; private set; }
		public Color BackColor { get; private set; }
		public string Text { get; private set; }
		public bool ShowIcon { get; private set; }

		public FormPage(List<Control> controls, Color backColor, string text, bool showIcon)
		{
			this.Controls = controls;
			this.BackColor = backColor;
			this.Text = text;
			this.ShowIcon = showIcon;
		}

		public void LoadToForm(Form form)
		{
			this.SavedForms.Add(form, new FormProperties(form.BackColor, form.Text, form.ShowIcon));

			form.BackColor = this.BackColor;
			form.Text = this.Text;
			form.ShowIcon = this.ShowIcon;

			form.Controls.AddRange(this.Controls.ToArray());
		}

		public void LoadToFormInstedCurrent(Form form, FormPage currentPage)
		{
			currentPage.RemoveFromForm(form);
			this.LoadToForm(form);
		}

		public void RemoveFromForm(Form form)
		{
			foreach (Control control in this.Controls) form.Controls.Remove(control);

			form.BackColor = this.SavedForms[form].BackColor;
			form.Text = this.SavedForms[form].Text;
			form.ShowIcon = this.SavedForms[form].ShowIcon;

			this.SavedForms.Remove(form);
		}

		public void AddControl(Control control)
		{
			List<Control> newControls = this.Controls;
			newControls.Add(control);
			this.ChangeControls(newControls);
		}

		public void AddControls(List<Control> controls)
		{
			List<Control> newControls = this.Controls;
			newControls.AddRange(controls);
			this.ChangeControls(newControls);
		}

		public void RemoveControl(Control control)
		{
			List<Control> newControls = this.Controls;
			newControls.Remove(control);
			this.ChangeControls(newControls);
		}

		public void ChangeControls(List<Control> newControls)
		{
			this.Controls = newControls;

			foreach (Form savedForm in this.SavedForms.Keys)
			{
				savedForm.Controls.Clear();
				savedForm.Controls.AddRange(newControls.ToArray());
			}
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