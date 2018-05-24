using Data;
using Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oprForm
{
    public partial class MaterialsForm : Form
    {
        private DBManager db = new DBManager();
        int nameColIdx = 0;
        int descColIdx = 1;
        Resource saved;

        public MaterialsForm()
        {
            InitializeComponent();

            getMaterials();
        }

        private void getMaterials()
        {
            resDGV.Rows.Clear();
            db.Connect();
            var obj = db.GetRows("resource", "*", "");
            var res = new List<Resource>();
            foreach (var row in obj)
            {
                res.Add(ResourceMapper.Map(row));
            }

            foreach (var r in res)
            {
                resDGV.Rows.Add(r, r.description);
            }

            db.Disconnect();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var selected = resDGV.SelectedRows;
            foreach (DataGridViewRow row in selected)
            {
                if (row.Cells[0].Value is Resource)
                {
                    var res = row.Cells[0].Value as Resource;
                    try
                    {
                        db.Connect();
                        string cols = "resource_id";
                        string values = res.id.ToString();

                        db.DeleteFromDB("resource", cols, values);
                        resDGV.Rows.Remove(row);
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1451)
                        {
                            MessageBox.Show("Ресурс використовуэться.");
                        }
                    }
                    finally
                    {
                        db.Disconnect();
                    }

                }
            }
        }

        private void commitValue(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == nameColIdx)
            {
                var val = resDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (val.Length != 0 && !val.Equals(" "))
                {
                    saved.name = val;
                }
                else
                {
                    MessageBox.Show("Назвe не повиннa бути пустa.");
                }
                resDGV.Rows[e.RowIndex].Cells[0].Value = saved;
                return;
            }
            if (resDGV.Rows[e.RowIndex].Cells[0].Value is Resource)
            {
                var res = resDGV.Rows[e.RowIndex].Cells[0].Value as Resource;
                if (e.ColumnIndex == descColIdx)
                {
                    var val = resDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (val.Length != 0 && !val.Equals(" "))
                        res.description = val;
                    else
                    {
                        MessageBox.Show("Опис не повинен бути пустим.");
                    }
                }
            }
        }

        private void cancelEdit()
        {
            //TODO
            return;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in resDGV.Rows)
            {
                if (row.Cells[0].Value is Resource)
                {
                    var res = row.Cells[0].Value as Resource;
                    db.Connect();

                    string[] cols = { "resource_id", "name", "description" };
                    string[] values = { res.id.ToString(), DBUtil.AddQuotes(res.name), DBUtil.AddQuotes(res.description) };

                    db.UpdateRecord("resource", cols, values);

                    db.Disconnect();
                }
            }
        }

        private void cacheResFromFirstCol(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == nameColIdx)
            {
                saved = resDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Resource;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var form = new AddMaterialForm();
            form.ShowDialog(this);
            getMaterials();
        }
    }
}
