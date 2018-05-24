using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using LawFileBase;
namespace experts_jurist
{
	public partial class analisResult : Form
	{
		private DBManager db = new DBManager();
		private SearchManager SM = new SearchManager();
		protected int currentEventID;
		private List<string> listOfAttachedFi = new List<string>();
		private Dictionary<string, int> listOfAll = new Dictionary<string, int>();
		private List<List<object>> listOfAttachedRaws = new List<List<object>>();
		private List<string> listOfDelate = new List<string>();
		public analisResult()
		{
			db.Connect();
			InitializeComponent();
		}
		public analisResult(int currentEventID, List<string> listOfAttachedFi, Dictionary<string, int> listOfAll)
		{
			db.Connect();
			InitializeComponent();
			this.listOfAttachedFi = listOfAttachedFi;
			this.listOfAll = listOfAll;
			this.currentEventID = currentEventID;
		}
		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

			doData();
			db.UpdateRecord("event",
					new String[] {
						"event_id",
						"lawyer_vefirication"
					}, new String[] {
						DBUtil.ValidateForSQL(currentEventID),
						"1"
					});
			DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			doData();
			db.UpdateRecord("event",
					new String[] {
						"event_id",
						"lawyer_vefirication"
					}, new String[] {
						DBUtil.ValidateForSQL(currentEventID),
						"0"
					});
			DialogResult = DialogResult.OK;
		}
		private void doData()
		{
			foreach(var a in listOfDelate)
			{
				db.DeleteFromDB("event_documents", new String[] {
						"event_id",
						"document_code"
					}, new String[] {
						DBUtil.ValidateForSQL(currentEventID),
						DBUtil.ValidateForSQL(a)
					}); 
			}
			foreach(var a in listOfAttachedRaws)
			{
				switch(listOfAll[(string)a[1]]){
					case 3:
						db.InsertToBD("event_documents",
							new string[] {
							"event_id",
							"document_code",
							"description"
							}, new string[] {
							DBUtil.ValidateForSQL(a[0]),
							DBUtil.ValidateForSQL(a[1]),
							DBUtil.ValidateForSQL(a[2])
							});
						break;
					case 1:
						db.SetValue("event_documents", "description", DBUtil.ValidateForSQL(a[2]),
							"(event_id=" +
							a[0] +
							" AND document_code=" +
							DBUtil.ValidateForSQL(a[1])+")");//я исправил сетвальюе в либе дб
						break;
				}
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			foreach(var a in listOfAll)
			{
				if(a.Value==2)
				{
					listOfDelate.Add(a.Key);
				}
			}
			var temp = new List<object>();
			temp.Add(currentEventID);
			temp.Add("");
			temp.Add("");
			foreach (var a in listOfAttachedFi)
			{
				if (listOfAll[a] == 3 || listOfAll[a] == 1)
				{
					temp[1] = a;
					if(listOfAll[a] == 1)
					{
						temp[2] = db.GetValue("event_documents", "description", "event_id = " + currentEventID + " AND document_code = " + DBUtil.ValidateForSQL(a));
					}
					else
					{
						temp[2] = "";
					}
					listOfAttachedRaws.Add(new List<object>(temp));
				}
			}
			foreach (var a in listOfAttachedFi)
			{
				if (listOfAll[a] == 1 || listOfAll[a] == 3)
				{
					listBox2.Items.Add(SM.GetPrewiew(a));
				}
			}
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox2.SelectedIndex > -1)
			{
				textBox3.Text = (string)listOfAttachedRaws[listBox2.SelectedIndex][2];
				webBrowser1.DocumentText = SM.GetPage((string)listOfAttachedRaws[listBox2.SelectedIndex][1]);
			}
			else
			{
				textBox3.Text = "";
				webBrowser1.DocumentText = "";
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			listOfAttachedRaws[listBox2.SelectedIndex][2] = textBox3.Text;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.None;
		}
	}
}
