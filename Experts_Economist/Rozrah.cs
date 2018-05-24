using Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Experts_Economist
{
    public partial class Rozrah : Form
    {
        private DBManager db = new DBManager();
        private Calculations calc = new Calculations();
        private MedicalCalculator medCalc = new MedicalCalculator();

        public int id_of_exp;

        public Rozrah()
        {
            InitializeComponent();
        }

        private void Rozrah_Load(object sender, EventArgs e)
        {
            logTb.Text = "";
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "id_of_expert>0 AND id_of_expert<4");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            formulasDGV.AllowUserToAddRows = false;

            //вызываем при первом открытии формы функцию refresh, которая обновляет элементы со списками, таблицу, номер расчета
            Get_values();
        }

        public bool help = true;//если true - ещё не посчитали, false - посчитали

        //функция для забивания данных в список формул, и номера расчета
        private void Get_values()
        {
            if (id_of_exp == 0)
            {
                label10.Visible = true;
                experts_CB.Visible = true;
                experts_CB.SelectedIndex = 0;
            }
            //очищаем списки формул и список id формул
            formulasLB.Items.Clear();
            formulas_idLB.Items.Clear();
            formulasDGV.Rows.Clear();

            //создаем переменную для записи в неё имён формулы, в цикле записываем имена формулы в список
            var obj = db.GetRows("formulas", "name_of_formula", "id_of_expert = " + id_of_exp);
            string item = "";//вспомогательная переменная для хранения имён
            for (int i = 0; i < obj.Count; i++)
            {
                for (int j = 0; j < obj[i].Count; j++)
                {
                    item += obj[i][j];
                }
                formulasLB.Items.Add(item);
                item = "";
            }

            //создаем переменную для записи в неё id формулы, в цикле записываем id формулы в список
            var obj1 = db.GetRows("formulas", "id_of_formula", "id_of_expert = " + id_of_exp);
            item = "";//вспомогательная переменная для хранения id
            for (int i = 0; i < obj1.Count; i++)
            {
                for (int j = 0; j < obj1[i].Count; j++)
                {
                    item += obj1[i][j];
                }
                formulas_idLB.Items.Add(item);
                item = "";
            }
            calc_numbCB.Items.Clear();//очищаем список расчётов
            name_of_seriesCB.Items.Clear();
            //создаём переменную для хранения списка номеров расчётов и забиваем её в список расчётов
            var obj01 = db.GetRows("calculations_description", "calculation_number, calculation_name", "id_of_expert = " + id_of_exp);
            for (int i = 0; i < obj01.Count; i++)
            {
                calc_numbCB.Items.Add(Convert.ToInt32(obj01[i][0]).ToString());
                name_of_seriesCB.Items.Add(obj01[i][1].ToString());
            }
            //функция заполнения таблицы формулами и их параметрами

            //находим максимальный номер расчётов и записываем в ячейку с номером расчетов это число + 1, если расчетов нет, ставим номер расчетов 1
            var obj02 = db.GetRows("calculations_description", "Max(calculation_number)", "id_of_expert = " + id_of_exp);
            try
            {
                calc_numbCB.Text = (Convert.ToInt32(obj02[0][0]) + 1).ToString();
            }
            catch { calc_numbCB.Text = "1"; }

            issueTB.Items.Clear();
            var obj3 = db.GetRows("issues", "*", "");
            var Issues = new List<Issue>();
            foreach (var row in obj3)
            {
                Issues.Add(IssueMapper.Map(row));
            }

            issueTB.Items.AddRange(Issues.ToArray());
            try
            {
                issueTB.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
            try
            {
                formulasLB.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        // при событии Изменение индекса в списке формулы, то есть при выборе формулы чисти таблицу справа и заносим в неё список параметров для дальнейшего подсчета
        private void FormulasLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.formulasDGV.Rows.Clear();//очищаем таблицу
            formulas_idLB.SelectedIndex = formulasLB.SelectedIndex;//ставим выбранное id в соответствии с выбранной формулой
            string idf = formulas_idLB.SelectedItem.ToString();//переменная для хранения id выбранной формулы
            form_desc_L.Text = "Опис формули : " + db.GetValue("formulas", "description_of_formula", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp).ToString();
            if (((Convert.ToInt32(idf) == 4) || (Convert.ToInt32(idf) == 5) || (Convert.ToInt32(idf) == 6) || (Convert.ToInt32(idf) == 11) || (Convert.ToInt32(idf) == 12) || (Convert.ToInt32(idf) == 13) || (Convert.ToInt32(idf) == 15) || (Convert.ToInt32(idf) == 16) || (Convert.ToInt32(idf) == 18) || (Convert.ToInt32(idf) == 19) || (Convert.ToInt32(idf) == 20) || (Convert.ToInt32(idf) == 21) || (Convert.ToInt32(idf) == 23) || (Convert.ToInt32(idf) == 24) || (Convert.ToInt32(idf) == 44)) & id_of_exp == 1)
            {
                Iterations.SelectedIndex = 1;
                Iterations.SelectedIndex = 0;
                if ((Convert.ToInt32(idf) == 4) || (Convert.ToInt32(idf) == 5) || (Convert.ToInt32(idf) == 6))
                    for_i.Text = "Кількість забрудників";
                if ((Convert.ToInt32(idf) == 15) || (Convert.ToInt32(idf) == 16))
                    for_i.Text = "Кількість видів основних фондів";
                if ((Convert.ToInt32(idf) == 18) || (Convert.ToInt32(idf) == 19) || (Convert.ToInt32(idf) == 20) || (Convert.ToInt32(idf) == 21) || (Convert.ToInt32(idf) == 23) || (Convert.ToInt32(idf) == 24))
                    for_i.Text = "Кількість втраченої продукції";
                if ((Convert.ToInt32(idf) == 11) || (Convert.ToInt32(idf) == 12) || (Convert.ToInt32(idf) == 13))
                    for_i.Text = "Кількість постраждалих";
                if (Convert.ToInt32(idf) == 44)
                    for_i.Text = "Кількість установ \n природно-заповідного фонду ";
                for_i.Visible = true;
                Iterations.Visible = true;
                return;
            }
            else
            {
                for_i.Visible = false;
                Iterations.Visible = false;
                this.formulasDGV.Rows.Clear();
            }
            var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);//переменная для хранения списка параментров привязанных к данной формуле
            var obj1 = new List<List<Object>>();//переменная для хранения имени параметра и единиц измерения
            for (int i = 0; i < obj.Count; i++)//в цикле записываем в таблицу имена параметров,пустое поле для ввода значения параметра и единици измерения
            {
                obj1 = db.GetRows("formula_parameters", "name_of_parameter, measurement_of_parameter,description_of_parameter", "id_of_parameter = " + obj[i][0].ToString() + " AND id_of_expert = " + id_of_exp);
                this.formulasDGV.Rows.Add(obj1[0][0].ToString(), "0", obj1[0][1].ToString(), obj1[0][2].ToString());
            }
            help = true;//вспомогательная переменная для проверки наличия строки Result с результатом исчисления
        }

        private void Iterations_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.formulasDGV.Rows.Clear();//очищаем таблицу
            string idf = formulas_idLB.SelectedItem.ToString();//переменная для хранения id выбранной формулы
            int it = Convert.ToInt32(Iterations.Text);
            int obj_items = 0;
            int help1 = 0;
            for (int j = 0; j < it; j++)
            {
                var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);//переменная для хранения списка параметров привязанных к данной формуле
                var obj1 = new List<List<Object>>();//переменная для хранения имени параметра и единиц измерения
                if (Convert.ToInt32(idf) == 15 || Convert.ToInt32(idf) == 16)
                    help1 = 1;
                obj_items = obj.Count - help1;
                for (int i = 0; i < obj_items; i++)//в цикле записываем в таблицу имена параметров,пустое поле для ввода значения параметра и единици измерения
                {
                    if (Convert.ToInt32(obj[i][0]) < 1)
                        continue;
                    obj1 = db.GetRows("formula_parameters", "name_of_parameter, measurement_of_parameter,description_of_parameter", "id_of_parameter = " + obj[i][0].ToString() + " AND id_of_expert = " + id_of_exp);
                    this.formulasDGV.Rows.Add(obj1[0][0].ToString(), "0", obj1[0][1].ToString(), obj1[0][2].ToString());
                }
            }
            if (help1 == 1)
            {
                var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);//переменная для хранения списка параметров привязанных к данной формуле
                var obj1 = db.GetRows("formula_parameters", "name_of_parameter, measurement_of_parameter,description_of_parameter", "id_of_parameter = " + obj[obj_items][0].ToString() + " AND id_of_expert = " + id_of_exp);
                this.formulasDGV.Rows.Add(obj1[0][0].ToString(), "0", obj1[0][1].ToString(), obj1[0][2].ToString());
            }
            help = true;//вспомогательная переменная для проверки наличия строки Result с результатом исчисления
        }

        //событие нажатия на кнопку Зберегти значення та порахувати, смотрит id  формулы и считает по определенным образом, потом записывает в БД значения формулы и параметров если формула ещё не была расчитана в данной серии расчётов
        private void Save_values_Click(object sender, EventArgs e)
        {
            if (help == false)// проверяем есть ли строка с результатом, если есть - удаляем и сбрасываем переменную
            {
                formulasDGV.Rows.RemoveAt(formulasDGV.Rows.Count - 1);
                help = true;
            }

            int idf = Convert.ToInt32(formulas_idLB.SelectedItem);//переменная для хранения id формулы
            double[] h = new double[90];
            try
            {
                for (int i = 0; i < formulasDGV.Rows.Count; i++)
                {
                    h[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                    if (formulasDGV.Rows[i].Cells[1].Value.Equals(""))
                    {
                        MessageBox.Show("Один чи декілька параметрів було введено неправильно");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Один чи декілька параметрів було введено неправильно");
                return;
            }
            if (id_of_exp == 1)
            {
                #region formulas_ekonomist

                switch (idf)//свитч для подсчета формул, общий вид - несколько параметров беруться из ячеек таблицы и потом передаются в функцию подсчета класс Calculation, потом добавляем в таблицу строку с результатом
                {
                    case 1:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 2:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            if (d <= 0)
                            {
                                MessageBox.Show("Сума розрахунків та пасивів не може мати таке значення");
                                return;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Kp(a, b, c, d), "");
                            break;
                        }
                    case 3:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 4:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Mi = new double[it];
                            double[] Npi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Mi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Npi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Mi, Npi), "");
                            break;
                        }
                    case 5:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Mi = new double[it];
                            double[] Npi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Mi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Npi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pc(it, Mi, Npi), "");
                            break;
                        }
                    case 6:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Mi = new double[it];
                            double[] Npi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Mi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Npi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Prv(it, Mi, Npi), "");
                            break;
                        }
                    case 7:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            int c = Convert.ToInt32(formulasDGV.Rows[2].Cells[1].Value);
                            int d = Convert.ToInt32(formulasDGV.Rows[3].Cells[1].Value);
                            double f = Convert.ToDouble(formulasDGV.Rows[4].Cells[1].Value);
                            if (c <= 0 || d <= 0)
                            {
                                MessageBox.Show("Неправильні значення Tр чи Тт");
                                return;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.E(a, b, c, d, f), "");
                            break;
                        }
                    case 8:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 9:
                        {
                            double[] Mr = new double[7];
                            for (int i = 0; i < 7; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 7), "");
                            break;
                        }
                    case 10:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 11:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Ml = new double[it];
                            double[] Nl = new double[it];
                            double[] Mt = new double[it];
                            double[] Nt = new double[it];
                            double[] Mi = new double[it];
                            double[] Ni = new double[it];
                            double[] Mz = new double[it];
                            double[] Nz = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Ml[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Nl[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Mt[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Nt[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Mi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Ni[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Mz[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Nz[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Vtrr(it, Ml, Nl, Mt, Nt, Mi, Ni, Mz, Nz), "");
                            break;
                        }
                    case 12:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Mdp = new double[it];
                            double[] Nz = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Mdp[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Nz[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Mdp, Nz), "");
                            break;
                        }
                    case 13:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Mdp = new double[it];
                            double[] Nz = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Mdp[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Nz[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Vtg(it, Mdp, Nz), "");
                            break;
                        }
                    case 14:
                        {
                            double[] Mr = new double[6];
                            for (int i = 0; i < 6; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 6), "");
                            break;
                        }
                    case 15:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Pi = new double[it];
                            double[] Li = new double[it];
                            double Lv = Convert.ToDouble(formulasDGV.Rows[it * 2].Cells[1].Value);
                            for (int i = 0; i < it; i++)
                            {
                                Pi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Li[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Fg(it, Pi, Li, Lv), "");
                            break;
                        }
                    case 16:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Pi = new double[it];
                            double[] Li = new double[it];
                            double Lv = Convert.ToDouble(formulasDGV.Rows[it * 2].Cells[1].Value);
                            for (int i = 0; i < it; i++)
                            {
                                Pi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Li[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Fg(it, Pi, Li, Lv), "");
                            break;
                        }
                    case 17:
                        {
                            double[] Mr = new double[2];
                            for (int i = 0; i < 2; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 2), "");
                            break;
                        }
                    case 18:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Ci = new double[it];
                            double[] qi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Ci[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Ci, qi), "");
                            break;
                        }
                    case 19:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Tci = new double[it];
                            double[] qi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Tci[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Tci, qi), "");
                            break;
                        }
                    case 20:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Si = new double[it];
                            double[] Ki = new double[it];
                            double[] Ui = new double[it];
                            double[] Tci = new double[it];
                            double[] Zi_dod = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Si[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Ki[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Ui[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Tci[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Zi_dod[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Prc(it, Si, Ki, Ui, Tci, Zi_dod), "");
                            break;
                        }
                    case 21:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Tci_ser = new double[it];
                            double[] qi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Tci_ser[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Tci_ser, qi), "");
                            break;
                        }
                    case 22:
                        {
                            double[] Mr = new double[2];
                            for (int i = 0; i < 2; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 2), "");
                            break;
                        }
                    case 23:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Tci = new double[it];
                            double[] qi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Tci[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pvc(it, Tci, qi), "");
                            break;
                        }
                    case 24:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Pi = new double[it];
                            double[] Ki = new double[it];
                            double[] ki = new double[it];
                            double[] qi = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Pi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Ki[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                ki[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mdg_o(it, Pi, Ki, ki, qi), "");
                            break;
                        }
                    case 25:
                        {
                            double[] Mr = new double[2];
                            for (int i = 0; i < 2; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 2), "");
                            break;
                        }
                    case 26:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rsg1(a, b), "");
                            break;
                        }
                    case 27:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rsg2(a, b, c), "");
                            break;
                        }
                    case 28:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rsg1(a, b), "");
                            break;
                        }
                    case 29:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 30:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rlg1(a, b, c), "");
                            break;
                        }
                    case 31:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rlg2(a, b, c), "");
                            break;
                        }
                    case 32:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rlg3(a, b, c, d), "");
                            break;
                        }
                    case 33:
                        {
                            double[] Mr = new double[6];
                            for (int i = 0; i < 6; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 6), "");
                            break;
                        }
                    case 34:
                        {
                            double[] Mr = new double[7];
                            for (int i = 0; i < 7; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.N(Mr), "");
                            break;
                        }
                    case 35:
                        {
                            double[] Mr = new double[6];
                            for (int i = 0; i < 6; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.N1(Mr), "");
                            break;
                        }
                    case 36:
                        {
                            double[] Mr = new double[6];
                            for (int i = 0; i < 6; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.N2(Mr), "");
                            break;
                        }
                    case 37:
                        {
                            double[] Mr = new double[5];
                            for (int i = 0; i < 5; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.N3(Mr), "");
                            break;
                        }
                    case 38:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rsg1(a, b), "");
                            break;
                        }
                    case 39:
                        {
                            double[] Mr = new double[7];
                            for (int i = 0; i < 7; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.N5(Mr), "");
                            break;
                        }
                    case 40:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", calc.Rsg1(a, b), "");
                            break;
                        }
                    case 41:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 42:
                        {
                            double[] Mr = new double[2];
                            for (int i = 0; i < 2; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 2), "");
                            break;
                        }
                    case 43:
                        {
                            double[] Mr = new double[3];
                            for (int i = 0; i < 3; i++)
                            {
                                Mr[i] = Convert.ToDouble(formulasDGV.Rows[i].Cells[1].Value);
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Mr(Mr, 3), "");
                            break;
                        }
                    case 44:
                        {
                            int it = Convert.ToInt32(Iterations.Text);
                            int j = 0;
                            double[] Qi = new double[it];
                            double[] Qi_p = new double[it];
                            for (int i = 0; i < it; i++)
                            {
                                Qi[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                                Qi_p[i] = Convert.ToDouble(formulasDGV.Rows[j].Cells[1].Value);
                                j++;
                            }
                            this.formulasDGV.Rows.Add("Result", calc.Pz(it, Qi, Qi_p), "");
                            break;
                        }
                }

                #endregion formulas_ekonomist
            }
            else if (id_of_exp == 3)
            {
                #region formulas_medic
                switch (idf)//свитч для подсчета формул, общий вид - несколько параметров беруться из ячеек таблицы и потом передаются в функцию подсчета класс Calculation, потом добавляем в таблицу строку с результатом
                {
                    case 1:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getOSTG(a, b), "");
                            break;
                        }
                    case 2:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getOSTG_2(a, b, c), "");
                            break;
                        }
                    case 3:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getPM_GIM(a, b, c, d), "");
                            break;
                        }
                    case 4:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getPM_MI(a, b), "");
                            break;
                        }
                    case 5:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getPM_HCVP(a, b), "");
                            break;
                        }
                    case 6:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getBVForMen(a, b, c, d), "");
                            break;
                        }
                    case 7:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getBVForWomen(a, b, c, d), "");
                            break;
                        }
                    case 8:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getNBVForMen(a), "");
                            break;
                        }
                    case 9:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getNBVForWomen(a), "");
                            break;
                        }
                    case 10:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            double c = Convert.ToDouble(formulasDGV.Rows[2].Cells[1].Value);
                            double d = Convert.ToDouble(formulasDGV.Rows[3].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getFV_SSSForMen(a, b, c, d), "");
                            break;
                        }
                    case 11:
                        {
                            double a = Convert.ToDouble(formulasDGV.Rows[0].Cells[1].Value);
                            double b = Convert.ToDouble(formulasDGV.Rows[1].Cells[1].Value);
                            this.formulasDGV.Rows.Add("Result", medCalc.getFV_SSSForWomen(a, b), "");
                            break;
                        }
                }
                #endregion formulas_medic
            }
            else
            {
                MessageBox.Show("Для цього експерта немає розрахунків");
                help = false;
                return;
            }
            //проверка введён ли корректный номер расчётной серии
            if (calc_numbCB.Text == "" || calc_numbCB.Text == "0")
            {
                var obj2 = db.GetRows("calculations_description", "Max(calculation_number)", "id_of_expert = " + id_of_exp);
                if (obj2.Count == 1)
                    calc_numbCB.Text = "1";
                else
                    calc_numbCB.Text = (Convert.ToInt32(obj2[0][0]) + 1).ToString();
            }

            if (name_of_seriesCB.Text == "")
            {
                MessageBox.Show("Введіть ім'я для серії");
                help = false;
                return;
            }

            //создаём переменные для хранения номера расчётной серии, времени расчёта, id формулы и результата и записываем это всё в БД
            DateTime localDate = DateTime.Now;
            string[] fields5 = { "calculation_number", "date_of_calculation", "id_of_formula", "result", "id_of_expert" };
            string[] values5 = { calc_numbCB.Text, "'" + localDate.ToString("yyyy-MM-dd HH:mm:ss") + "'", idf.ToString(), formulasDGV.Rows[formulasDGV.Rows.Count - 1].Cells[1].Value.ToString().Replace(",", "."), id_of_exp.ToString() };
            int issueid = (issueTB.SelectedItem as Issue).id;
            string[] fields4_1 = { "calculation_number", "calculation_name", "description_of_calculation", "issue_id", "id_of_expert" };
            string[] values4_1 = { calc_numbCB.Text, "'" + name_of_seriesCB.Text.Replace('\'', '`') + "'", "'" + desc_of_seriesTB.Text.Replace('\'', '`') + "'", issueid.ToString(), id_of_exp.ToString() };
            try
            {
                db.InsertToBD("calculations_description", fields4_1, values4_1);
            }
            catch (Exception)
            {
            }
            try
            {
                db.InsertToBD("calculations_result", fields5, values5);
            }
            catch (MySqlException ex)// ловим эксепшн mysql если идёт дупликация ключа
            {
                //MYSQL_DUPLICATE_PK = 1062;
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ця формула вже була розрахована у данній серії \nЗмінити ці значення ви можете у вкладці 'Перегляд результатів' ");
                    help = false;
                    return;
                }
                else if (ex.Number == 1452)
                {
                    MessageBox.Show("Серія з таким ім'ям вже існує, виберіть її з списку серій");
                    help = false;
                    return;
                }
                else
                    throw ex;
            }
            // по аналогии с функцие записи результатов формулы записываем значения параметров в БД
            // для формул с сумой записываем по другому алгоритму
            if (((Convert.ToInt32(idf) == 4) || (Convert.ToInt32(idf) == 5) || (Convert.ToInt32(idf) == 6) || (Convert.ToInt32(idf) == 11) || (Convert.ToInt32(idf) == 12) || (Convert.ToInt32(idf) == 13) || (Convert.ToInt32(idf) == 15) || (Convert.ToInt32(idf) == 16) || (Convert.ToInt32(idf) == 18) || (Convert.ToInt32(idf) == 19) || (Convert.ToInt32(idf) == 20) || (Convert.ToInt32(idf) == 21) || (Convert.ToInt32(idf) == 23) || (Convert.ToInt32(idf) == 24) || (Convert.ToInt32(idf) == 44)) & id_of_exp == 1)
            {
                //переменная для хранения значения i - количества итераций
                int it = Convert.ToInt32(Iterations.Text);
                //список id параметров данной формулы
                var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                //первый параметр i - количество итераций
                string[] fields5_1 = { "calculation_number", "id_of_parameter", "parameter_value", "index_of_parameter", "id_of_expert", "id_of_formula" };
                string[] values5_1 = { calc_numbCB.Text, obj[0][0].ToString(), it.ToString(), "0", id_of_exp.ToString(), idf.ToString() };
                db.InsertToBD("parameters_value", fields5_1, values5_1);
                //переменная для хранения количества параметров у формулы
                int obj_items = obj.Count;
                //вспомогательная  переменная, 1 для обычных сумм, 2 для сумм с дополнительными параметрами
                int s = 1;
                //если 4 параметра( i, два для сумы и 1 вне сумы) ставим s=2
                if (obj_items == 4)
                    s = 2;
                //в цикле начиная с 1 посколько i первый параметр и до obj_items-s количества параметров записываем в БД значения параметров
                for (int i = 1; i < (obj_items - s + 1); i++)
                {
                    //переменная для хранения индекса параметров
                    int iter = 1;
                    //id параметра
                    values5_1[1] = obj[i][0].ToString();
                    //в цикле начиная с первого (i-1) - места i-го параметра и до it * (obj_items - s) - последннего места i-го параметра
                    //шаг - j + obj_items (количество переменных) - s
                    for (int j = (i - 1); j < (it * (obj_items - s)); j = j + obj_items - s)
                    {
                        values5_1[2] = formulasDGV.Rows[j].Cells[1].Value.ToString().Replace(",", ".");
                        values5_1[3] = iter.ToString();
                        db.InsertToBD("parameters_value", fields5_1, values5_1);
                        iter++;
                    }
                }
                if (s == 2)
                {
                    values5_1[1] = obj[obj_items - 1][0].ToString();
                    values5_1[2] = formulasDGV.Rows[it * 2].Cells[1].Value.ToString().Replace(",", ".");
                    values5_1[3] = "0";
                    db.InsertToBD("parameters_value", fields5_1, values5_1);
                }
            }
            else
            {
                var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                string[] fields6 = { "calculation_number", "id_of_parameter", "parameter_value", "index_of_parameter", "id_of_expert", "id_of_formula" };
                string[] values6 = { calc_numbCB.Text, "", "", "0", id_of_exp.ToString(), idf.ToString() };
                for (int i = 0; i < obj.Count; i++)
                {
                    values6[1] = obj[i][0].ToString();
                    values6[2] = formulasDGV.Rows[i].Cells[1].Value.ToString().Replace(",", ".");
                    db.InsertToBD("parameters_value", fields6, values6);
                    //  MessageBox.Show();
                }
            }
            help = false;

            logTb.Text += formulasLB.SelectedItem.ToString() + " = " + formulasDGV.Rows[formulasDGV.Rows.Count - 1].Cells[1].Value.ToString() + "\n";
        }

        //событие ведения мышки по списку формул, при наведении на формулу показываем подсказку из БД по формуле
        private void formulasLB_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";//переменная для хранения сообщения подсказки

            //смотрим на каком месте указатель, считываем id формулы и делаем запрос в БД для изъятия подсказки
            int nIdx = formulasLB.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < formulasLB.Items.Count))
            {
                string idf = formulas_idLB.Items[nIdx].ToString();
                var obj2 = db.GetRows("formulas", "description_of_formula", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                strTip = obj2[0][0].ToString();
            }
            toolTip1.SetToolTip(formulasLB, strTip);
        }

        //событие нажатия клавиши в окне серии расчётов, проверяем на правильность, разрешаем вводить только цифры и только 1 точку
        private void rozrah_numbTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //та же самая проверка только для второй колонке таблицы - колонки значений компонентов
        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        //событие редактирования ячейки, через него вызываем событие нажатия кнопки для 2 колонки(проверка)
        private void formulasDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            if (formulasDGV.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
        }

        private void Iterations_VisibleChanged(object sender, EventArgs e)
        {
            Iterations.SelectedIndex = 0;
        }

        private void series_over_Click(object sender, EventArgs e)
        {
            //Сохраняем название и описание серии расчётов
            int issueid = (issueTB.SelectedItem as Issue).id;
            string[] fields4_1 = { "calculation_number", "calculation_name", "description_of_calculation", "issue_id", "id_of_expert" };
            string[] values4_1 = { calc_numbCB.Text, "'" + name_of_seriesCB.Text.Replace('\'', '`') + "'", "'" + desc_of_seriesTB.Text.Replace('\'', '`') + "'", issueid.ToString(), id_of_exp.ToString() };
            try
            {
                db.UpdateRecord("calculations_description", fields4_1, values4_1);
            }
            catch (MySqlException)// ловим эксепшн mysql если идёт дупликация ключа
            {
                MessageBox.Show("Ця серія вже була описана \nЗмінити ці значення ви можете у вкладці 'Перегляд результатів' ");
                // MessageBox.Show(eboi.ToString());
                help = false;
                return;
            }

            calc_numbCB.Text = (Convert.ToInt32(calc_numbCB.Text) + 1).ToString();
            if (formulasLB.Items.Count > 0)
            {
                formulasLB.SelectedIndex = 1;
                formulasLB.SelectedIndex = 0;
            }
            name_of_seriesCB.Text = "";
            desc_of_seriesTB.Clear();

        }

        private void calc_numbCB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                desc_of_seriesTB.Clear();// очищаем поле описания расчёта
                string idc = calc_numbCB.Text;//переменная для хранения id расчёта
                //переменная для хранения имени и описания расчёта
                var calc = db.GetRows("calculations_description", "calculation_name,description_of_calculation,issue_id", "calculation_number = " + idc + " AND id_of_expert = " + id_of_exp);
                //заполняем поля соответственно
                if (calc.Count > 0)
                {
                    name_of_seriesCB.SelectedIndex = name_of_seriesCB.FindString(calc[0][0].ToString());
                }
                else
                {
                    name_of_seriesCB.Text = "";
                }
                desc_of_seriesTB.Text = calc[0][1].ToString();
                for (int i = 0; i < issueTB.Items.Count; i++)
                {
                    if ((issueTB.Items[i] as Issue).id == Convert.ToInt32(calc[0][2]))
                        issueTB.SelectedIndex = i;
                }
            }
            catch (Exception)
            {
            }
            if (calc_numbCB.Text == "")
                calc_numbCB.Text = prev_calc_numb;
        }

        public string prev_calc_numb = "";

        //проверка ввода номера серии расчётов
        private void calc_numbCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            prev_calc_numb = calc_numbCB.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void experts_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_of_exp = (experts_CB.Items[experts_CB.SelectedIndex] as Expert).id;
            //вызываем при первом открытии формы функцию refresh, которая обновляет элементы со списками, таблицу, номер расчета
            Get_values();
        }

        private void name_of_seriesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var calc = db.GetRows("calculations_description", "calculation_number", "calculation_name = '" + name_of_seriesCB.Text.Replace('\'', '`') + "' AND id_of_expert = " + id_of_exp);
                if (calc_numbCB.Text == calc[0][0].ToString())
                {
                    return;
                }
                calc_numbCB.SelectedIndex = calc_numbCB.FindString(calc[0][0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void formulasDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex >= 0) && (e.RowIndex < formulasDGV.Rows.Count))
                {
                    var cell = formulasDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = formulasDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTb.Text = "";
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "id_of_expert>0 AND id_of_expert<4");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            formulasDGV.AllowUserToAddRows = false;

            Get_values();
        }

        private void showLog_Click(object sender, EventArgs e)
        {
            logL.Visible = !logL.Visible;
            logTb.Visible = !logTb.Visible;
        }
    }
}