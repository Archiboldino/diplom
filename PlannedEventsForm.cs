using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Data.Sql;
using Data;

namespace oprForm
{
	public partial class PlannedEventsForm : Form
	{
		DBManager db = new DBManager();
		String user = "Vasya";

		public PlannedEventsForm()
		{
			InitializeComponent();
		}

		private void PlannedEventsForm_Load(object sender, EventArgs e)
		{
			db.Connect();
			var obj = db.GetRows("actions", "*", "");
			var events = new List<Event>();
			foreach(var row in obj)
			{
				events.Add(EventMapper.Map(row));
			}
				

			eventsLB.Items.AddRange(events.ToArray());
			db.Disconnect();
		}

		private void LoadDataGrid()
		{
			//eventListGrid.Columns.
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//if (eventsLB.SelectedItem != null)
			//{
			//	Event ev = eventsLB.SelectedItem as Event;
			//	db.Connect();
			//	string[] values = { ev.id.ToString(), "'"+DateTime.Now.Date.ToString("yyyy-MM-dd HH")+"'", "'value?'",
			//		"'" + user + "'"};
			//	string[] fields = { "id_of_action", "date_of_action", "value", "user_name" };
			//	db.InsertToBD("action_list", fields, values);
			//}
			db.Connect();
			Event ev = eventsLB.SelectedItem as Event;
			var resourcesForEvent = db.GetRows("resource_of_action", "id_of_action, id_of_resource", "id_of_action=" + ev.id);
			var resources = new List<Resource>();
			foreach(var resForEvent in resourcesForEvent)
			{
				var res = db.GetRows("resources", "*", "id_of_resources=" + resForEvent[1]);
				resources.Add(ResourceMapper.Map(res[0]));
			}
			db.Disconnect();

			foreach(var r in resources)
			{
				var res = new DataGridViewRow();
				res.SetValues(r, r.description);
				eventListGrid.Rows.Add(res);
			}

		}

		private void eventsLB_SelectedIndexChanged(object sender, EventArgs e)
		{
			// TODO Confirmation if data entered
			db.Connect();
			Event ev = eventsLB.SelectedItem as Event;
			var resourcesForEvent = db.GetRows("resources_of_action", "id_of_action, id_of_resource", "id_of_action=" + ev.id);
			var resources = new List<Resource>();
			foreach(var resForEvent in resourcesForEvent)
			{
				var res = db.GetRows("resources", "*", "id_of_resource=" + resForEvent[1]);
				resources.Add(ResourceMapper.Map(res[0]));
			}

			eventListGrid.Rows.Clear();
			foreach(var r in resources)
			{
				eventListGrid.Rows.Add(r, r.description);
			}

			db.Disconnect();
		}

		private void commitValue(object sender, DataGridViewCellEventArgs e)
		{
			// TODO add on button
			// Add new resources
			Resource res = eventListGrid.Rows[e.RowIndex].Cells[0].Value as Resource;
			Event ev = eventsLB.SelectedItem as Event;
			db.Connect();
			string[] fields = { "event_id", "resource_id", "value" };
			string[] values = { ev.id.ToString(), res.id.ToString(), eventListGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() };
			db.InsertToBD("event_resources", fields, values);
		}

	}

	//class EventMapper : Mapper<Event>
	//{
	//	public Event Map(IDataReader reader)
	//	{
	//		var e = new Event();
	//		e.id = reader.GetInt32(0);
	//		e.name = reader.GetString(1);
	//		e.description = reader.GetString(2);
	//		e.actionCol = reader.GetString(3);

	//		return e;
	//	}
	//}
	class EventMapper 
	{
		public static Event Map(List<Object> row)
		{
			var e = new Event();
			e.id = Int32.Parse(row[0].ToString());
			e.name = row[1].ToString();
			e.description = row[2].ToString();
			e.actionCol = row[3].ToString();

			return e;
		}
	}

	class ResourceMapper 
	{
		public static Resource Map(List<Object> row)
		{
			var r = new Resource();
			r.id = Int32.Parse(row[0].ToString());
			r.name = row[1].ToString();
			r.description = row[2].ToString();

			return r;
		}
	}

	class Event
	{
		public int id;
		public string name;
		public string description;
		public string actionCol;

		public override string ToString()
		{
			return id + " " + name + " " + description + " " + actionCol;
		}
	}
	class Resource
	{
		public int id;
		public string name;
		public string description;

		public override string ToString()
		{
			return name;
		}
	}
}						  
