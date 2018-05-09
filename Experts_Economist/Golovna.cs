using Data;
using Odessa;
using oprForm;
using System;
using System.Windows.Forms;
using UserLoginForm;

namespace Experts_Economist
{
    public partial class Golovna : Form
    {
        public int id_of_exp; //переменная для хранения id експерта
        private DBManager db = new DBManager();

        public Golovna(int id) //класс формы, input - id експерта
        {
            InitializeComponent();
            id_of_exp = id;
        }

        private Rozrah RozrahMDIChild;
        private Result ResultMDIChild;
        private Redakt RedaktMDIChild;
        private Map MapMDIChild;

        private void Golovna_Load(object sender, EventArgs e)
        {
            label1.Text += " " + this.id_of_exp;
            label2.Text += " " + db.GetValue("expert", "expert_name", "id_of_expert = " + id_of_exp).ToString();
            if (id_of_exp == 0)
            {
                RedaktTSM.Visible = true;
                user_redakt_button.Visible = true;
            }
            if (MapMDIChild == null)
            {
                MapMDIChild = new Map();
                MapMDIChild.id_of_exp = id_of_exp;
                MapMDIChild.MdiParent = this;
                MapMDIChild.Show();
                MapMDIChild.FormClosed += MapMDIChild_FormClosed;
            }
            MapMDIChild.BringToFront();
        }

        private void MapMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            MapMDIChild.Dispose();
            MapMDIChild = null;
        }

        //событие нажатия на кнопку Розрахунок - запуск формы Rozrah в главном окне(Mdi)
        private void RozrahTSM_Click(object sender, EventArgs e)
        {
            if (RozrahMDIChild == null)
            {
                RozrahMDIChild = new Rozrah();
                RozrahMDIChild.id_of_exp = id_of_exp;
                RozrahMDIChild.MdiParent = this;
                RozrahMDIChild.Show();
                RozrahMDIChild.FormClosed += RozrahMDIChild_FormClosed;
            }
            RozrahMDIChild.BringToFront();
        }

        private void RozrahMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            RozrahMDIChild.Dispose();
            RozrahMDIChild = null;
        }

        //событие нажатия на кнопку Перегляд результатів - запуск формы Result в главном окне(Mdi)
        private void ResultTSM_Click(object sender, EventArgs e)
        {
            if (ResultMDIChild == null)
            {
                ResultMDIChild = new Result();
                ResultMDIChild.id_of_exp = id_of_exp;
                ResultMDIChild.MdiParent = this;
                ResultMDIChild.Show();
                ResultMDIChild.FormClosed += ResultMDIChild_FormClosed;
            }
            ResultMDIChild.BringToFront();
        }

        private void ResultMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMDIChild.Dispose();
            ResultMDIChild = null;
        }

        //событие нажатия на кнопку Редактор формул - запуск формы Redakt в главном окне(Mdi)
        private void RedaktTSM_Click(object sender, EventArgs e)
        {
            if (RedaktMDIChild == null)
            {
                RedaktMDIChild = new Redakt();
                RedaktMDIChild.MdiParent = this;
                RedaktMDIChild.Show();
                RedaktMDIChild.FormClosed += RedaktMDIChild_FormClosed;
            }
            RedaktMDIChild.BringToFront();
        }

        private void RedaktMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            RedaktMDIChild.Dispose();
            RedaktMDIChild = null;
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlannedEventsForm child = new PlannedEventsForm(id_of_exp);
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
            PlannedEventsForm child = new PlannedEventsForm(id_of_exp);
            child.MdiParent = this;
            child.Show();
        }

        private void змiнитиШаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new AlterTemplateForm();
            child.MdiParent = this;
            child.Show();
        }

        private void Golovna_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void user_redakt_button_Click(object sender, EventArgs e)
        {
            new User_editor().ShowDialog();
        }
    }
}