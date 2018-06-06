using Data;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Odessa
{
    internal class ClassMap
    {
        private GMap.NET.WindowsForms.GMapControl gMapControl;

        private DBManager db = new DBManager();

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
            points_grid.Rows.RemoveAt(points_grid.RowCount - 1);
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
        public void SaveToDB(string id_calc, string id_formula, string id_expert, DataGridView points_grid)
        {
            int maXNum;
            //get the max poligon id0
            var res_points = db.GetRows("poligon", "max(Id_of_poligon)", "");
            if (res_points[0][0] is DBNull)
                maXNum = 1;
            else
                maXNum = Convert.ToInt16(res_points[0][0]) + 1;

            string[] fields = { "Id_of_poligon","brush_color_r", "bruch_color_g", "brush_color_b", "brush_alfa", "line_collor_r", "line_color_g", "line_color_b",
                "line_alfa", "line_thickness", "name","id_of_expert"};
            string[] val = { Convert.ToString(maXNum), "250", "250", "250", "250", "0", "250", "2", "21", "2", "'Test1'", id_expert };
            db.InsertToBD("poligon", fields, val);
            //points
            string[] fields_1 = { "longitude", "latitude", "Id_of_poligon", "`order`" };

            for (int i = 0; i < points_grid.Rows.Count - 1; i++)
            {
                string[] va1 = { points_grid.Rows[i].Cells[0].Value.ToString().Replace(',', '.'), points_grid.Rows[i].Cells[1].Value.ToString().Replace(',', '.'), Convert.ToString(maXNum), Convert.ToString(i + 1) };
                db.InsertToBD("point_poligon", fields_1, va1);
            }

            string[] fields2 = { "id_poligon", "calculations_description_number", "id_of_formula" };
            string[] val2 = { Convert.ToString(maXNum), id_calc, id_formula };
            db.InsertToBD("poligon_calculations_description", fields2, val2);
        }

        private double R = 6378.137;

        public double ToRad(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public double cArea()
        {
            var over = from a in gMapControl.Overlays where a.Id == "polygons" select a;
            if (over.Count() == 0) return 0;
            double area1 = 0;
            var polygons = over.First().Polygons;
            foreach (var polygon in polygons)
            {
                double area = 0;
                var points = polygon.Points;
                if (points.Count > 2)
                {
                    for (var i = 0; i < points.Count - 1; i++)
                    {
                        var p1 = points[i];
                        var p2 = points[i + 1];
                        area += ToRad(p2.Lng - p1.Lng) * (2 + Math.Sin(ToRad(p1.Lat))
                           + Math.Sin(ToRad(p2.Lat)));
                    }
                    var p3 = points.Last();
                    var p4 = points.First();
                    area += ToRad(p4.Lng - p3.Lng) * (2 + Math.Sin(ToRad(p3.Lat))
                       + Math.Sin(ToRad(p4.Lat)));

                    area = area * R * R / 2;
                }
                area1 = Math.Abs(area);
            }
            return area1;
        }

        //функция поставить точку наблюдения и указать ее тип

        //отрисовка полигона по данным из таблицы (необходимо передавать параметр calculation_description_number)
        //int expert_id код эксперта для которго рисуем, int param_id - параметр для которого рисуем
        //+функция которая рисует все полигоны для экспетра по всем параметрам
        public void highlight_polygon_from_table(string calc_id, string param_id, int zoom, int expert_id)
        {
            //очищать полигон перед отрисовкой
            //!!!
            var res_points = db.GetRows("point_poligon,poligon_calculations_description", "longitude, latitude, `order`",
                "poligon_calculations_description.calculations_description_number=" + calc_id +
                " and  point_poligon.Id_of_poligon=poligon_calculations_description.id_poligon and poligon_calculations_description.id_of_formula=" + param_id + " order by `order`");
            if (res_points.Count > 0)
            {
                GMapOverlay polyOverlay = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();
                for (int i = 0; i < res_points.Count; i++)
                {
                    points.Add(new PointLatLng(Convert.ToDouble(res_points[i][0]),
                                                Convert.ToDouble(res_points[i][1])));
                }
                //name of poligon references from params and calc_description
                GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                polygon.Tag = param_id;
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
            else
                MessageBox.Show("Для обраної серії розрахунків та параметру відсутня інформація про зони забруднення!");
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

        public void zoom_plus(int zoom) //увеличение масштаба (передает зум)
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

        public void start_write() //начало записи
        {
            gMapControl.Overlays.Clear();
        }

        public void end_write(int zoom, DataGridView points_grid) //конец записи (1- кнопка начала записи, 2- кнопка конца записи)
        {
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

        //заполнение формулами
        public void FillFormulas(int id_expert, ComboBox cbForm)
        {
            //List<Formula> formulas = new List<Formula>();

            // cbForm.Items.Add("LOL");
            var formulas = db.GetRows("FORMULAS", "description_of_formula",
               "id_of_expert=" + id_expert +
               "");

            for (int i = 0; i < formulas.Count; i++)
            {
                cbForm.Items.Add(Convert.ToString(formulas[i][0]));
            }
        }

        public void Try1(DataGridView points_grid, double lat, double lng, int zoom) //ставим точки по двойному нажатию мыши
        {
            try
            {
                points_grid.Rows.Add(lat.ToString(), lng.ToString());
            }
            catch (ArgumentOutOfRangeException)
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