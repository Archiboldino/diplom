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
    public partial class AlterTemplateForm : Form
    {
        DBManager db = new DBManager();
        int user = 1;
        private int valueCol = 2;
        private int descCol = 1;

        public AlterTemplateForm()
        {
            InitializeComponent();
            db.Connect();
            var obj = db.GetRows("event_template", "*", "");
            var events = new List<Event>();
            foreach (var row in obj)
            {
                events.Add(EventTemplateMapper.Map(row));
            }
            templatesLB.Items.AddRange(events.ToArray());


            var res = db.GetRows("resource", "*", "");
            var resources = new List<Resource>();
            foreach (var row in res)
            {
                resources.Add(ResourceMapper.Map(row));
            }
            resourcesLB.Items.AddRange(resources.ToArray());

            db.Disconnect();

        }

        private void resourcesLB_DoubleClick(object sender, EventArgs e)
        {
            Resource res = resourcesLB.SelectedItem as Resource;

            foreach (DataGridViewRow row in materialListGrid.Rows)
            {
                if ((row.Cells[0].Value as Resource).id == res.id)
                    return;
            }
            materialListGrid.Rows.Add(res, res.description);
        }

        private void templatesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO Confirmation if data entered
            if (templatesLB.SelectedItem is Event)
            {
                Event ev = templatesLB.SelectedItem as Event;
                addGB.Visible = true;
                db.Connect();
                var resourcesForEvent = db.GetRows("template_resource", "template_id, resource_id",
                    "template_id=" + ev.id);
                var resources = new List<Resource>();
                foreach (var resForEvent in resourcesForEvent)
                {
                    var res = db.GetRows("resource", "*", "resource_id=" + resForEvent[1]);
                    resources.Add(ResourceMapper.Map(res[0]));
                }

                materialListGrid.Rows.Clear();
                foreach (var r in resources)
                {
                    materialListGrid.Rows.Add(r, r.description);
                }
                descTB.Text = ev.description;
                nameTB.Text = ev.name;

                db.Disconnect();
            }

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var ev = templatesLB.SelectedItem as Event;
            db.Connect();
            string[] cols = { "template_id", "name", "description" };
            string[] values = { ev.id.ToString(), DBUtil.AddQuotes(nameTB.Text), DBUtil.AddQuotes(descTB.Text) };

            ev.name = nameTB.Text;
            ev.description = descTB.Text;

            templatesLB.Refresh();

            db.UpdateRecord("event_template", cols, values);

            //Get all resources for thar template
            var ress = db.GetRows("template_resource", "resource_id", "template_id=" + ev.id);

            //Update resources for event
            foreach (DataGridViewRow row in materialListGrid.Rows)
            {
                var res = row.Cells[0].Value as Resource;

                //Remove present resources to delete left ones
                ress.RemoveAll(o => Int32.Parse(o[0].ToString()) == res.id);

                string[] resCols = { "template_id" };
                string[] resValues = { ev.id + " AND resource_id=" + res.id };
                if (db.GetRows("template_resource", "*", "template_id=" + ev.id + " AND resource_id=" + res.id).Count == 0)
                {
                    string[] resColsIns = { "template_id", "resource_id" };
                    string[] resValuesIns = { ev.id.ToString(), res.id.ToString() };
                    db.InsertToBDWithoutId("template_resource", resColsIns, resValuesIns);
                }
            }

            //Delete resources thar are not in grid view
            foreach (var resId in ress)
            {
                string resCols = "template_id";
                string resValues = ev.id + " AND resource_id=" + resId[0].ToString();

                db.DeleteFromDB("template_resource", resCols, resValues);
            }

            db.Disconnect();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (templatesLB.SelectedItem is Event)
            {
                Event ev = templatesLB.SelectedItem as Event;
                db.Connect();
                db.DeleteFromDB("event_template", "template_id", ev.id.ToString());
                db.Disconnect();

                templatesLB.Items.Remove(ev);
            }
        }
    }
}
