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
using Data;

namespace MedicForm
{
    public partial class Calculate : Form
    {
        DBManager dbManager = new DBManager();
        MedicalCalculator medicalCalculator = new MedicalCalculator();
        int kod_f; // код формулы которую расчитываем
        string[] parameterNames;
        double[] parameters;
        int[] ids;
        Label[] labels;
        Label[] descriptions;
        TextBox[] textBoxes;

        public Calculate(int kod_f)
        {
            InitializeComponent();
            this.kod_f = kod_f;
        }

        /* метод, при загрузке окна, заполняет groupBox именами и описаниями параметров
         * и полями для ввода этих параметров 
         */ 
        private void Calculate_Load(object sender, EventArgs e)
        {
            string item = "";
            var issues = dbManager.GetRows("issues", "name", "");
            for (int i = 0; i < issues.Count; i++)
            {
                item += issues[i][0];
                issueList.Items.Add(item);
                item = "";
            }

            var list_par = dbManager.GetRows("formula_compound, formula_parameters",
                "name_of_parameter, description_of_parameter, formula_parameters.id_of_parameter",
                "formula_compound.id_of_parameter = formula_parameters.id_of_parameter AND id_of_formula=" + kod_f.ToString());
            parameterGroupBox.Text = dbManager.GetValue("formulas", "name_of_formula", "id_of_formula = " + kod_f.ToString())+
                " " +
                dbManager.GetValue("formulas", "description_of_formula", "id_of_formula = " + kod_f.ToString());
            labels = new Label[list_par.Count];
            descriptions = new Label[list_par.Count];
            ids = new int[list_par.Count];
            textBoxes = new TextBox[list_par.Count];
            for (int i = 0; i < list_par.Count; i++)
            {
                labels[i] = new Label();
                labels[i].Name = "label" + i.ToString();
                labels[i].Top = 20 * (i + 1);
                labels[i].Left = 20;
                labels[i].Text = list_par[i][0].ToString();
                labels[i].AutoSize = true;

                descriptions[i] = new Label();
                descriptions[i].Name = "description" + i.ToString();
                descriptions[i].Top = 20 * (i + 1);
                descriptions[i].Left = 160;
                descriptions[i].Text = list_par[i][1].ToString();
                descriptions[i].AutoSize = true;

                ids[i] = Convert.ToInt32(list_par[i][2]);

                textBoxes[i] = new TextBox();
                textBoxes[i].Name = "textBox" + i.ToString();
                textBoxes[i].Top = 20 * (i + 1);
                textBoxes[i].Left = 50;

                parameterGroupBox.Controls.Add(labels[i]);
                parameterGroupBox.Controls.Add(textBoxes[i]);
                parameterGroupBox.Controls.Add(descriptions[i]);
            }
            this.Refresh();
        }

        // метод обработки события нажатия на кнопку "Порахувати"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                parameterNames = new string[textBoxes.Length];
                parameters = new double[textBoxes.Length];
                for(int i = 0; i < textBoxes.Length; i++)
                {
                    parameterNames[i] = textBoxes[i].Name;
                }

                for (int i = 0; i < parameterNames.Length; i++)
                {
                  parameters[i] = Convert.ToDouble(textBoxes[i].Text);
                }

                double res = 0;
                if (kod_f == 1)
                {
                    res = medicalCalculator.getOSTG(
                        parameters[0],
                        parameters[1]);
                }
                else if (kod_f == 2)
                {
                    res = medicalCalculator.getOSTG_2(
                        parameters[0],
                        parameters[1],
                        parameters[2]);
                }
                else if (kod_f == 3)
                {
                    res = medicalCalculator.getPM_GIM(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3]);
                }
                else if (kod_f == 4)
                {
                    res = medicalCalculator.getPM_HCVP(
                        parameters[0],
                        parameters[1]);
                }
                else if (kod_f == 5)
                {
                    res = medicalCalculator.getPM_MI(
                        parameters[0],
                        parameters[1]);
                }
                else if(kod_f == 6)
                {
                    res = medicalCalculator.getBVForMen(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3]);
                }
                else if (kod_f == 7)
                {
                    res = medicalCalculator.getBVForWomen(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3]);
                }
                else if(kod_f == 8)
                {
                    res = medicalCalculator.getNBVForMen(
                        parameters[0]);
                }
                else if(kod_f == 9)
                {
                    res = medicalCalculator.getNBVForWomen(
                        parameters[0]);
                }
                else if(kod_f == 10)
                {
                    res = medicalCalculator.getFV_SSSForMen(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3]);
                }
                else if(kod_f == 11)
                {
                    res = medicalCalculator.getFV_SSSForWomen(
                        parameters[0],
                        parameters[1]);
                }
                string resultString = Convert.ToString(res);
                result.Text = resultString;
                
            }
            catch (FormatException a) {
                result.Text = "0";
                foreach(TextBox t in textBoxes)
                {
                    t.Text = "";
                }

                MessageBox.Show("Неправильні дані");
            }
            
        }

        /* метод обрабатывает событие нажатия кнопки "Зберегти"  
         */
        private void button2_Click(object sender, EventArgs e)
        {
            if (findId())
            {
                dbManager.SetValue("calculations_result", "result", result.Text.Replace(",", "."), "calculation_number = " + seria.Value);

                for (int i = 0; i < parameters.Length; i++)
                {
                    dbManager.SetValue("parameters_value", "parameter_value", parameters[i].ToString(), "calculation_number = " + seria.Value);
                }

                MessageBox.Show("Розрахунок змінен");
            }
            else
            {
                    dbManager.InsertToBD("calculations_result", (seria.Value + ",'" +
                                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + kod_f + "," + result.Text.Replace(",", ".")));
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        dbManager.InsertToBD("parameters_value", seria.Value + "," + ids[i] + "," + parameters[i]);
                    }
                    MessageBox.Show("Розрахунок доданий");
            }
        }

        /*метод проверяет существует ли уже выбранная серия расчетов в бд,
            возвращает true серия существует 
            false если нет
             */
        private bool findId()
        {
            var ids = dbManager.GetRows("calculations_result", "calculation_number", "id_of_formula =" + kod_f.ToString());
            for (int i = 0; i < ids.Count; i++)
            {
                if (seria.Value == Convert.ToInt32(ids[i][0]))
                {
                    return true;
                }
            }

            return false;
        }

        // заполняет поля значениями, если выбранная серия уже существует
        private void seria_ValueChanged(object sender, EventArgs e)
        {
            getValues();   
        }

        // заполняет поля значениями, если выбранная серия уже существует
        private void getValues()
        {
            if (findId())
            {
                result.Text = dbManager.GetValue("calculations_result", "result", "calculation_number = " + seria.Value + " AND id_of_formula = " + kod_f).ToString();
                descBox.Text = dbManager.GetValue("calculations_description", "description_of_calculation", "calculation_number = " + seria.Value).ToString();
                calcName.Text = dbManager.GetValue("calculations_description", "calculation_name", "calculation_number = " + seria.Value).ToString();
            }
            else if (findSeria())
            {
                result.Text = "0";
                descBox.Text = dbManager.GetValue("calculations_description", "description_of_calculation", "calculation_number = " + seria.Value).ToString();
                calcName.Text = dbManager.GetValue("calculations_description", "calculation_name", "calculation_number = " + seria.Value).ToString();
            }
            else
            {
                result.Text = "0";
                calcName.Text = "";
                descBox.Text = "";
            }
        }

        // поиск существующей серии
        private bool findSeria()
        {
            var serias = dbManager.GetRows("calculations_description", "calculation_number", "");
            for(int i = 0; i < serias.Count; i++)
            {
                if(seria.Value == Convert.ToInt32(serias[i][0]))
                {
                    return true;
                }

            }

            return false;
        }

        // добавление новой серии
        private void addSeria_Click(object sender, EventArgs e)
        {
            if (calcName.Text != null & descBox.Text != null)
            {

                dbManager.InsertToBD("calculations_description", seria.Value + ",'" + calcName.Text + "','" + descBox.Text + "'," + findIssueId());
            }
            MessageBox.Show("Розрахунок доданий");
            getValues();
        }

        // изменение описания серии
        private void setSeria_Click(object sender, EventArgs e)
        {
            if (findSeria())
            {
                if (calcName.Text != null & descBox.Text != null)
                {
                    dbManager.SetValue("calculations_description",
                        "calculation_name",
                        "'" + calcName.Text + "'",
                        "calculation_number = " + seria.Value);
                    dbManager.SetValue("calculations_description",
                        "description_of_calculation",
                        "'" + descBox.Text + "'",
                        "calculation_number = " + seria.Value);
                    dbManager.SetValue("calculations_description",
                        "issue_id",
                        findIssueId().ToString(),
                        "calculation_number = " + seria.Value);
                    MessageBox.Show("Серія змінена");
                    getValues();
                }
            }
            else
            {
                MessageBox.Show("Серії не існує");
            }
        }

        private int findIssueId()
        {
            return Convert.ToInt32(dbManager.GetValue("issues", "issue_id", "name = '" + issueList.Text + "'"));
        }
    }
}
