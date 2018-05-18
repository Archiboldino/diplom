using Data;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oprForm
{
    public partial class AlterEventForm : Form
    {
        private DBManager db = new DBManager();
        private int valueCol = 2;
        private int descCol = 1;

        public AlterEventForm()
        {
            InitializeComponent();
            db.Connect();

            getEvents();

            issuesCB.Items.Clear();
            var iss = db.GetRows("issues", "*", "");
            var issues = new List<Issue>();
            foreach (var row in iss)
            {
                issues.Add(IssueMapper.Map(row));
            }

            issuesCB.Items.AddRange(issues.ToArray());
            issuesCB.SelectedIndex = 0;

            var res = db.GetRows("resource", "*", "");
            var resources = new List<Resource>();
            foreach (var row in res)
            {
                resources.Add(ResourceMapper.Map(row));
            }
            resLB.Items.AddRange(resources.ToArray());

            db.Disconnect();
        }

        private void getEvents()
        {
            eventsLB.Items.Clear();
            var obj = db.GetRows("event", "*", "");
            var events = new List<Event>();
            foreach (var row in obj)
            {
                events.Add(EventMapper.Map(row));
            }

            eventsLB.Items.AddRange(events.ToArray());
        }

        private void eventsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO Confirmation if data entered
            if (eventsLB.SelectedItem is Event)
            {
                if (eventsLB.SelectedItem is Event)
                {
                    Event ev = eventsLB.SelectedItem as Event;
                    alterGB.Visible = true;
                    db.Connect();
                    var resourcesForEvent = db.GetRows("event_resource", "event_id, resource_id, description, value",
                        "event_id=" + ev.id);
                    var resources = new List<Resource>();
                    foreach (var resForEvent in resourcesForEvent)
                    {
                        var res = db.GetRows("resource", "*", "resource_id=" + resForEvent[1]);
                        var resource = ResourceMapper.Map(res[0]);
                        resource.description = resForEvent[2].ToString();
                        resource.value = Int32.Parse(resForEvent[3].ToString());
                        resources.Add(resource);
                    }

                    eventListGrid.Rows.Clear();
                    foreach (var r in resources)
                    {
                        eventListGrid.Rows.Add(r, r.description, r.value);
                    }

                    updateEvent(ev);

                    db.Disconnect();
                }
            }
        }

        private void commitValue(object sender, DataGridViewCellEventArgs e)
        {
            if (eventListGrid.Rows[e.RowIndex].Cells[0].Value is Resource)
            {
                var res = eventListGrid.Rows[e.RowIndex].Cells[0].Value as Resource;
                if (e.ColumnIndex == valueCol)
                {
                    try
                    {
                        var val = Int32.Parse(eventListGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        if (val > 0)
                        {
                            res.value = val;
                            return;
                        }
                        else
                            throw new ArgumentException();
                    }
                    catch (FormatException)
                    {
                        cancelEdit();
                        MessageBox.Show("Введiть цiле число.");
                        return;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Число повинно бути > 0");
                    }
                }
                if (e.ColumnIndex == descCol)
                {
                    var val = eventListGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
        }

        private void updateEvent(Event ev)
        {
            evNameTB.Text = ev.name;
            descTB.Text = ev.description;

            foreach (var i in issuesCB.Items)
            {
                if (i is Issue)
                {
                    var iss = i as Issue;
                    if (iss.id == ev.issueId)
                    {
                        issuesCB.SelectedItem = iss;
                    }
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Видалити захiд?", "Видалення", MessageBoxButtons.YesNo);

            if (confirm.Equals(DialogResult.Yes) && eventsLB.SelectedItem is Event)
            {
                Event ev = eventsLB.SelectedItem as Event;
                db.Connect();
                db.DeleteFromDB("event", "event_id", ev.id.ToString());
                getEvents();
                db.Disconnect();
                eventListGrid.Rows.Clear();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var ev = eventsLB.SelectedItem as Event;
            db.Connect();
            string[] cols = { "event_id", "name", "description", "issue_id" };
            string[] values = { ev.id.ToString(), DBUtil.AddQuotes(evNameTB.Text), DBUtil.AddQuotes(descTB.Text), (issuesCB.SelectedItem as Issue).id.ToString() };

            db.UpdateRecord("event", cols, values);

            //Get all resources for thar event
            var ress = db.GetRows("event_resource", "resource_id", "event_id=" + ev.id);

            //Update resources for event
            foreach (DataGridViewRow row in eventListGrid.Rows)
            {
                var res = row.Cells[0].Value as Resource;

                //Remove present resources to delete left ones
                ress.RemoveAll(o => Int32.Parse(o[0].ToString()) == res.id);

                string[] resCols = { "event_id", "value", "description" };
                string[] resValues = { ev.id + " AND resource_id=" + res.id, res.value.ToString(), DBUtil.AddQuotes(res.description) };
                if (db.UpdateRecord("event_resource", resCols, resValues) == 0)
                {
                    string[] resColsIns = { "event_id", "resource_id", "value", "description" };
                    string[] resValuesIns = { ev.id.ToString(), res.id.ToString(), res.value.ToString(), DBUtil.AddQuotes(res.description) };
                    db.InsertToBDWithoutId("event_resource", resColsIns, resValuesIns);
                }
            }

            //Delete resources thar are not in grid view
            foreach (var resId in ress)
            {
                string resCols = "event_id";
                string resValues = ev.id + " AND resource_id=" + resId[0].ToString();

                db.DeleteFromDB("event_resource", resCols, resValues);
            }

            db.Disconnect();
        }

        private void addMaterial(object sender, EventArgs e)
        {
            Resource res = resLB.SelectedItem as Resource;

            foreach (DataGridViewRow row in eventListGrid.Rows)
            {
                if (row.Cells[0].Value.Equals(res))
                    return;
            }
            eventListGrid.Rows.Add(res, res.description);
        }
    }
}