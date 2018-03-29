using ChartModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MedicForm
{
    public partial class IssueChart : Form
    {
        private DBManager dbManager = new DBManager();
        private ChartM chart;

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

        private void addIssueSeria_Click(object sender, EventArgs e)
        {
            if (issueSerias.SelectedItem != null)
            {
                if (!findItem(issueSerias.SelectedItem, addedIssueSerias))
                {
                    addedIssueSerias.Items.Add(issueSerias.SelectedItem);
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

        private void removeIssueSeria_Click(object sender, EventArgs e)
        {
            if (addedIssueSerias.SelectedItem != null)
            {
                addedIssueSerias.Items.Remove(addedIssueSerias.SelectedItem);
            }
        }

        private void diagIssueButt_Click(object sender, EventArgs e)
        {
            List<List<object>> formulas = new List<List<object>>();
            List<object> formIds = new List<object>();
            List<List<object>> list = new List<List<object>>();
            List<object> names = new List<object>();

            for (int i = 0; i < addedIssueSerias.Items.Count; i++)
            {
                formulas = dbManager.GetRows("calculations_result",
                    "id_of_formula", "calculation_number = " + addedIssueSerias.Items[i]);
            }

            for (int i = 0; i < formulas.Count; i++)
            {
                formIds.Add(formulas[i][0]);
            }

            IEnumerable<object> ids = formIds.Distinct();

            foreach (object i in ids)
            {
                list.Add(getResult(i));
                names.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + i));
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
            List<List<object>> formulas = new List<List<object>>();
            List<object> formIds = new List<object>();
            List<List<object>> list = new List<List<object>>();
            List<object> names = new List<object>();

            for (int i = 0; i < addedIssueSerias.Items.Count; i++)
            {
                formulas = dbManager.GetRows("calculations_result",
                    "id_of_formula", "calculation_number = " + addedIssueSerias.Items[i]);
            }

            for (int i = 0; i < formulas.Count; i++)
            {
                formIds.Add(formulas[i][0]);
            }

            IEnumerable<object> ids = formIds.Distinct();

            foreach (object i in ids)
            {
                list.Add(getResult(i));
                names.Add(dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + i));
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

        private void issueSerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            seriaName.Text = dbManager.GetValue("calculations_description", "calculation_name", "calculation_number = " + issueSerias.SelectedItem).ToString();
            seriaDescription.Text = dbManager.GetValue("calculations_description", "description_of_calculation", "calculation_number = " + issueSerias.SelectedItem).ToString();
        }
    }
}