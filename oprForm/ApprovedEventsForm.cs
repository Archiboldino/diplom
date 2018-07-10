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
    public partial class ApprovedEventsForm : Form
    {
        DBManager db = new DBManager();
        private List<Event> events = new List<Event>();
        private List<Document> issueDocs = new List<Document>();
        private Dictionary<int, int> expertOfUser = new Dictionary<int, int>();
        public ApprovedEventsForm()
        {
            InitializeComponent();
            db.Connect();
            //var obj = db.GetRows("event", "*", "");
            //var events = new List<Event>();
            //foreach (var row in obj)
            //{
            //    events.Add(EventMapper.Map(row));
            //}
            var obj = db.GetRows("issues", "*", "issue_id in (select issue_id from event where dm_verification=TRUE)");
            var issues = new List<Issue>();
            foreach (var row in obj)
            {
                issues.Add(IssueMapper.Map(row));
            }


            issuesLB.Items.AddRange(issues.ToArray());
            db.Disconnect();
        }

        private void eventsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventsLB.SelectedItem is Event)
            {
                Event ev = eventsLB.SelectedItem as Event;
                approveGB.Visible = true;
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
                double totalPrice = 0;
                foreach (var r in resources)
                {
                    eventListGrid.Rows.Add(r, r.description, r.value, r.unit, r.price, r.value * r.price);
                    totalPrice += r.value * r.price;
                }
                totalPriceLbl.Text = totalPrice.ToString();

                updateEvent(ev);

                var docObj = db.GetRows("event_documents", "*", "event_id=" + ev.id);
                var docs = new List<Document>();
                foreach (var row in docObj)
                {
                    docs.Add(DocumentMapper.Map(row));
                }
                docsLB.Items.Clear();
                docsLB.Items.AddRange(issueDocs.ToArray());
                docsLB.Items.AddRange(docs.ToArray());

                db.Disconnect();
            }

        }

        private string ukrBool(string str)
        {
            return str == "" ? "не переглянуто" : str.Equals("0") ? "нi" : "так";
        }

        private void updateEvent(Event ev)
        {
            eventDescLabel.Text = ev.description;
            //dmApprLbl.Text = ukrBool(ev.dmVer);
            //lawyerApprLbl.Text = ukrBool(ev.lawyerVer);
            var obj = db.GetRows("planned_event", "*", "event_id=" + ev.id);

            startLbl.Text = obj[0][1].ToString();
            endLbl.Text = obj[0][2].ToString();
            vidpovLbl.Text = obj[0][3].ToString();

            if (ev.issueId != -1)
            {
                var issName = db.GetValue("issues", "name", "issue_id=" + ev.issueId);
                issueLbl.Text = issName.ToString();
            }
            else
            {
                issueLbl.Text = "Net";
            }
        }

        private void docsLB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (docsLB.SelectedItem is Document)
            {
                var doc = docsLB.SelectedItem as Document;
                var child = new DocumentViewForm(doc.document_code);
                child.ShowDialog(this);
            }
        }

        private void expertsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expertsLB.SelectedItem is Expert)
            {
                var expert = expertsLB.SelectedItem as Expert;
                eventsLB.Items.Clear();
                if (expert.id == -1)
                {
                    eventsLB.Items.AddRange(events.ToArray());
                }
                else
                {
                    eventsLB.Items.AddRange((from ev in events where expertOfUser[ev.userId] == expert.id select ev).ToArray());
                }
            }
        }

        private double GetTotalCost(int eventId)
        {
            //db.Connect();
            var resourcesForEvent = db.GetRows("event_resource", "event_id, resource_id, description, value",
                "event_id=" + eventId);
            var resources = new List<Resource>();
            foreach (var resForEvent in resourcesForEvent)
            {
                var res = db.GetRows("resource", "*", "resource_id=" + resForEvent[1]);
                var resource = ResourceMapper.Map(res[0]);
                resource.description = resForEvent[2].ToString();
                resource.value = Int32.Parse(resForEvent[3].ToString());
                resources.Add(resource);
            }

            double totalPrice = 0;
            foreach (var r in resources)
            {
                totalPrice += r.value * r.price;
            }

            return totalPrice;
        }

        private void issuesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (issuesLB.SelectedItem is Issue)
            {
                Issue iss = issuesLB.SelectedItem as Issue;
                eventsLB.Items.Clear();
                db.Connect();
                var obj = db.GetRows("event", "*", "issue_id=" + (issuesLB.SelectedItem as Issue).id +
                    " AND dm_verification=TRUE");
                if (obj.Count != 0)
                {
                    events.Clear();
                    foreach (var row in obj)
                    {
                        events.Add(EventMapper.Map(row));
                    }

                    double issueCost = 0;
                    foreach (var ev in events)
                    {
                        issueCost += GetTotalCost(ev.id);
                    }
                    issueCostLbl.Text = issueCost.ToString();

                    // Get list of user ids
                    var userIds = (from ev in events select Int32.Parse(ev.userId.ToString())).ToArray();

                    // Get list of expert ids from users
                    List<int> expertIds = new List<int>();
                    foreach (var uid in userIds)
                    {
                        expertIds.Add(Int32.Parse(db.GetValue("user", "id_of_expert", "id_of_user=" + uid).ToString()));
                    }
                    obj = db.GetRows("expert", "distinct id_of_expert, expert_name", "id_of_expert in (" + String.Join(",", expertIds) + ")");

                    for (int i = 0; i < userIds.Length; i++)
                    {
                        expertOfUser[userIds[i]] = expertIds[i];
                    }

                    var experts = new List<Expert>();

                    var emptyExpert = new Expert();
                    emptyExpert.id = -1;
                    emptyExpert.name = "Усі";
                    experts.Add(emptyExpert);

                    expertsLB.Items.Clear();
                    foreach (var row in obj)
                    {
                        experts.Add(ExpertMapper.Map(row));
                    }
                    expertsLB.Items.AddRange(experts.ToArray());

                }
                var issDocs = db.GetRows("issues_documents", "*", "issue_id=" + iss.id);
                issueDocs.Clear();
                foreach(var o in issDocs)
                {
                    issueDocs.Add(DocumentMapper.Map(o));
                }
                db.Disconnect();

                docsLB.Items.Clear();
                docsLB.Items.AddRange(issueDocs.ToArray());
            }

        }
    }
}
