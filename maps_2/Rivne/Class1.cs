using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.MapProviders;
using MySql.Data.MySqlClient;
using System.Configuration;
using GMap;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Odessa
{
    class ClassMap
    {
        private GMap.NET.WindowsForms.GMapControl gMapControl;

        DBManager db = new DBManager();

        public ClassMap(GMap.NET.WindowsForms.GMapControl gm)
        {
            gMapControl = gm;

        }





        //отрисовать по данным из грида (полезно при удалении точек)
    public void highlight_district_grid(DataGridView points_grid, int zoom)
    {
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        List<PointLatLng> points = new List<PointLatLng>();
        for (int i = 0; i < points_grid.Rows.Count - 1; i++)
        {
            points.Add(new PointLatLng(Convert.ToDouble(points_grid.Rows[i].Cells[0].Value),
                                        Convert.ToDouble(points_grid.Rows[i].Cells[1].Value)));
        }
        GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
        polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
        polygon.Stroke = new Pen(Color.Red, 1);
        polyOverlay.Polygons.Add(polygon);
       // return polyOverlay;
        gMapControl.Overlays.Add(polyOverlay);

            zoom += 1;
            gMapControl.Zoom = zoom;
            zoom -= 1;
            gMapControl.Zoom = zoom;

        }

        //удаляет последнюю запись из грида
        public void delete_last_point(DataGridView points_grid, int zoom)
        {
           
            points_grid.AllowUserToAddRows = false;
            points_grid.Rows.RemoveAt(points_grid.RowCount-1);
            points_grid.AllowUserToAddRows = true;
            gMapControl.Overlays.Clear();

            if (points_grid.Rows.Count != 0)
            {
                for (int i = 0; i < points_grid.Rows.Count; i++)
                {
                    marker(Convert.ToDouble(points_grid.Rows[i].Cells[0].Value),
                                               Convert.ToDouble(points_grid.Rows[i].Cells[1].Value));
                }
            }

            zoom += 1;
            gMapControl.Zoom = zoom;
            zoom -= 1;
            gMapControl.Zoom = zoom;



        }

        //сохраняет координаты из грида в таблицы БД
        //необходимо передавать параметр calculation_description_number
       public void SaveToDB(string id_calc, DataGridView points_grid)
        {
             int maXNum, Num;

            var res_points = db.GetRows("poligon_calculations_description", "id_poligon",
                "");
            maXNum = Convert.ToInt16(res_points[0][0]);
            for (int i = 1; i < res_points.Count; i++)
            {
                Num = Convert.ToInt16(res_points[i][0]);
                if (maXNum < Num)
                {
                    maXNum = Num;
                }
            }

            maXNum += 1;
            string[] fields = { "Id_of_poligon","brush_color_r", "bruch_color_g", "brush_color_b", "brush_alfa", "line_collor_r", "line_color_g", "line_color_b",
                "line_alfa", "line_thickness", "name"};
            string[] val = { Convert.ToString(maXNum), "250","250","250", "250", "0", "250", "2", "21", "2", "'Test1'"};
            db.InsertToBD("poligon", fields, val);
            //points
            string[] fields_1 = { "longitude", "latitude", "Id_of_poligon", "order_p" };

            for (int i = 0; i < points_grid.Rows.Count - 1; i++)
            {
                string[] va1 = {points_grid.Rows[i].Cells[0].Value.ToString(), points_grid.Rows[i].Cells[1].Value.ToString(), Convert.ToString(maXNum), Convert.ToString(i+1) };
                db.InsertToBD("point_poligon", fields_1, va1);
            }

            string[] fields2 = { "id_poligon", "calculations_description_number" };
            string[] val2 = { Convert.ToString(maXNum), id_calc};
            db.InsertToBD("poligon_calculations_description", fields2, val2);
 
        }

        //отрисовка полигона по данным из таблицы (необходимо передавать параметр calculation_description_number)
        public void highlight_polygon_from_table(string calc_id, int zoom)
        {
            var res_points = db.GetRows("point_poligon,poligon_calculations_description", "longitude, latitude",
                "poligon_calculations_description.calculations_description_number=" + calc_id+
                " and  point_poligon.Id_of_poligon=poligon_calculations_description.id_poligon");
            
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            for (int i = 0; i < res_points.Count; i++)
            {
                points.Add(new PointLatLng(Convert.ToDouble(res_points[i][0]),
                                            Convert.ToDouble(res_points[i][1])));
            }
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            // return polyOverlay;
            gMapControl.Overlays.Add(polyOverlay);
            zoom += 1;
            gMapControl.Zoom = zoom;
            zoom -= 1;
            gMapControl.Zoom = zoom;

        }

        

        public void load_map(int zoom)//прогрузка карты
        {
            gMapControl.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            ///с помощью левой кнопки мыши. 
            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMapControl.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            
              gMapControl.Zoom = zoom;                                ///!!!!!!!!!!!!

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            //gMapControl.Dock = DockStyle.Fill;

            //Указываем что будем использовать карты Google.
            gMapControl.MapProvider =
            GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode =
            GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy =
                System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials =
                System.Net.CredentialCache.DefaultCredentials;

            gMapControl.SetPositionByKeywords("Ukraine");
        }

        public void  zoom_plus(int zoom) //увеличение масштаба (передает зум)
        {
            //return (zoom++);
            zoom += 1;
            gMapControl.Zoom = zoom;
        }

        public void zoom_minus(int zoom) //уменьшение масштаба (передает зум)
        {
            //return (zoom++);
            zoom -= 1;
            gMapControl.Zoom = zoom;
        }


        public void start_write(System.Windows.Forms.Button but1, System.Windows.Forms.Button but2, DataGridView points_grid) //начало записи (1- кнопка начала записи, 2- кнопка конца записи)
        {
            but1.Enabled = false;
            but2.Enabled = true;
            gMapControl.Overlays.Clear();


        }

        public void end_write(System.Windows.Forms.Button but1, System.Windows.Forms.Button but2, int zoom, DataGridView points_grid) //конец записи (1- кнопка начала записи, 2- кнопка конца записи)
        {
            but2.Enabled = false;
            but1.Enabled = true;
            if (points_grid.Rows.Count != 0)
            {
                for (int i = 0; i < points_grid.Rows.Count; i++)
                {
                    marker(Convert.ToDouble(points_grid.Rows[i].Cells[0].Value),
                                               Convert.ToDouble(points_grid.Rows[i].Cells[1].Value));
                }
            }

           
            zoom += 1;
            gMapControl.Zoom = zoom;
            zoom -= 1;
            gMapControl.Zoom = zoom;

           // gMapControl.E = false;
                        

        }

       



        public void marker(double lat, double lng) //отрисовка маркеров
        {
            
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng),
              GMarkerGoogleType.red_small);
            markersOverlay.Markers.Add(marker);
            gMapControl.Overlays.Add(markersOverlay);

           


        }

        
        public void   Try1(DataGridView points_grid, double lat, double lng, int zoom) //ставим точки по двойному нажатию мыши
        {
            try
            {
                points_grid.Rows.Add(lat.ToString().Remove(10), lng.ToString().Remove(10));
            }
            catch (ArgumentOutOfRangeException e)
            {
                points_grid.Rows.Add(lat.ToString().Remove(8), lng.ToString().Remove(8));
            }


            //gMapControl.Overlays.Clear();
            if (points_grid.Rows.Count != 0)
            {
                for (int i = 0; i < points_grid.Rows.Count; i++)
                {
                    marker(Convert.ToDouble(points_grid.Rows[i].Cells[0].Value),
                                               Convert.ToDouble(points_grid.Rows[i].Cells[1].Value));
                }
            }

            zoom += 1;
            gMapControl.Zoom = zoom;
            zoom -= 1;
            gMapControl.Zoom = zoom;


        }

            
        
        




    }
}
