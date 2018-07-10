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
    public partial class SetDateForm : Form
    {
        private DBManager db = new DBManager();

        private Event ev;

        public SetDateForm(Event ev)
        {
            this.ev = ev;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Connect();
            ev.dmVer = "1";

            string[] cols = { "event_id", "dm_verification" };
            string[] values = { ev.id.ToString(), true.ToString() };
            db.UpdateRecord("event", cols, values);

            string[] colsPlanned = { "event_id", "start_date", "end_date", "responsible" };

            string startDate = startDP.Value.Date.ToString("yyyy-MM-dd");
            string endDate = endDP.Value.Date.ToString("yyyy-MM-dd");
            string[] valuesPlanned = { ev.id.ToString(), DBUtil.AddQuotes(startDate), DBUtil.AddQuotes(endDate), DBUtil.AddQuotes(respTB.Text) };
            db.InsertToBD("planned_event", colsPlanned, valuesPlanned);

            db.Disconnect();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
