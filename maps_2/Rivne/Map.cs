using Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Odessa
{
    public partial class Map : Form
    {
        private ClassMap m; //object for work with maps
        public int id_of_exp;
        private DBManager db = new DBManager();
        private List<List<Object>> list_calc;
        private List<List<Object>> list_params;
        private bool start_draw = false;

        public Map()
        {
            InitializeComponent();
        }

        private void gMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && start_draw)
            {
                double lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                m.Try1(dataGridView1, lat, lng, Convert.ToInt16(gMapControl.Zoom.ToString()));
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (cbParams.SelectedIndex >= 0)
                m.SaveToDB(list_calc[cbCalc.SelectedIndex][1].ToString(),
                     list_params[cbParams.SelectedIndex][0].ToString(), id_of_exp.ToString(), dataGridView1);
            else
                m.SaveToDB(list_calc[cbCalc.SelectedIndex][1].ToString(),
                                 "0", id_of_exp.ToString(), dataGridView1);
            //first param "1" - параметр calculation_description_number, который необходимо передать для сохранения в базу данных
            //second - id_of_formula
            //third it is id_of_expert
            btnSave.Enabled = false;
            btnEndPoint.Enabled = false;
            btnStartPoint.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // просто чистит грид
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //отрисовка полигона по данным из БД
            string id_param = "0";
            if (cbParams.SelectedIndex >= 0) id_param = list_params[cbParams.SelectedIndex][0].ToString();
            if (cbCalc.SelectedIndex >= 0)
                m.highlight_polygon_from_table(list_calc[cbCalc.SelectedIndex][1].ToString(), id_param,
                 Convert.ToInt16(gMapControl.Zoom.ToString()), id_of_exp);
            else
                MessageBox.Show("Оберіть серію розрахунків!");
            //"1" - параметр calculation_description_number, который необходимо передать
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //увеличение масштаба
            m.zoom_plus(Convert.ToInt16(gMapControl.Zoom.ToString()));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //уменьшение масштаба
            m.zoom_minus(Convert.ToInt16(gMapControl.Zoom.ToString()));
        }

        private void button12_Click(object sender, EventArgs e)
        {   //удаляет последнюю строчку из грида, но не перерисовывает полигон (на карте остаются точки)
            m.delete_last_point(dataGridView1, Convert.ToInt16(gMapControl.Zoom.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbCalc.SelectedIndex >= 0)
            {
                start_draw = true;
                btnStartPoint.Enabled = false;
                btnEndPoint.Enabled = true;
                m.start_write();//начало работы с картой
                                //m.erase_all(Convert.ToInt16(gMapControl.Zoom.ToString()));
            }
            else
                MessageBox.Show("Оберіть серію розрахунків та параметр, для яких бажаєте побудувати зону забруднення!");
        }

        //end point
        private void button2_Click(object sender, EventArgs e)
        {
            start_draw = false;
            if (dataGridView1.RowCount > 0)
            {
                m.end_write(Convert.ToInt16(gMapControl.Zoom.ToString()), dataGridView1); //отрисовывает полигон по точкам
                m.highlight_district_grid(dataGridView1, Convert.ToInt16(gMapControl.Zoom.ToString())); //функция для отрисовки полигона по точкам из грида
                btnSave.Enabled = true;
                btnEndPoint.Enabled = false;
            }
        }

        private void Map_Load(object sender, EventArgs e)
        {
            m = new ClassMap(this.gMapControl); //создаем экземпляр класса
            m.load_map(5); //начальная прогрузка карты с масштабом 5
            btnEndPoint.Enabled = false;
            // cbCalc.Items.Add("LOL");
            m.FillFormulas(id_of_exp, cbCalc);

            //заполнить существующие серии расчетов
            list_calc = db.GetRows("calculations_description", "calculation_name, calculation_number", "id_of_expert=" + id_of_exp.ToString());
            cbCalc.Items.Clear();
            for (int i = 0; i < list_calc.Count; i++)
                cbCalc.Items.Add(list_calc[i][0].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = m.cArea();
            button3.Text = a.ToString();
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
        }

        private void gMapControl_OnPolygonClick(GMap.NET.WindowsForms.GMapPolygon item, MouseEventArgs e)
        {
            MessageBox.Show(item.Tag.ToString());
        }

        private void cbCalc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCalc.SelectedIndex >= 0)
            {
                //заполнить существующие серии params of description
                string condition = "calculations_description.calculation_name ='" + cbCalc.Text +
                    "' and calculations_description.id_of_expert = " + id_of_exp.ToString() +
                    " and calculations_description.calculation_number = calculations_result.calculation_number and " +
                    " calculations_result.id_of_expert = " + id_of_exp.ToString() +
                    " and formulas.id_of_formula = calculations_result.id_of_formula and formulas.id_of_expert=" + id_of_exp.ToString();
                list_params = db.GetRows("calculations_description, calculations_result, formulas",
                    "formulas.id_of_formula, name_of_formula, description_of_formula, measurement_of_formula, result", condition);
                cbParams.Items.Clear();
                if (list_params.Count > 0)
                {
                    for (int i = 0; i < list_params.Count; i++)
                        cbParams.Items.Add(list_params[i][2].ToString() + "(" + list_params[i][1].ToString() + ")");
                    cbParams.Enabled = true;
                }
            }
        }
    }
}