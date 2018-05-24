using Data;
using MedicForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Experts_Economist
{
    public partial class Result : Form
    {  //используем библиотеки работы с БД и формулами
        private DBManager db = new DBManager();
        private Calculations calc = new Calculations();
        private MedicalCalculator medCalc = new MedicalCalculator();

        public int id_of_exp;
        public int idOfViewedExpert;

        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "id_of_expert>0 AND id_of_expert<4");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            //функция для забивания данных в таблицу с формулами и параметрами, их значениями и номера расчётов
            idOfViewedExpert = id_of_exp;
            for (int i = 0; i < experts_CB.Items.Count; i++)
            {
                if ((experts_CB.Items[i] as Expert).id == idOfViewedExpert)
                    experts_CB.SelectedIndex = i;
            }
        }

        //функция для забивания данных в таблицу с формулами и параметрами, их значениями и номера расчётов
        private void get_values()
        {
            if (id_of_exp == 0 && id_of_exp == 4 && id_of_exp == 5)
            {
                experts_CB.SelectedIndex = 0;
            }
            calc_numbCB.Items.Clear();//очищаем список расчётов
            name_of_seriesCB.Items.Clear();
            name_of_seriesCB.Text = "";
            //создаём переменную для хранения списка номеров расчётов и забиваем её в список расчётов
            var obj01 = db.GetRows("calculations_description", "calculation_number, calculation_name", "id_of_expert = " + idOfViewedExpert);
            for (int i = 0; i < obj01.Count; i++)
            {
                calc_numbCB.Items.Add(Convert.ToInt32(obj01[i][0]).ToString());
                name_of_seriesCB.Items.Add(obj01[i][1].ToString());
            }
            //если есть номера расчётов выставляем первый
            if (calc_numbCB.Items.Count > 0)
                calc_numbCB.SelectedIndex = 0;
            //функция заполнения таблицы формулами и их параметрами
            get_grid();
        }

        //функция заполнения таблицы формулами и их параметрами
        private void get_grid()
        {
            try
            {
                DGV.Rows.Clear();//очищаем таблицу

                string idc = calc_numbCB.SelectedItem.ToString();//переменная для хранения id расчёта
                var iof_res = db.GetRows("calculations_result", "id_of_formula,result", "calculation_number = " + idc + " AND id_of_expert = " + idOfViewedExpert);//переменная для хранения id формулы и результата
                var nof = new List<List<Object>>();//список имён формулы
                var nop = new List<List<Object>>();//список имён параметра
                var pv = new List<List<Object>>();//список значений параметра
                var hpv = new List<List<Object>>();//в hpv храним значение i - количества итераций
                var iop = new List<List<Object>>(); //храним id параметров

                int t = 0;//переменная для уравнений с суммой и дополнительными параметрами, отвечает за количество параметров после суммы
                for (int i = 0; i < iof_res.Count; i++)
                {
                    //в 15 и 16 формуле после суммы идёт ещё один параметр, t - условно количество параметров после сумы
                    if (Convert.ToInt32(iof_res[i][0]) == 15 || Convert.ToInt32(iof_res[i][0]) == 16)
                    {
                        t = 1;
                    }
                    nof = db.GetRows("formulas", "name_of_formula,measurement_of_formula", "id_of_formula = " + iof_res[i][0].ToString() + " AND id_of_expert = " + idOfViewedExpert);
                    //добавляем в таблицу формулу и значения и подписываем, в скрытой ячейке указываем что это формула
                    this.DGV.Rows.Add("Формула " + nof[0][0].ToString(), iof_res[i][1].ToString(), iof_res[i][0].ToString(), "id_of_formula", "", nof[0][1].ToString());
                    //список id параметров по данной формуле
                    iop = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + iof_res[i][0].ToString() + " AND id_of_expert = " + idOfViewedExpert);
                    //для сумовых уравнений у нас id первого параметра (i - количество итераций) равно 0, такие уравнения записываються по другому - сначала все итерации а потом кол-во итераций
                    if (Convert.ToInt32(iop[0][0]) == 0)
                    {
                        hpv = db.GetRows("parameters_value", "parameter_value", "calculation_number = " + idc + " AND id_of_parameter = " + iop[0][0].ToString() + " AND id_of_expert = " + idOfViewedExpert + " AND id_of_formula = " + iof_res[i][0].ToString());
                        //первый цикл - для количества итераций, начинаем с 1 потому что номера начинаются с 1, соответственно к концу также прибавляем 1
                        for (int k = 1; k < (Convert.ToInt32(hpv[0][0].ToString()) + 1); k++)
                        {
                            //второй цикл для переменных в одной итерации,начинаем цикл с 1, потому что 0 член списка - параметр i, его мы отображаем в конце
                            for (int j = 1; j < iop.Count - t; j++)
                            {
                                pv = db.GetRows("parameters_value", "parameter_value", "calculation_number = " + idc + " AND id_of_parameter = " + iop[j][0].ToString() + " AND index_of_parameter = " + k.ToString() + " AND id_of_expert = " + idOfViewedExpert + " AND id_of_formula = " + iof_res[i][0].ToString());
                                nop = db.GetRows("formula_parameters", "name_of_parameter,measurement_of_parameter", "id_of_parameter = " + iop[j][0].ToString() + " AND id_of_expert = " + idOfViewedExpert);
                                //добавляем в таблицу параметр и значения и подписываем, в скрытой ячейке указываем что это параметр, его id и индекс
                                this.DGV.Rows.Add("Параметр " + nop[0][0].ToString(), pv[0][0].ToString(), iop[j][0].ToString(), "id_of_parameter", k, nop[0][1].ToString(), iof_res[i][0].ToString());
                            }
                        }
                        //если есть параметры после сумы записываем их перед индексом, предпоследними
                        if (t > 0)
                        {
                            pv = db.GetRows("parameters_value", "parameter_value", "calculation_number = " + idc + " AND id_of_parameter = " + iop[iop.Count - 1][0].ToString() + " AND index_of_parameter = " + 0 + " AND id_of_expert = " + idOfViewedExpert + " AND id_of_formula = " + iof_res[i][0].ToString());
                            nop = db.GetRows("formula_parameters", "name_of_parameter,measurement_of_parameter", "id_of_parameter = " + iop[iop.Count - 1][0].ToString() + " AND id_of_expert = " + idOfViewedExpert);
                            this.DGV.Rows.Add("Параметр " + nop[0][0].ToString(), pv[0][0].ToString(), iop[iop.Count - 1][0].ToString(), "id_of_parameter", "0", nop[0][1].ToString(), iof_res[i][0].ToString());
                        }
                        //в конце добалвяем отдельно параметр i
                        this.DGV.Rows.Add("Параметр " + "i", hpv[0][0].ToString(), iop[0][0].ToString(), "index", "0", "", iof_res[i][0].ToString());
                        //p++;
                        t = 0;
                    }
                    //считывание результатов для обычных формул
                    else
                    {
                        for (int j = 0; j < iop.Count; j++)
                        {
                            pv = db.GetRows("parameters_value", "parameter_value,index_of_parameter", "calculation_number = " + idc + " AND id_of_parameter = " + iop[j][0].ToString() + " AND index_of_parameter = " + 0 + " AND id_of_expert = " + idOfViewedExpert + " AND id_of_formula = " + iof_res[i][0].ToString());
                            nop = db.GetRows("formula_parameters", "name_of_parameter,measurement_of_parameter", "id_of_parameter = " + iop[j][0].ToString() + " AND id_of_expert = " + idOfViewedExpert);

                            //добавляем в таблицу параметр и значения и подписываем, в скрытой ячейке указываем что это параметр
                            this.DGV.Rows.Add("Параметр " + nop[0][0].ToString(), pv[0][0].ToString(), iop[j][0].ToString(), "id_of_parameter", pv[0][1], nop[0][1].ToString(), iof_res[i][0].ToString());
                        }
                    }
                }
                //для всех формул выделяем жирным шрифтом
                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    if (DGV.Rows[i].Cells[3].Value.ToString() == "id_of_formula")
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.Font = new Font(DGV.Font, FontStyle.Bold);
                        DGV.Rows[i].DefaultCellStyle = style;
                    }
                }
            }
            catch (Exception)
            { }

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
                desc_of_seriesTB.Clear();// очищаем поле описания расчёта
                string idc = calc_numbCB.SelectedItem.ToString();//переменная для хранения id расчёта
                //переменная для хранения имени и описания расчёта
                var calc = db.GetRows("calculations_description", "calculation_name,description_of_calculation,issue_id", "calculation_number = " + idc + " AND id_of_expert = " + idOfViewedExpert);
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
            { }
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

        //при выборе номера расчётов обновляет таблицу
        private void calc_numbCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_grid();
        }

        public double prev_value = 0;

        //приверка правильности ввода в 2 колонке таблицы, событие открытия режима редактироваия колонки вызывает событие нажатия на клавиши Column2_KeyPress
        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            prev_value = Convert.ToDouble(DGV.CurrentCell.Value);
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);

            if (DGV.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
        }

        //событие нажатия клавиши в окне серии расчётов, проверяем на правильность, разрешаем вводить только цифры и только 1 точку

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-') && (!DGV.Rows[DGV.CurrentCell.RowIndex].Cells[3].Value.ToString().Equals("id_of_formula")))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1) && (DGV.Rows[DGV.CurrentCell.RowIndex].Cells[3].Value.ToString() != "id_of_formula"))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1) && (DGV.Rows[DGV.CurrentCell.RowIndex].Cells[3].Value.ToString() != "id_of_formula"))
            {
                e.Handled = true;
            }
        }

        //событие отжатия клавиши, проверяем что пользователь нажал кнопку delete на строке содержащей формулу и если это так то удаляем расчитанные значения формулы и соотвествующие расчитанные параметры
        private void DGV_KeyUp(object sender, KeyEventArgs e)
        {//проверка
            if (e.KeyCode == Keys.Delete && DGV.Rows[DGV.CurrentCell.RowIndex].Cells[3].Value.ToString() == "id_of_formula" && Panel_redakt.BackColor == Color.LightGreen)
            {//переменная для хранения id формулы и номера расчёта
                string idf = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[2].Value.ToString();
                string idc = "";
                try
                {
                    idc = calc_numbCB.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Невірна серія розрахунків");
                }
                //переменные для удаления, первая - поля, вторая - значения
                string[] fields2 = { "calculation_number ", "id_of_formula", "id_of_expert" };
                string[] values2 = { idc, idf, idOfViewedExpert.ToString() };
                //удаляем из БД значения по формуле
                db.DeleteFromDB("calculations_result", fields2, values2);

                //id параметра
                var iop = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + idOfViewedExpert);
                int b = 0;
                //для формул с сумами отдельный алгоритм удаления
                if ((Convert.ToInt32(idf) == 4) || (Convert.ToInt32(idf) == 5) || (Convert.ToInt32(idf) == 6) || (Convert.ToInt32(idf) == 11) || (Convert.ToInt32(idf) == 12) || (Convert.ToInt32(idf) == 13) || (Convert.ToInt32(idf) == 15) || (Convert.ToInt32(idf) == 16) || (Convert.ToInt32(idf) == 18) || (Convert.ToInt32(idf) == 19) || (Convert.ToInt32(idf) == 20) || (Convert.ToInt32(idf) == 21) || (Convert.ToInt32(idf) == 23) || (Convert.ToInt32(idf) == 24) || (Convert.ToInt32(idf) == 44))
                {
                    string[] fields3_1 = { "calculation_number ", "id_of_parameter", "id_of_expert", "id_of_formula" };
                    string[] values3_1 = { idc, iop[0][0].ToString(), idOfViewedExpert.ToString(), idf.ToString() };
                    db.DeleteFromDB("parameters_value", fields3_1, values3_1);
                    b = 1;
                }
                for (int i = b; i < iop.Count; i++) //в цикле удаляем значения параметров по формуле
                {
                    string[] fields3_2 = { "calculation_number ", "id_of_parameter", "id_of_expert", "id_of_formula" };
                    string[] values3_2 = { idc, iop[i][0].ToString(), idOfViewedExpert.ToString(), idf.ToString() };
                    db.DeleteFromDB("parameters_value", fields3_2, values3_2);
                }
                //обновляем таблицу и список расчётов

                get_values();
                calc_numbCB.SelectedItem = idc;
            }
        }

        //при изменении значений параметров пересчитываем формулу и обновляем БД
        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //выполняем в другом потоке асинхронно
            this.BeginInvoke(new MethodInvoker(() =>
            {
                double h = 0;
                try
                {
                    h = Convert.ToDouble(DGV.Rows[e.RowIndex].Cells[1].Value);
                    if (DGV.Rows[e.RowIndex].Cells[1].Value.Equals(""))
                    {
                        MessageBox.Show("Один чи декілька параметрів було введено неправильно");
                        DGV.Rows[e.RowIndex].Cells[1].Value = prev_value;
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Один чи декілька параметрів було введено неправильно");
                    DGV.Rows[e.RowIndex].Cells[1].Value = prev_value;
                    return;
                }

                //переменная для хранения id параметра
                string idp = DGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (DGV.Rows[e.RowIndex].Cells[3].Value.ToString() == "id_of_parameter")//проверяем что меняем параметр

                {//переменные для хранения полей изменения и параметров
                    string[] fields2 = { "id_of_parameter", "parameter_value" };
                    string[] values2 = { idp + " AND calculation_number = " + calc_numbCB.Text + " AND index_of_parameter = " + DGV.Rows[e.RowIndex].Cells[4].Value.ToString() + " AND id_of_expert = " + idOfViewedExpert + " AND id_of_formula = " + DGV.Rows[e.RowIndex].Cells[6].Value.ToString(), DGV.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(",", ".") };
                    db.UpdateRecord("parameters_value", fields2, values2);//обновляем значения параметров
                    //считваем текущий индекс и идём к началу списка пока не найдём строку, в которой записана формула
                    for (int i = e.RowIndex; i >= 0; i--)
                    {//переменная для хранения id формулы
                        string idf = DGV.Rows[i].Cells[2].Value.ToString();
                        if (DGV.Rows[i].Cells[3].Value.ToString() == "id_of_formula")//нашли формулу
                        {
                            if (id_of_exp == 1)
                            {
                                switch (Convert.ToInt32(idf))
                                {//свитч для подсчёта значения формулы, общий вид - записываем значения параметров в переменные, передаём их в функции класса Calculations, пересчитываем, обновляем БД
                                    case 1:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 2:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            if (d <= 0)
                                            {
                                                MessageBox.Show("Сума розрахунків та пасивів не може мати таке значення");
                                                return;
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Kp(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 3:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 4:
                                        {//для формул с сумой сначала идём к концу параметров и находим i - количество итераций, от него движемся вверх и по количеству итераций считываем параметры
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Prv(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            int c = Convert.ToInt32(DGV.Rows[i + 3].Cells[1].Value);
                                            int d = Convert.ToInt32(DGV.Rows[i + 4].Cells[1].Value);
                                            double f = Convert.ToDouble(DGV.Rows[i + 5].Cells[1].Value);
                                            if (c <= 0 || d <= 0)
                                            {
                                                MessageBox.Show("Неправильні значення Tр чи Тт");
                                                return;
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.E(a, b, c, d, f).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 8:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 9:
                                        {
                                            double[] Mr = new double[7];
                                            for (int s = 0; s < 7; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 7).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 10:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 11:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Ml = new double[it];
                                                    double[] Nl = new double[it];
                                                    double[] Mt = new double[it];
                                                    double[] Nt = new double[it];
                                                    double[] Mi = new double[it];
                                                    double[] Ni = new double[it];
                                                    double[] Mz = new double[it];
                                                    double[] Nz = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Nz[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mz[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Ni[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Nt[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mt[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Nl[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Ml[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Vtrr(it, Ml, Nl, Mt, Nt, Mi, Ni, Mz, Nz).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 12:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 13:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Vtg(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 14:
                                        {
                                            double[] Mr = new double[6];
                                            for (int s = 0; s < 6; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 6).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 15:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    double Lv = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                    iter--;
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Fg(it, Mi, Npi, Lv).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 16:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    double Lv = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                    iter--;
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Fg(it, Mi, Npi, Lv).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 17:
                                        {
                                            double[] Mr = new double[2];
                                            for (int s = 0; s < 2; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 2).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 18:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 19:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 20:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Si = new double[it];
                                                    double[] Ki = new double[it];
                                                    double[] Ui = new double[it];
                                                    double[] Tci = new double[it];
                                                    double[] Zi_dod = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Zi_dod[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Tci[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Ui[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Ki[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Si[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Prc(it, Si, Ki, Ui, Tci, Zi_dod).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 21:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Mi = new double[it];
                                                    double[] Npi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Npi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Mi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Mi, Npi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 22:
                                        {
                                            double[] Mr = new double[2];
                                            for (int s = 0; s < 2; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 2).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 23:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Tci = new double[it];
                                                    double[] qi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        qi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Tci[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pvc(it, Tci, qi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 24:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Pi = new double[it];
                                                    double[] Ki = new double[it];
                                                    double[] ki = new double[it];
                                                    double[] qi = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Pi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Ki[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        ki[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        qi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mdg_o(it, Pi, Ki, ki, qi).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 25:
                                        {
                                            double[] Mr = new double[2];
                                            for (int s = 0; s < 2; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 2).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 26:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rsg1(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 27:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rsg2(a, b, c).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 28:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rsg1(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 29:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 30:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rlg1(a, b, c).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 31:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rlg2(a, b, c).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 32:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rlg3(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 33:
                                        {
                                            double[] Mr = new double[6];
                                            for (int s = 0; s < 6; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 6).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 34:
                                        {
                                            double[] Mr = new double[7];
                                            for (int s = 0; s < 7; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.N(Mr).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 35:
                                        {
                                            double[] Mr = new double[6];
                                            for (int s = 0; s < 6; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.N1(Mr).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 36:
                                        {
                                            double[] Mr = new double[6];
                                            for (int s = 0; s < 6; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.N2(Mr).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 37:
                                        {
                                            double[] Mr = new double[5];
                                            for (int s = 0; s < 5; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.N3(Mr).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 38:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rsg1(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 39:
                                        {
                                            double[] Mr = new double[7];
                                            for (int s = 0; s < 7; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.N5(Mr).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 40:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Rsg1(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 41:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 42:
                                        {
                                            double[] Mr = new double[2];
                                            for (int s = 0; s < 2; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 2).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 43:
                                        {
                                            double[] Mr = new double[3];
                                            for (int s = 0; s < 3; s++)
                                            {
                                                Mr[s] = Convert.ToDouble(DGV.Rows[i + s + 1].Cells[1].Value);
                                            }
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Mr(Mr, 3).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 44:
                                        {
                                            for (int iter = i; iter < DGV.Rows.Count; iter++)
                                            {
                                                if (DGV.Rows[iter].Cells[3].Value.ToString() == "index")
                                                {
                                                    int it = Convert.ToInt32(DGV.Rows[iter].Cells[1].Value);
                                                    double[] Qi = new double[it];
                                                    double[] Qi_p = new double[it];
                                                    for (int p = 0; p < it; p++)
                                                    {
                                                        Qi_p[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                        Qi[p] = Convert.ToDouble(DGV.Rows[iter - 1].Cells[1].Value);
                                                        iter--;
                                                    }
                                                    string[] fields2_1 = { "id_of_formula", "result" };
                                                    string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, calc.Pz(it, Qi, Qi_p).ToString().Replace(",", ".") };
                                                    db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                            else if (id_of_exp == 3)
                            {
                                switch (Convert.ToInt32(idf))
                                {
                                    case 1:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getOSTG(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 2:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getOSTG_2(a, b, c).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 3:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getPM_GIM(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 4:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getPM_MI(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 5:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getPM_HCVP(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 6:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getBVForMen(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 7:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getBVForWomen(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 8:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getNBVForMen(a).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 9:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getNBVForWomen(a).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 10:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            double c = Convert.ToDouble(DGV.Rows[i + 3].Cells[1].Value);
                                            double d = Convert.ToDouble(DGV.Rows[i + 4].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getFV_SSSForMen(a, b, c, d).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                    case 11:
                                        {
                                            double a = Convert.ToDouble(DGV.Rows[i + 1].Cells[1].Value);
                                            double b = Convert.ToDouble(DGV.Rows[i + 2].Cells[1].Value);
                                            string[] fields2_1 = { "id_of_formula", "result" };
                                            string[] values2_1 = { idf + " AND calculation_number = " + calc_numbCB.Text + " AND id_of_expert = " + idOfViewedExpert, medCalc.getFV_SSSForWomen(a, b).ToString().Replace(",", ".") };
                                            db.UpdateRecord("calculations_result", fields2_1, values2_1);
                                            break;
                                        }
                                }
                            }
                            //выходим из цикла поиска
                            break;
                        }
                    }
                }
                //обновляем Таблицу
                get_grid();
            }));
        }

        private void change_desc_Click(object sender, EventArgs e)
        {
            if (idOfViewedExpert == id_of_exp)
            {            //Переменная для хранения описания и названия серии
                string idc = calc_numbCB.SelectedItem.ToString();
                string issueid = "NULL";
                try
                {
                    issueid = (issueTB.SelectedItem as Issue).id.ToString();
                }
                catch (Exception)
                {
                }
                string[] fields4 = { "calculation_number", "calculation_name", "description_of_calculation", "issue_id" };
                string[] values4 = { idc + " AND id_of_expert = " + idOfViewedExpert, "'" + name_of_seriesCB.Text.Replace('\'', '`') + "'", "'" + desc_of_seriesTB.Text.Replace('\'', '`') + "'", issueid };
                db.UpdateRecord("calculations_description ", fields4, values4);//обновляем описание и название серии
            }
            else
            {
                MessageBox.Show("Ви не можете змінити данні іншого експерта");
            }
        }

        private bool redakt = true;

        private void Panel_redakt_Click(object sender, EventArgs e)
        {
            if (idOfViewedExpert == id_of_exp)
            {
                redakt = !redakt;

                if (!redakt)
                {
                    Panel_redakt.BackColor = Color.LightGreen;
                    desc_of_seriesTB.ReadOnly = false;
                    Column2.ReadOnly = false;
                    issueTB.Enabled = true;
                }
                if (redakt)
                {
                    Panel_redakt.BackColor = Color.Brown;
                    desc_of_seriesTB.ReadOnly = true;
                    Column2.ReadOnly = true;
                    issueTB.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Ви не можете змінювати данні іншого експерта");
            }
        }

        private void Delete_desc_Click(object sender, EventArgs e)
        {
            if (idOfViewedExpert == id_of_exp)
            {
                DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити опис серії?\n Це видалить всі результати в даній серії", "Повідомлення", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string idc = calc_numbCB.SelectedItem.ToString();
                    string[] fields2 = { "calculation_number", "id_of_expert" };
                    string[] values2 = { idc, idOfViewedExpert.ToString() };
                    db.DeleteFromDB("parameters_value", fields2, values2);
                    db.DeleteFromDB("calculations_description", fields2, values2);
                    get_values();
                }
                else if (dialogResult == DialogResult.No)
                {
                    get_values();
                }
            }
            else
            {
                MessageBox.Show("Ви не можете видалити данні іншого експерта");
            }
        }

        private void Mass_delete_Click(object sender, EventArgs e)
        {
            if (idOfViewedExpert == id_of_exp)
            {
                DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити всі формули в цій серії?", "Повідомлення", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string idc = calc_numbCB.SelectedItem.ToString();
                    string[] fields2 = { "calculation_number", "id_of_expert" };
                    string[] values2 = { idc, idOfViewedExpert.ToString() };
                    db.DeleteFromDB("calculations_result", fields2, values2);
                    db.DeleteFromDB("parameters_value", fields2, values2);
                    get_values();
                    calc_numbCB.SelectedItem = idc;
                }
                else if (dialogResult == DialogResult.No)
                {
                    get_values();
                }
            }
            else
            {
                MessageBox.Show("Ви не можете видалити данні іншого експерта");
            }
        }

        private void calc_numbCB_TextChanged(object sender, EventArgs e)
        {
            if (calc_numbCB.Text == "")
                calc_numbCB.Text = prev_calc_numb;
        }

        private bool isOpenChart = false;

        private void chartButt_Click(object sender, EventArgs e)
        {
            if (isOpenChart)
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
                new FormulaChart(idOfViewedExpert).ShowDialog();
            }
            else if (chartsList.Text.Equals("Графік проблеми"))
            {
                new IssueChart(idOfViewedExpert).ShowDialog();
            }
        }

        private void experts_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            idOfViewedExpert = (experts_CB.Items[experts_CB.SelectedIndex] as Expert).id;
            get_values();
        }

        private void name_of_seriesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var calc = db.GetRows("calculations_description", "calculation_number", "calculation_name = '" + name_of_seriesCB.Text.Replace('\'', '`') + "' AND id_of_expert = " + idOfViewedExpert);
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

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                string strTip = "";//переменная для хранения сообщения подсказки

                //смотрим на каком месте указатель, считываем id формулы и делаем запрос в БД для изъятия подсказки
                int rIdx = e.RowIndex;
                if ((rIdx >= 0) && (rIdx < DGV.Rows.Count))
                {
                    if (DGV.Rows[rIdx].Cells[3].Value.ToString() == "id_of_formula")
                    {
                        string idf = DGV.Rows[rIdx].Cells[2].Value.ToString();
                        var obj2 = db.GetRows("formulas", "description_of_formula", "id_of_formula = " + idf + " AND id_of_expert = " + idOfViewedExpert);
                        strTip = obj2[0][0].ToString();
                    }
                    else
                    {
                        string idf = DGV.Rows[rIdx].Cells[2].Value.ToString();
                        var obj21 = db.GetRows("formula_parameters", "description_of_parameter", "id_of_parameter = " + idf + " AND id_of_expert = " + idOfViewedExpert);
                        strTip = obj21[0][0].ToString();
                    }
                    DataGridViewCell cell = this.DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = strTip;
                }
            }
            catch (Exception)
            {
            }
        }

        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "id_of_expert>0 AND id_of_expert<4");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            //функция для забивания данных в таблицу с формулами и параметрами, их значениями и номера расчётов
            idOfViewedExpert = id_of_exp;
            for (int i = 0; i < experts_CB.Items.Count; i++)
            {
                if ((experts_CB.Items[i] as Expert).id == idOfViewedExpert)
                    experts_CB.SelectedIndex = i;
            }
        }
    }
}