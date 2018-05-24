using Data;
using Data.Entity;
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
    public partial class AddTemplateForm : Form
    {
        DBManager db = new DBManager();
        int user = 1;
        private int valueCol = 2;
        private int descCol = 1;

        public AddTemplateForm()
        {
            InitializeComponent();
        }

        private void AddTemplateForm_Load(object sender, EventArgs e)
        {
            db.Connect();
            var obj = db.GetRows("resource", "*", "");
            var resources = new List<Resource>();
            foreach (var row in obj)
            {
                resources.Add(ResourceMapper.Map(row));
            }


            resourcesLB.Items.AddRange(resources.ToArray());
            db.Disconnect();
        }

        private void commitValue(object sender, DataGridViewCellEventArgs e)
        {
            Resource res = materialListGrid.Rows[e.RowIndex].Cells[0].Value as Resource;
            if (e.RowIndex == valueCol)
                res.value = Int32.Parse(materialListGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            if (e.RowIndex == descCol)
                res.description = materialListGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            db.Connect();
            string temName = DBUtil.AddQuotes(nameTB.Text);
            string temDesc = DBUtil.AddQuotes(descTB.Text);

            string[] evFields = new string[] { "name", "description", "expert_id" };
            string[] evValues = new string[] { temName, temDesc, user.ToString() };

            int evId = db.InsertToBD("event_template", evFields, evValues);

            foreach (DataGridViewRow row in materialListGrid.Rows)
            {
                Resource res = row.Cells[0].Value as Resource;
                if (res != null)
                {
                    string desc = "";
                    string value = "";
                    //if (row.Cells[descCol].Value != null)
                    //    desc = DBUtil.AddQuotes(row.Cells[descCol].Value.ToString());
                    //if (row.Cells[valueCol].Value != null)
                    //    value = row.Cells[valueCol].Value.ToString();

                    string[] fields = { "template_id", "resource_id"};
                    string[] values = { evId.ToString(), res.id.ToString()};

                    db.InsertToBD("template_resource", fields, values);
                }
            }
            db.Disconnect();

        }

        private void resourcesLB_DoubleClick(object sender, EventArgs e)
        {
            Resource res = resourcesLB.SelectedItem as Resource;

            foreach(DataGridViewRow row in materialListGrid.Rows)
            {
                if (row.Cells[0].Value == res)
                    return;
            }
            materialListGrid.Rows.Add(res, res.description);
        }
    }
}
