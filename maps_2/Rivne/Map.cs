using System;
using System.Windows.Forms;

namespace Odessa
{
    public partial class Map : Form
    {
        private ClassMap m; //object for work with maps

        public Map()
        {
            InitializeComponent();
            m = new ClassMap(this.gMapControl); //создаем экземпляр класса
            m.load_map(5); //начальная прогрузка карты с масштабом 5
            button2.Enabled = false;
        }

        private void gMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                m.Try1(dataGridView1, lat, lng, Convert.ToInt16(gMapControl.Zoom.ToString()));
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            m.SaveToDB("1", dataGridView1); //"1" - параметр calculation_description_number, который необходимо передать для сохранения в базу данных
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // просто чистит грид
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //отрисовка полигона по данным из БД
            m.highlight_polygon_from_table("1", Convert.ToInt16(gMapControl.Zoom.ToString()));//"1" - параметр calculation_description_number, который необходимо передать
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
            m.start_write(button1, button2, dataGridView1);//начало работы с картой
            //m.erase_all(Convert.ToInt16(gMapControl.Zoom.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m.end_write(button1, button2, Convert.ToInt16(gMapControl.Zoom.ToString()), dataGridView1); //отрисовывает полигон по точкам
            m.highlight_district_grid(dataGridView1, Convert.ToInt16(gMapControl.Zoom.ToString())); //функция для отрисовки полигона по точкам из грида
        }

        private void Map_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = m.cArea();
            button3.Text = a.ToString();
        }
    }
}