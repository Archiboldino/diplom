using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oprForm;
namespace experts_jurist
{
    public partial class mainWin : Form
    {

        private estimate ResultMDIChild;
        private search RedaktMDIChild;
        private greeting GreetMDIChild;
		private issues IssuesMDIChild;

		private PlannedEventsForm NewEventMDIChild;
		private AddTemplateForm NewTemplateMDIChild;
		private AlterTemplateForm TemplateMDIChild;

        private int userId;
        private bool closeIt = false;
        public mainWin()
        {
			InitializeComponent();
        }
		public mainWin(int userId)
		{
			this.userId = userId;
			GreetMDIChild = new greeting(userId);
			InitializeComponent();
		}

		private void estimate_Click(object sender, EventArgs e)
        {
            if (ResultMDIChild == null)
            {
                ResultMDIChild = new estimate();
                ResultMDIChild.MdiParent = this;
                ResultMDIChild.Show();
                ResultMDIChild.FormClosed += ResultMDIChild_FormClosed;
                ResultMDIChild.WindowState = FormWindowState.Maximized;
            }
            ResultMDIChild.BringToFront();
        }

        private void ResultMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMDIChild.Dispose();
            ResultMDIChild = null;
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (RedaktMDIChild == null)
            {
                RedaktMDIChild = new search();
                RedaktMDIChild.MdiParent = this;
                RedaktMDIChild.Show();
                RedaktMDIChild.FormClosed += RedaktMDIChild_FormClosed;
                RedaktMDIChild.WindowState = FormWindowState.Maximized;
            }
            RedaktMDIChild.BringToFront();
        }

        private void RedaktMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            RedaktMDIChild.Dispose();
            RedaktMDIChild = null;
        }

        private void offer_Click(object sender, EventArgs e)
        {
            if (NewEventMDIChild == null)
            {
				NewEventMDIChild = new PlannedEventsForm(userId);
				NewEventMDIChild.MdiParent = this;
				NewEventMDIChild.Show();
				NewEventMDIChild.FormClosed += NewEventMDIChild_FormClosed;
				NewEventMDIChild.WindowState = FormWindowState.Maximized;
            }
			NewEventMDIChild.BringToFront();
        }
		
        private void NewEventMDIChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			NewEventMDIChild.Dispose();
			NewEventMDIChild = null;
		}

        private void mainWin_Load(object sender, EventArgs e)
        {
            if(closeIt)
            {
                this.Close();
            } else
            {
                GreetMDIChild.Show();
                GreetMDIChild.MdiParent = this;
                GreetMDIChild.FormClosed += GreetMDIChild_FormClosed;
                GreetMDIChild.WindowState = FormWindowState.Maximized;

            }
        }

        private void проМодульToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GreetMDIChild == null)
            {
                GreetMDIChild = new greeting(userId);
                GreetMDIChild.MdiParent = this;
                GreetMDIChild.Show();
                GreetMDIChild.FormClosed += GreetMDIChild_FormClosed;
                GreetMDIChild.WindowState = FormWindowState.Maximized;
            }
            GreetMDIChild.BringToFront();
        }

        private void GreetMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            GreetMDIChild.Dispose();
            GreetMDIChild = null;
        }

        private void mainWin_Shown(object sender, EventArgs e)
        {
        }
		private void alterTemplateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TemplateMDIChild == null)
			{
				TemplateMDIChild = new AlterTemplateForm();
				TemplateMDIChild.MdiParent = this;
				TemplateMDIChild.Show();
				TemplateMDIChild.FormClosed += TemplateMDIChild_FormClosed;
				TemplateMDIChild.WindowState = FormWindowState.Maximized;
			}
			TemplateMDIChild.BringToFront();
		}

		private void TemplateMDIChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			TemplateMDIChild.Dispose();
			TemplateMDIChild = null;
		}

		private void newTemplateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (NewTemplateMDIChild == null)
			{
				NewTemplateMDIChild = new AddTemplateForm();
				NewTemplateMDIChild.MdiParent = this;
				NewTemplateMDIChild.Show();
				NewTemplateMDIChild.FormClosed += NewTemplateMDIChild_FormClosed;
				NewTemplateMDIChild.WindowState = FormWindowState.Maximized;
			}
			NewTemplateMDIChild.BringToFront();
		}

		private void NewTemplateMDIChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			NewTemplateMDIChild.Dispose();
			NewTemplateMDIChild = null;
		}

		private void проблемыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IssuesMDIChild == null)
			{
				IssuesMDIChild = new issues();
				IssuesMDIChild.MdiParent = this;
				IssuesMDIChild.Show();
				IssuesMDIChild.FormClosed += IssuesMDIChild_FormClosed;
				IssuesMDIChild.WindowState = FormWindowState.Maximized;
			}
			IssuesMDIChild.BringToFront();
		}

		private void IssuesMDIChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			IssuesMDIChild.Dispose();
			IssuesMDIChild = null;
		}
	}
}
