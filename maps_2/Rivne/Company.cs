using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odessa
{
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
            FillCombo();
            comboBox1.SelectedIndex = 0;
            FillGrid(dataGridView1, "atmosphere");
            FillGrid(dataGridView2, "water");
            highlight_cells(dataGridView1);
            highlight_cells(dataGridView2);
            count_tax(dataGridView1,"Total Atmosphere Tax: ",label1);
            count_tax(dataGridView2, "Total Water Tax: ",label2);
        }

        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1111";
            string Query = "select * from eko.company ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                comboBox1.Items.Clear();
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("company_name");
                    comboBox1.Items.Add(sName);
                }
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string Query1 = "select * from eko.components group by component_name;";
            MySqlCommand cmdDatabase1 = new MySqlCommand(Query1, conDatabase);
            MySqlDataReader myReader1;
            try
            {
                comboBox2.Items.Clear();
                conDatabase.Open();
                myReader1 = cmdDatabase1.ExecuteReader();
                while (myReader1.Read())
                {
                    string sName = myReader1.GetString("component_name");
                    comboBox2.Items.Add(sName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void FillGrid(DataGridView grid,string area)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1111";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(" SELECT zabrudn.component_name AS Emmision, zabrudn.value AS `Value(ton)`, components.gdv AS `GDV(ton)`, components.tax AS `Tax(hrn per ton)`, zabrudn.value * components.tax AS `Tax amount(hrn)` , ROUND(zabrudn.value / components.gdv * 100, 0) AS `Percent(%)` FROM eko.zabrudn INNER JOIN eko.components ON zabrudn.area_name = components.area_name AND zabrudn.component_name = components.component_name WHERE (zabrudn.area_name = '" + area + "' and zabrudn.company_name= '"+this.comboBox1.SelectedItem+ "') GROUP BY zabrudn.company_name, zabrudn.value * components.tax, ROUND(zabrudn.value / components.gdv * 100, 0); ", conDatabase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                grid.DataSource = bSource;
                sda.Update(dbdataset);

                DataSet ds = new DataSet("New_DataSet");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                sda.Fill(dbdataset);
                ds.Tables.Add(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void highlight_cells(DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToDouble(grid.Rows[i].Cells[5].Value) > 100)
                {
                    grid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }
                else
                {
                    grid.Rows[i].Cells[5].Style.BackColor = Color.Green;
                }

            }
            
        }

        void count_tax(DataGridView grid, string area, Label label)
        {

            double tax=0;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                tax += Convert.ToDouble(grid.Rows[i].Cells[4].Value);
                label.Text = area + tax + " hrn";
            }
        }

        private void alter_data(string query, string message)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1111";
            string Query = query;
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show(message);
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FillGrid(dataGridView1,"atmosphere");
            FillGrid(dataGridView2,"water");
            highlight_cells(dataGridView1);
            highlight_cells(dataGridView2);
            count_tax(dataGridView1, "Total Atmosphere Tax: ", label1);
            count_tax(dataGridView2, "Total Water Tax: ", label2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                alter_data("insert into eko.zabrudn (component_name,value,company_name,area_name) values('" + this.comboBox2.SelectedItem + "','" + this.textBox4.Text + "','" + this.comboBox1.SelectedItem + "', 'atmosphere');", "Inserted");
            if (tabControl1.SelectedIndex == 1)
                alter_data("insert into eko.zabrudn (component_name,value,company_name,area_name) values('" + this.comboBox2.SelectedItem + "','" + this.textBox4.Text + "','" + this.comboBox1.SelectedItem + "', 'water');", "Inserted");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                alter_data("update eko.zabrudn set component_name='" + this.comboBox2.SelectedItem + "', value = '" + this.textBox4.Text + "' where company_name='" + this.comboBox1.SelectedItem + "' and area_name = 'atmosphere' and component_name='" + this.comboBox2.SelectedItem + "';", "Updated");
            if (tabControl1.SelectedIndex == 1)
                alter_data("update eko.zabrudn set component_name='" + this.comboBox2.SelectedItem + "', value = '" + this.textBox4.Text + "' where company_name='" + this.comboBox1.SelectedItem + "' and area_name = 'water' and component_name='" + this.comboBox2.SelectedItem + "';", "Updated");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                alter_data("delete from eko.zabrudn where component_name='" + this.comboBox2.SelectedItem + "' and area_name = 'atmosphere';", "Deleted");
            if (tabControl1.SelectedIndex == 1)
                alter_data("delete from eko.company where component_name='" + this.comboBox2.SelectedItem + "' and area_name = 'water';", "Deleted");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            FillGrid(dataGridView1, "atmosphere");
            FillGrid(dataGridView2, "water");
            highlight_cells(dataGridView1);
            highlight_cells(dataGridView2);
            count_tax(dataGridView1, "Total Atmosphere Tax: ", label1);
            count_tax(dataGridView2, "Total Water Tax: ", label2);
        }
    }
}
