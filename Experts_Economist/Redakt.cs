﻿using Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Experts_Economist
{
    public partial class Redakt : Form
    {
        public Redakt()
        {
            InitializeComponent();
        }

        //инициализираем экземпляр класса работы с БД
        private DBManager db = new DBManager();

        public int id_of_exp;

        private void Redakt_Load(object sender, EventArgs e)
        {
            //при входе на форму обновляем компоненты и записываем в combobox список экспертов
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "id_of_expert>0 AND id_of_expert<4");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            experts_CB.SelectedIndex = 0;
            id_of_exp = (experts_CB.Items[experts_CB.SelectedIndex] as Expert).id;
            refresh();
        }

        //функция для записи формул,параметров в списки
        private void get_values()
        {
            //переменная для хранения имён формул
            var obj = db.GetRows("formulas", "name_of_formula", "id_of_expert = " + id_of_exp);

            string item = "";//вспомогательная переменная для записи имён формул в список
            for (int i = 0; i < obj.Count; i++)//в цикле записываем имена формулы в список
            {
                for (int j = 0; j < obj[i].Count; j++)
                {
                    item += obj[i][j];
                }
                formulasLB.Items.Add(item);
                item = "";
            }
            //аналогично с алгоритмом выше записываем id формул
            var obj1 = db.GetRows("formulas", "id_of_formula", "id_of_expert = " + id_of_exp);
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
            //аналогично с алгоритмом выше записываем имена параметров
            var obj2 = db.GetRows("formula_parameters", "name_of_parameter", "id_of_expert = " + id_of_exp);
            item = "";
            for (int i = 0; i < obj2.Count; i++)
            {
                for (int j = 0; j < obj2[i].Count; j++)
                {
                    item += obj2[i][j];
                }
                componentLB.Items.Add(item);
                item = "";
            }
            //аналогично с алгоритмом выше записываем id параметров
            var obj3 = db.GetRows("formula_parameters", "id_of_parameter", "id_of_expert = " + id_of_exp);
            item = "";
            for (int i = 0; i < obj3.Count; i++)
            {
                for (int j = 0; j < obj3[i].Count; j++)
                {
                    item += obj3[i][j];
                }
                componentidLB.Items.Add(item);
                item = "";
            }
        }

        //функция для обновления элементов формы
        private void refresh()
        {
            formulasLB.Items.Clear();
            formulas_idLB.Items.Clear();
            formula_nameTB.Clear();
            formula_explTB.Clear();

            componentLB.Items.Clear();
            componentidLB.Items.Clear();
            component_nameTB.Clear();
            component_measureTB.Clear();
            component_explTB.Clear();
            bind_compLB.Items.Clear();

            get_values();
            try
            {
                formulasLB.SelectedIndex = 0;
                componentLB.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        //вызов события нажатия на кнопку Добавить которая относиться к добавлению новых формул
        private void add1_Click(object sender, EventArgs e)
        {//переменные для хранения имён формул, описания и id експерта
            if (id_of_exp == 0)
                id_of_exp = 1;
            string[] fields4 = { "name_of_formula", "description_of_formula", "id_of_expert", "measurement_of_formula" };
            string[] values4 = { "'" + formula_nameTB.Text + "'", "'" + formula_explTB.Text + "'", id_of_exp.ToString(), "'" + formula_measureTB.Text + "'" };
            try
            {
                db.InsertToBD("formulas", fields4, values4);//запись новой формулы в БД
            }
            catch (MySqlException)// ловим эксепшн mysql если идёт дупликация ключа
            {
                MessageBox.Show("Перевірте правильність введенних даних");
                return;
            }
            // MessageBox.Show();
            refresh();
            formulasLB.SelectedIndex = formulasLB.Items.Count - 1;//выбор последней формулы в списке формул
        }

        //вызов события нажатия на кнопку Обновить которая относиться к обновлению  формул
        private void update1_Click(object sender, EventArgs e)
        {
            int ii = formulasLB.SelectedIndex;//сохраняем место редактируемой формулы
            //переменная для хранения id формулы
            if (id_of_exp == 0)
                id_of_exp = 1;
            string idf = formulas_idLB.SelectedItem.ToString();
            //Переменная для хранения id формулы, имени, описания и id експерта
            string[] fields5 = { "id_of_formula", "name_of_formula", "description_of_formula", "id_of_expert", "measurement_of_formula" };
            string[] values5 = { idf, "'" + formula_nameTB.Text + "'", "'" + formula_explTB.Text + "'", id_of_exp.ToString(), "'" + formula_measureTB.Text + "'" };
            db.UpdateRecord("formulas", fields5, values5);//обновляем запись формулы
            refresh();//обновляем элементы формы
            formulasLB.SelectedIndex = ii;//выбираем только что измененную формулу в списке формул
        }

        //вызов события нажатия на кнопку Удалить которая относиться к удалению  формул
        private void del1_Click(object sender, EventArgs e)
        {//при нажатии на кнопку выскакивает диалоговое окно с вариантами да/нет, да - создание переменной для id формулы и удаление последней, нет - выход из функции с обновлением
            int ii = formulasLB.SelectedIndex;//сохраняем место редактируемой формулы
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити цю формулу?", "Повідомлення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string idf = formulas_idLB.SelectedItem.ToString();
                db.DeleteFromDB("formulas", "id_of_formula", idf);
                refresh();
                try
                {
                    formulasLB.SelectedIndex = ii;
                }
                catch (Exception)
                {
                    try
                    {
                        formulasLB.SelectedIndex = ii - 1;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                refresh();
                formulasLB.SelectedIndex = ii;//выбираем только что измененную формулу в списке формул
            }
        }

        //аналогично с добавлением новых формул - добалвение новых параметров
        private void add2_Click(object sender, EventArgs e)
        {
            if (id_of_exp == 0)
                id_of_exp = 1;
            string[] fields4 = { "name_of_parameter", "measurement_of_parameter", "description_of_parameter", "id_of_expert" };
            string[] values4 = { "'" + component_nameTB.Text + "'", "'" + component_measureTB.Text + "'", "'" + component_explTB.Text + "'", id_of_exp.ToString() };
            try
            {
                db.InsertToBD("formula_parameters", fields4, values4);
            }
            catch (MySqlException)// ловим эксепшн mysql если идёт дупликация ключа
            {
                MessageBox.Show("Перевірте правильність введенних даних");
                return;
            }
            // MessageBox.Show();
            refresh();
            componentLB.SelectedIndex = componentLB.Items.Count - 1;
        }

        //аналогично с обновлением формул - обновление параметров

        private void update2_Click(object sender, EventArgs e)
        {
            int ii = componentLB.SelectedIndex;
            if (id_of_exp == 0)
                id_of_exp = 1;
            string idfc = componentidLB.SelectedItem.ToString();
            string[] fields5 = { "id_of_parameter", "name_of_parameter", "measurement_of_parameter", "description_of_parameter", "id_of_expert" };
            string[] values5 = { idfc, "'" + component_nameTB.Text + "'", "'" + component_measureTB.Text + "'", "'" + component_explTB.Text + "'", id_of_exp.ToString() };
            db.UpdateRecord("formula_parameters", fields5, values5);
            // MessageBox.Show();
            refresh();
            componentLB.SelectedIndex = ii;
        }

        //аналогично с удалением формул - удаление параметров
        private void del2_Click(object sender, EventArgs e)
        {
            int ii = componentLB.SelectedIndex;//сохраняем место редактируемой формулы
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити цей параметр?", "Повідомлення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string idfc = componentidLB.SelectedItem.ToString();
                db.DeleteFromDB("formula_parameters", "id_of_parameter", idfc);
                refresh();
                try
                {
                    componentLB.SelectedIndex = ii;
                }
                catch (Exception)
                {
                    try
                    {
                        componentLB.SelectedIndex = ii - 1;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                refresh();
                componentLB.SelectedIndex = ii;//выбираем только что измененную формулу в списке формул
            }
        }

        //событие ведения мышки по списку формул, выведение подсказки для каждой формулы
        private void formulasLB_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";//переменная для хранения подсказки
            //смотрим положение указателя и id текущей формулы под указателем
            int nIdx = formulasLB.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < formulasLB.Items.Count))
            {//достаём из БД описание формулы по текущему id и заносим в подсказку
                string idf = formulas_idLB.Items[nIdx].ToString();
                var obj = db.GetRows("formulas", "description_of_formula", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                strTip = obj[0][0].ToString();
            }
            toolTip1.SetToolTip(formulasLB, strTip);
        }

        //аналогично с подсказкой для формулы - посдказка для параметров
        private void componentLB_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            int nIdx = componentLB.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < componentLB.Items.Count))
            {
                string idfp = componentidLB.Items[nIdx].ToString();
                var obj = db.GetRows("formula_parameters", "description_of_parameter", "id_of_parameter = " + idfp + " AND id_of_expert = " + id_of_exp);
                strTip = obj[0][0].ToString();
            }
            toolTip1.SetToolTip(componentLB, strTip);
        }

        //событие выбора формулы, при выборе формулы в списке параметров для формулы отображаются привязанные к формуле параметры
        private void formulasLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                formulas_idLB.SelectedIndex = formulasLB.SelectedIndex;
                string idf = formulas_idLB.SelectedItem.ToString();
                formula_nameTB.Text = formulasLB.SelectedItem.ToString();
                var obj0 = db.GetRows("formulas", "description_of_formula,measurement_of_formula", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                formula_explTB.Text = obj0[0][0].ToString();
                formula_measureTB.Text = obj0[0][1].ToString();

                bind_compLB.Items.Clear();
                formulas_idLB.SelectedIndex = formulasLB.SelectedIndex;
                var obj = db.GetRows("formula_compound", "id_of_parameter", "id_of_formula = " + idf + " AND id_of_expert = " + id_of_exp);
                var obj1 = new List<List<Object>>();
                for (int i = 0; i < obj.Count; i++)
                {
                    obj1 = db.GetRows("formula_parameters", "name_of_parameter", "id_of_parameter = " + obj[i][0].ToString() + " AND id_of_expert = " + id_of_exp);
                    bind_compLB.Items.Add(obj1[0][0].ToString());
                }
            }
            catch (Exception)
            {
            }
        }

        //при нажатии на параметре в поля снизу записываются имя параметра, описание, единицы измерения
        private void componentLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                componentidLB.SelectedIndex = componentLB.SelectedIndex;
                string idfp = componentidLB.SelectedItem.ToString();
                component_nameTB.Text = componentLB.SelectedItem.ToString();
                var obj = db.GetRows("formula_parameters", "measurement_of_parameter,description_of_parameter ", "id_of_parameter =" + idfp + " AND id_of_expert = " + id_of_exp);
                component_measureTB.Text = obj[0][0].ToString();
                component_explTB.Text = obj[0][1].ToString();
            }
            catch (Exception)
            {
            }
        }

        //Привязывает параметр к формуле
        private void Bind_Click(object sender, EventArgs e)
        {
            //параметры для хранения изменяемых полей - id формулы, id параметра и значения изменяемых полей
            try
            {
                string[] fields2 = { "id_of_formula", "id_of_parameter", "id_of_expert" };
                string[] values2 = { "'" + formulas_idLB.SelectedItem.ToString() + "'", "'" + componentidLB.SelectedItem.ToString() + "'", id_of_exp.ToString() };
                db.InsertToBD("formula_compound", fields2, values2); // вносим изменения в таблицу
                int ii = formulasLB.SelectedIndex;
                int ii2 = componentLB.SelectedIndex;//запоминаем места формулы и параметра
                refresh();//обновляем
                formulasLB.SelectedIndex = ii;//выделяем формулу и параметр с которыми работали
                componentLB.SelectedIndex = ii2;
            }
            catch (Exception)
            {
            }
        }

        //аналогично с привязкой делает обратное - отсоедниеяет параметр от формулы
        private void Unbind_Click(object sender, EventArgs e)
        {
            try
            {
                string[] fields2 = { "id_of_formula", "id_of_parameter", "id_of_expert" };
                string[] values2 = { "'" + formulas_idLB.SelectedItem.ToString() + "'", "'" + componentidLB.SelectedItem.ToString() + "'", id_of_exp.ToString() };
                db.DeleteFromDB("formula_compound", fields2, values2);
                //MessageBox.Show();

                int ii = formulasLB.SelectedIndex;
                int ii2 = componentLB.SelectedIndex;
                refresh();
                formulasLB.SelectedIndex = ii;
                componentLB.SelectedIndex = ii2;
            }
            catch (Exception)
            {
            }
        }

        //при выборе параметра в списке привязанных параметров выбирает данный параметр в списке параметров
        private void bind_compLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < componentLB.Items.Count; i++)
                {
                    if (bind_compLB.SelectedItem.ToString() == componentLB.Items[i].ToString())
                    {
                        componentLB.SelectedIndex = i;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void search_formula_TextChanged(object sender, EventArgs e)
        {
            int i = formulasLB.FindString(search_formula.Text);
            formulasLB.SelectedIndex = i;
        }

        private void search_parametr_TextChanged(object sender, EventArgs e)
        {
            int i = componentLB.FindString(search_parametr.Text);
            componentLB.SelectedIndex = i;
        }

        private void experts_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_of_exp = (experts_CB.Items[experts_CB.SelectedIndex] as Expert).id;
            refresh();
        }

        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            experts_CB.Items.Clear();
            var obj3 = db.GetRows("expert", "*", "");
            var Experts = new List<Expert>();
            foreach (var row in obj3)
            {
                Experts.Add(ExpertMapper.Map(row));
            }
            experts_CB.Items.AddRange(Experts.ToArray());
            experts_CB.SelectedIndex = 0;
            id_of_exp = (experts_CB.Items[experts_CB.SelectedIndex] as Expert).id;
            refresh();
        }
    }
}