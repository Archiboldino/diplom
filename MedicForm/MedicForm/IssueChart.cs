using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartModule;

namespace MedicForm
{
    public partial class IssueChart : Form
    {
        DBManager dbManager = new DBManager();
        ChartM chart;
        public IssueChart()
        {
            InitializeComponent();
            string item = "";
            var issues = dbManager.GetRows("issues", "name", "");
            for (int i = 0; i < issues.Count; i++)
            {
                item += issues[i][0];
                problemBox.Items.Add(item);
                item = "";
            }
        }

        // при выборе проблемы из списка, заполняется список серий этой проблемы
        private void problemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            issueSerias.Items.Clear();
            addedIssueSerias.Items.Clear();
            var issueId = dbManager.GetValue("issues", "issue_id", "name = '" + problemBox.Text + "'");
            var serias = dbManager.GetRows("calculations_description", "calculation_number", "issue_id = " + issueId);

            for (int i = 0; i < serias.Count; i++)
            {
                issueSerias.Items.Add(serias[i][0]);
            }
        }

        // метод добавляет выбранную серию в результирующий список
        private void addIssueSeria_Click(object sender, EventArgs e)
        {
            if (issueSerias.SelectedItem != null)
            {
                if (!findItem(issueSerias.SelectedItem, addedIssueSerias))
                {
                    addedIssueSerias.Items.Add(issueSerias.SelectedItem);
                    getFormulas();
                }
            }
            addedIssueSerias.Sorted = true;
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

        private void getFormulas()
        {
            formulasList.Items.Clear();
            if (addedIssueSerias.Items.Count == 1)
            {
                var ids = dbManager.GetRows("calculations_result", "id_of_formula", "calculation_number = " + addedIssueSerias.Items[0]);
                for (int i = 0; i < ids.Count; i++)
                {
                    formulasList.Items.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + ids[i][0]));
                }
            }
            else
            {
                List<List<Object>> ids = new List<List<object>>();
                for (int i = 0; i < addedIssueSerias.Items.Count; i++)
                {
                    List<Object> list = new List<object>();
                    var temp = dbManager.GetRows("calculations_result", "id_of_formula", "calculation_number = " + addedIssueSerias.Items[i]);
                    for (int j = 0; j < temp.Count; j++)
                    {
                        list.Add(temp[j][0]);
                    }
                    ids.Add(list);
                }

                List<object> result = ids[0];

                for (int i = 0; i < ids.Count; i++)
                {
                    result = result.Intersect(ids[i]).ToList();
                }

                foreach (Object o in result)
                {
                    formulasList.Items.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + o));
                }
            }
        }

        // метод удаляет выбранную серию из результирующего списка
        private void removeIssueSeria_Click(object sender, EventArgs e)
        {
            if (addedIssueSerias.SelectedItem != null)
            {
                addedIssueSerias.Items.Remove(addedIssueSerias.SelectedItem);
                getFormulas();
            }
        }

        // рисуем диаграму проблемы 
        private void diagIssueButt_Click(object sender, EventArgs e)
        {
            if(problemBox.SelectedItem != null & addedIssueSerias.Items.Count != 0 & formulasList.CheckedItems.Count != 0)
            {
                List<List<object>> formulas = new List<List<object>>();
                List<object> formIds = new List<object>();
                List<List<object>> list = new List<List<object>>();
                List<string> names = new List<string>();

                /* for (int i = 0; i < addedIssueSerias.Items.Count; i++)
                 {
                     formulas = dbManager.GetRows("calculations_result",
                         "id_of_formula", "calculation_number = " + addedIssueSerias.Items[i]);
                 }

                 for (int i = 0; i < formulas.Count; i++)
                 {
                     formIds.Add(formulas[i][0]);
                 }

                 IEnumerable<object> ids = formIds.Distinct();*/
                List<Object> ids = new List<object>();
                for(int i = 0; i < formulasList.CheckedItems.Count; i++)
                {
                    ids.Add(dbManager.GetValue("formulas", "id_of_formula","name_of_formula = '" + formulasList.CheckedItems[i] + "'"));
                }

                foreach (object i in ids)
                {
                    list.Add(getResult(i));
                    names.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + i) + " (" +
                        dbManager.GetValue("formulas", "measurement_of_formula", "id_of_formula = " + i) + ")");
                }

                List<Object> listOfSerias = new List<object>();
                for (int i = 0; i < addedIssueSerias.Items.Count; i++)
                {
                    listOfSerias.Add(addedIssueSerias.Items[i]);
                }

                chart = new ChartM("Значення формули у серії", "range");
                chart.drawIssue(listOfSerias, list, names);
                chart.ShowDialog();
            }
            else
            {
                MessageBox.Show("Поля не заповнені");
            }
        }

        // метод возвращает список результатов показателя
        private List<object> getResult(object formulaId)
        {
            List<object> list = new List<object>();
            for (int i = 0; i < addedIssueSerias.Items.Count; i++)
            {
                list.Add(dbManager.GetValue("calculations_result", "result", "id_of_formula = " + formulaId +
                    " AND calculation_number = " + addedIssueSerias.Items[i]));
            }

            return list;
        }

        private void chartIssueButt_Click(object sender, EventArgs e)
        {
            if (problemBox.SelectedItem != null & addedIssueSerias.Items.Count != 0 & formulasList.CheckedItems.Count != 0)
            {
                List<List<object>> formulas = new List<List<object>>();
                List<object> formIds = new List<object>();
                List<List<object>> list = new List<List<object>>();
                List<string> names = new List<string>();

                /*for (int i = 0; i < addedIssueSerias.Items.Count; i++)
                {
                    formulas = dbManager.GetRows("calculations_result",
                        "id_of_formula", "calculation_number = " + addedIssueSerias.Items[i]);
                }

                for (int i = 0; i < formulas.Count; i++)
                {
                    formIds.Add(formulas[i][0]);
                }

                IEnumerable<object> ids = formIds.Distinct();*/

                List<Object> ids = new List<object>();
                for (int i = 0; i < formulasList.CheckedItems.Count; i++)
                {
                    ids.Add(dbManager.GetValue("formulas", "id_of_formula", "name_of_formula = '" + formulasList.CheckedItems[i] + "'"));
                }
                foreach (object i in ids)
                {
                    list.Add(getResult(i));
                    names.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + i) + " (" +
                        dbManager.GetValue("formulas", "measurement_of_formula", "id_of_formula = " + i) + ")");
                }

                List<Object> listOfSerias = new List<object>();
                for (int i = 0; i < addedIssueSerias.Items.Count; i++)
                {
                    listOfSerias.Add(addedIssueSerias.Items[i]);
                }

                chart = new ChartM("Значення формули у серії", "line");
                chart.drawIssue(listOfSerias, list, names);
                chart.ShowDialog();
            }
            else
            {
                MessageBox.Show("Поля не заповнені");
            }
        }

        // метод выводит название и описание серии при выборе серии в списке 
        private void issueSerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            seriaName.Text = dbManager.GetValue("calculations_description", "calculation_name", "calculation_number = " + issueSerias.SelectedItem).ToString();
            seriaDescription.Text = dbManager.GetValue("calculations_description", "description_of_calculation", "calculation_number = " + issueSerias.SelectedItem).ToString();
        }

        private void addAll_Click(object sender, EventArgs e)
        {
            if (issueSerias.Items.Count != 0)
            {
                if (!findItem(issueSerias.SelectedItem, addedIssueSerias))
                {
                    foreach(Object o in issueSerias.Items)
                    {
                        addedIssueSerias.Items.Add(o);
                    }
                    getFormulas();
                }
            }
            addedIssueSerias.Sorted = true;
        }

        private void removeAll_Click(object sender, EventArgs e)
        {
            if (addedIssueSerias.Items.Count != 0)
            {
                addedIssueSerias.Items.Clear();
                formulasList.Items.Clear();
            }
        }
    }
}
