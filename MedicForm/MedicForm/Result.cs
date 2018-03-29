using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartModule;
using Data;

namespace MedicForm
{
    public partial class Result : Form
    {
        DBManager dbManager = new DBManager();

        public Result()
        {
            InitializeComponent();
        }
        
        // при загрузке окна заполняются список серий и формул, создаются колонки dataGridView 
        private void Result_Load(object sender, EventArgs e)
        {
            getSerias();
            DataGridViewTextBoxColumn calc_func = new DataGridViewTextBoxColumn();
            calc_func.Name = "Показник";
            DataGridViewTextBoxColumn date = new DataGridViewTextBoxColumn();
            date.Name = "Дата розрахунку";
            DataGridViewTextBoxColumn res = new DataGridViewTextBoxColumn();
            res.Name = "Результат";
            DataGridViewTextBoxColumn measure = new DataGridViewTextBoxColumn();
            measure.Name = "Од. вимірювання";
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { calc_func, date, res, measure });
            this.dataGridViewResult.Rows.Clear();

        }

        private void getSerias()
        {
            seriesBox.Items.Clear();
            var series = dbManager.GetRows("calculations_description group by calculation_number", "calculation_name", "");
            string item = "";
            for (int i = 0; i < series.Count; i++)
            {
                item += series[i][0].ToString();
                seriesBox.Items.Add(item);
                item = "";
            }
        }

        // метод заполняет dataGridView данными из бд
        private void showResult()
        {
            dataGridViewResult.Rows.Clear();
            var number = dbManager.GetValue("calculations_description", "calculation_number", "calculation_name = '" + seriesBox.Text + "'");
            var results = dbManager.GetRows("calculations_result, formulas",
                "formulas.name_of_formula, date_of_calculation, result, formulas.measurement_of_formula",
                "calculations_result.id_of_formula = formulas.id_of_formula AND calculation_number = " + number);
            for (int i = 0; i < results.Count; i++)
            {
                this.dataGridViewResult.Rows.Add(results[i][0], results[i][1], results[i][2], results[i][3]);
            }

            var calculation = dbManager.GetRows("calculations_description", "description_of_calculation, issue_id", "calculation_name = '" + seriesBox.Text + "'");
            descSeria.Text = calculation[0][0].ToString();
            var issueDes = dbManager.GetRows("issues", "name, description", "issue_id = " + calculation[0][1]);
            issueName.Text = issueDes[0][0].ToString();
            issueDesc.Text = issueDes[0][1].ToString();
        }

        // метод вызивает showResult() при измении серии в списке seriesBox
        private void seriesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showResult();
        }

        // метод удаляет выбранную серии по нажатию кнопки
        private void delSeriaButt_Click(object sender, EventArgs e)
        {
            var number = dbManager.GetValue("calculations_description",
                "calculation_number", "calculation_name = '" + seriesBox.Text + "'");
            dbManager.DeleteFromDB("calculations_result","calculation_number", number.ToString());
            dbManager.DeleteFromDB("calculations_description","calculation_number", number.ToString());
            this.Refresh();
            getSerias();
            MessageBox.Show("Серія видалена");
        }

        // метод удалаяет расчет показателя из серии по нажатию кнопки
        private void delPokaz_Click(object sender, EventArgs e)
        {
            var formula_id = dbManager.GetValue("formulas", "id_of_formula", "name_of_formula = '" + dataGridViewResult.CurrentCell.Value + "'");
            string[] pole = { "id_of_formula", "calculation_number" };
            var id = dbManager.GetValue("calculations_description", "calculation_number", "calculation_name = '" + seriesBox.Text + "'");
            string[] values = { formula_id.ToString(), id.ToString()};
            dbManager.DeleteFromDB("calculations_result", pole, values);
            this.Refresh();
            getSerias();
            MessageBox.Show("Показник видалено");
        }
    }
}
