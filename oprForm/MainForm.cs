using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oprForm
{
	public partial class MainForm : Form
	{
        int expertId;
		public MainForm(int expertId)
		{
			InitializeComponent();
            this.expertId = expertId;
		}

		private void eventToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlannedEventsForm child = new PlannedEventsForm();
			child.MdiParent = this;
			child.Show();
		}

		private void переглядЗаходiвToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LookEventsForm child = new LookEventsForm();
			child.MdiParent = this;
			child.Show();
		}

        private void переглядПроблемToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new IssuesForm();
			child.MdiParent = this;
			child.Show();
        }

        private void шаблониToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new AddTemplateForm();
			child.MdiParent = this;
			child.Show();
        }

        private void додатиРесурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new AddMaterialForm();
			child.MdiParent = this;
			child.Show();
        }

        private void ресурсиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new MaterialsForm();
			child.MdiParent = this;
			child.Show();
        }

        private void змiнитиЗахiдToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new AlterEventForm();
			child.MdiParent = this;
			child.Show();
        }

        private void переглядЗаходiвToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
			LookEventsForm child = new LookEventsForm();
			child.MdiParent = this;
			child.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
			var child = new AlterEventForm();
			child.MdiParent = this;
			child.Show();
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			PlannedEventsForm child = new PlannedEventsForm();
			child.MdiParent = this;
			child.Show();
        }

        private void змiнитиШаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var child = new AlterTemplateForm();
			child.MdiParent = this;
			child.Show();
        }
    }
}
