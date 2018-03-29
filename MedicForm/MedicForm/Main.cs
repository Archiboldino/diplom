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
using System.Windows.Forms.DataVisualization.Charting;
using Edit;
using UserLoginForm;
using Data;

namespace MedicForm
{
    public partial class Main : Form
    {
        DBManager dbManager = new DBManager();

        public Main()
        {
            InitializeComponent();
            funcComboBox.Items.Clear();
        }   

        // метод создает поля для dataGridView при загрузке окна
        private void Form1_Load(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            if (userLogin.ShowDialog() == DialogResult.OK)
            {
                getMenu();

                DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
                name.Name = "Назва параметру";
                DataGridViewTextBoxColumn value = new DataGridViewTextBoxColumn();
                value.Name = "Значення";
                DataGridViewTextBoxColumn measurement = new DataGridViewTextBoxColumn();
                measurement.Name = "Одиниця вимірювання";
                dataGridViewParam.Columns.AddRange(new DataGridViewColumn[] { name, value, measurement });
            }
            else
            {
                Close();
            }

            chartsList.Items.Add("Графік показника");
            chartsList.Items.Add("Графік проблеми");
        }

        // метод открывает окно расчета формул при нажатии на кнопку
        private void button3_Click(object sender, EventArgs e)
        {
           new Calculate(Convert.ToInt32(dbManager.GetValue("formulas", "id_of_formula", "description_of_formula = '" + funcComboBox.Text + "'"))).ShowDialog();
           
        }

        // метод заполняет главное меню формы значениями из бд
        private void getMenu()
        {
            var formulas = dbManager.GetRows("formulas", "name_of_formula, description_of_formula", "id_of_expert = 3");
            string item = "";
            for (int i = 0; i < formulas.Count; i++)
            {
                item += /*formulas[i][0].ToString() + " - "+*/ formulas[i][1];
                funcComboBox.Items.Add(item);
                item = "";
            }
        }

        // метод открывает окно редактора формул по нажатию кнопки
        private void editButt_Click(object sender, EventArgs e)
        {
            new Redakt().ShowDialog();
        }

        // метод открывает окно просмотра результатов при нажатии на кнопку
        private void resultButton_Click(object sender, EventArgs e)
        {
            new Result().ShowDialog();
        }

        bool isOpenCalc = false;

        /* метод открывает дополнительное меню для расчета при нажатии на кнопку
         если isOpen true
         и закрівает его если false 
             */
        private void calcBoxButton_Click(object sender, EventArgs e)
        {
            if (isOpenCalc)
            {
                calcBox.Hide();
                calcBoxButton.Text = "→";
                isOpenCalc = false;
            }
            else
            {
                calcBox.Show();
                calcBoxButton.Text = "↑";
                isOpenCalc = true;
            }
        }

        bool isOpenChart = false;

        private void chartButt_Click(object sender, EventArgs e)
        {
            if(isOpenChart)
            {
                chartBox.Hide();
                chartButt.Text = "→";
                isOpenChart = false;
            }
            else
            {
                chartBox.Show();
                chartButt.Text = "↑";
                isOpenChart = true;
            }
        }

        private void newChartButt_Click(object sender, EventArgs e)
        {
            if (chartsList.Text.Equals("Графік показника"))
            {
                new FormulaChart().ShowDialog();
            }
            else if (chartsList.Text.Equals("Графік проблеми"))
            {
                new IssueChart().ShowDialog();
            }
        }
    }
}
