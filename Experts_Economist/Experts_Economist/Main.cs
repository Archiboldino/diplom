using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Experts_Economist
{
    public partial class Main : Form
    {
        DBManager db = new DBManager();
        Calculations calc = new Calculations();

        public Main()
        {
            InitializeComponent();
            formulasDGV.AllowUserToAddRows = false;
            //System.Threading.Thread.CurrentThread.CurrentUICulture =
            //    new CultureInfo("uk-UA", false);
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //    new CultureInfo("uk-UA", false);
        }

        private void нацДохідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulasLB.Items.Clear();
            formulas_idLB.Items.Clear();
            formula_nameTB.Clear();
            formula_explTB.Clear();

            db.Connect();
            var obj = db.GetRows("formulas", "name_of_formula", "");
            string item = "";
            for (int i = 0; i < obj.Count; i++)
            {
                for (int j = 0; j < obj[i].Count; j++)
                {
                    item += obj[i][j];
                }
                formulasLB.Items.Add(item);
                item = "";
            }

            var obj1 = db.GetRows("formulas", "id_of_formula", "");
            item = "";
            for (int i = 0; i < obj1.Count; i++)
            {
                for (int j = 0; j < obj1[i].Count; j++)
                {
                    item += obj1[i][j];
                }
                formulas_idLB.Items.Add(item);
                item = "";
            }
        }

        private void ефектЖиттєдіяльностіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Connect();
        }

        private void ефЛюдськоїДіяльностіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Connect();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            db.Connect();
            refresh();

        }

        private void formulasLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.formulasDGV.Rows.Clear();
            formulas_idLB.SelectedIndex = formulasLB.SelectedIndex;
            string idf = formulas_idLB.SelectedItem.ToString();
            var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf);
            var obj1 = new List<List<Object>>();
            for (int i=0; i < obj.Count; i++)
            {
                obj1 = db.GetRows("formula_parameters", "name_of_parameter, measurement_of_parameter", "id_of_parameter = " + obj[i][0].ToString());
                this.formulasDGV.Rows.Add(obj1[0][0].ToString(), "0", obj1[0][1].ToString());
            }

            formula_nameTB.Text = formulasLB.SelectedItem.ToString();
            var obj2 = db.GetRows("formulas", "description_of_formula", "id_of_formula = " + idf);
            formula_explTB.Text = obj2[0][0].ToString();

        }

        private void Save_values_Click(object sender, EventArgs e)
        {
            db.Connect();
            if (formulasLB.SelectedIndex == 0)
            {
                if (formulasDGV.Rows.Count == 4)
                {
                    this.formulasDGV.Rows.RemoveAt(3);
                }

                double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                this.formulasDGV.Rows.Add("Result", calc.Q_t(a, b, c), "");
            }


            DateTime localDate = DateTime.Now;
            string[] fields3 = { "date_of_calculation", "id_of_formula", "result" };
            string[] values3 = { "'" + localDate.ToString("yyyy-MM-dd HH:mm:ss") + "'", (formulasLB.SelectedIndex + 1).ToString(), formulasDGV.Rows[3].Cells[1].Value.ToString() };
            db.InsertToBD("calculations_result", fields3, values3);
            // MessageBox.Show();

            string idf = formulas_idLB.SelectedItem.ToString();
            var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf);
            var obj0 = db.GetRows("calculations_result", "Max(calculation_number)", "");
            string[] fields2 = { "calculation_number","id_of_parameter", "parameter_value" };
            string[] values2 = { obj0[0][0].ToString(),"", "" };
            for (int i = 0; i < obj.Count; i++)
            {
                values2[1] = obj[i][0].ToString();
                values2[2] = formulasDGV.Rows[i].Cells[1].Value.ToString();
                MessageBox.Show(db.InsertToBD("parameters_value", fields2, values2));
                // MessageBox.Show();
            }

        }

            private void refresh()
        {
            formulasLB.Items.Clear();
            formulas_idLB.Items.Clear();
            formula_nameTB.Clear();
            formula_explTB.Clear();
            нацДохідToolStripMenuItem.PerformClick();
            formulasLB.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string[] fields3 = { "name_of_formula", "description_of_formula", "id_of_expert"};
            string[] values3 = { "'"+formula_nameTB.Text+"'", "'" + formula_explTB.Text+"'", "1" };
            db.InsertToBD("formulas", fields3, values3);
           // MessageBox.Show();
            refresh();
            formulasLB.SelectedIndex = formulasLB.Items.Count-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idf = formulas_idLB.SelectedItem.ToString();
            string[] fields4 = { "id_of_formula","name_of_formula", "description_of_formula", "id_of_expert" };
            string[] values4 = { idf, "'" + formula_nameTB.Text + "'", "'" + formula_explTB.Text + "'", "1" };
            db.UpdateRecord("formulas",fields4,values4);
            // MessageBox.Show();
            int ii = formulasLB.SelectedIndex;
            refresh();
            formulasLB.SelectedIndex = ii;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idf = formulas_idLB.SelectedItem.ToString();
            db.DeleteFromDB("formulas", "id_of_formula", idf);
           // MessageBox.Show();
            refresh();

        }
    }
}
