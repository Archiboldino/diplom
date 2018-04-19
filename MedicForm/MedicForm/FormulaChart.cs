using ChartModule;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicForm
{
    public partial class FormulaChart : Form
    {
        private ChartM chart;
        private DBManager dbManager = new DBManager();

        public FormulaChart()
        {
            InitializeComponent();
            var formulas = dbManager.GetRows("formulas", "name_of_formula, description_of_formula", "id_of_expert = 1");
            string item = "";
            for (int i = 0; i < formulas.Count(); i++)
            {
                item += formulas[i][1];
                funcComboBox.Items.Add(item);
                item = "";
            }
        }

        private void funcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            seriaList.Items.Clear();
            addSeriaList.Items.Clear();
            var formula = dbManager.GetValue("formulas", "id_of_formula", "description_of_formula = '" + funcComboBox.Text + "'");
            var serias = dbManager.GetRows("calculations_result", "calculation_number", "id_of_formula = " + formula);

            for (int i = 0; i < serias.Count; i++)
            {
                seriaList.Items.Add(serias[i][0]);
            }
        }

        // метод добавляет выбранную серию в результирующий список, если её там еще нет
        private void addButton_Click(object sender, EventArgs e)
        {
            if (seriaList.SelectedItem != null)
            {
                if (!findItem(seriaList.SelectedItem, addSeriaList))
                {
                    addSeriaList.Items.Add(seriaList.SelectedItem);
                }
            }
            addSeriaList.Sorted = true;
        }

        // метод ищет серию в списке выбранных серий
        private bool findItem(object Item, ListBox list)
        {
            foreach (object o in list.Items)
            {
                if (o.Equals(Item))
                {
                    return true;
                }
            }

            return false;
        }

        // метод убирает выбранный элемент из списка ранне выбранных серий
        private void removeButt_Click(object sender, EventArgs e)
        {
            if (addSeriaList.SelectedItem != null)
            {
                addSeriaList.Items.Remove(addSeriaList.SelectedItem);
            }
        }

        private void diagrButt_Click(object sender, EventArgs e)
        {
            if (funcComboBox.SelectedItem != null)
            {
                Object[] arrayOfY = new Object[addSeriaList.Items.Count];
                Object[] arrayOfX = new Object[addSeriaList.Items.Count];

                for (int i = 0; i < addSeriaList.Items.Count; i++)
                {
                    arrayOfY[i] = addSeriaList.Items[i];
                    arrayOfX[i] = dbManager.GetValue("calculations_result", "result", "calculation_number = "
                        + addSeriaList.Items[i] + " AND id_of_formula = " +
                        dbManager.GetValue("formulas", "id_of_formula", "description_of_formula = '" +
                        funcComboBox.Text + "'"));
                }

                chart = new ChartM(dbManager.GetValue("formulas", "name_of_formula",
                    "description_of_formula = '" + funcComboBox.Text + "'").ToString()
                     + " ("
                    + dbManager.GetValue("formulas", "measurement_of_formula",
                    "description_of_formula = '" + funcComboBox.Text + "'").ToString()
                    + ")",
                    "range");
                chart.draw(arrayOfX, arrayOfY);
                chart.ShowDialog();
            }
            else
            {
                MessageBox.Show("Оберіть показник");
            }
        }

        private void graphButt_Click(object sender, EventArgs e)
        {
            if (funcComboBox.SelectedItem != null)
            {
                Object[] arrayOfY = new Object[addSeriaList.Items.Count];
                Object[] arrayOfX = new Object[addSeriaList.Items.Count];

                for (int i = 0; i < addSeriaList.Items.Count; i++)
                {
                    arrayOfY[i] = addSeriaList.Items[i];
                    arrayOfX[i] = dbManager.GetValue("calculations_result", "result", "calculation_number = "
                        + addSeriaList.Items[i] + " AND id_of_formula = " +
                        dbManager.GetValue("formulas", "id_of_formula", "description_of_formula = '" +
                        funcComboBox.Text + "'"));
                }

                chart = new ChartM(dbManager.GetValue("formulas", "name_of_formula",
                    "description_of_formula = '" + funcComboBox.Text + "'").ToString()
                    + " ("
                    + dbManager.GetValue("formulas", "measurement_of_formula",
                    "description_of_formula = '" + funcComboBox.Text + "'").ToString()
                    + ")"
                    , "line");
                chart.draw(arrayOfX, arrayOfY);
                chart.ShowDialog();
            }
            else
            {
                MessageBox.Show("Оберіть показник");
            }
        }

        private void seriaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (funcComboBox.SelectedIndex >= 0)
            {
                seriaName.Text = dbManager.GetValue("calculations_description", "calculation_name", "calculation_number = " + seriaList.SelectedItem).ToString();
                seriaDescription.Text = dbManager.GetValue("calculations_description", "description_of_calculation", "calculation_number = " + seriaList.SelectedItem).ToString();
            }
        }

        private int i;

        private void funcComboBox_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            i = funcComboBox.FindString(funcComboBox.Text);
            if (i >= 0) label1.Text = funcComboBox.Items[i].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            funcComboBox.SelectedIndex = i;
        }

        private void addAll_Click(object sender, EventArgs e)
        {
            if (seriaList.Items.Count != 0)
            {
                if (!findItem(seriaList.SelectedItem, addSeriaList))
                {
                    foreach (Object o in seriaList.Items)
                    {
                        addSeriaList.Items.Add(o);
                    }
                }
            }
            addSeriaList.Sorted = true;
        }

        private void removeAll_Click(object sender, EventArgs e)
        {
            if (addSeriaList.Items.Count != 0)
            {
                addSeriaList.Items.Clear();
            }
        }
    }
}