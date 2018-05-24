using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFileBase;
using Data;
namespace experts_jurist
{
	public partial class issuesAttachDocs : Form
	{
		/// <summary>
		/// Екземпляр классу DBManager, що використовується для доступу до бази данних.
		/// </summary>
		private DBManager db = new DBManager();
		/// <summary>
		/// Екземпляр классу SearchManager, що використовується для пошуку по файловій базі законодавчих документів.
		/// </summary>
		private SearchManager SM = new SearchManager();

		protected int currentIssueID;

		/// <summary>
		/// Змінна для збереження списку прикріплених до поточного заходу файлів.
		/// </summary>
		private List<string> listOfAttachedFi = new List<string>();

		private List<string> listOfSearchedFi = new List<string>();
		private Dictionary<string, int> listOfAll = new Dictionary<string, int>();
		/* 0 - знайдено
		 * 1 - прикріплено по дефолту
		 * 2 - відкріплено
		 * 3 - прикріплено по новому
		 */

		public issuesAttachDocs()
		{
			InitializeComponent();
			db.Connect();
		}
		public issuesAttachDocs(int currentIssueID)
		{
			db.Connect();
			this.currentIssueID = currentIssueID;
			InitializeComponent();
		}


		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				button3.Enabled = true;
				listBox2.ClearSelected();
				webBrowser1.DocumentText = SM.GetPage(listOfSearchedFi[listBox1.SelectedIndex].ToString());
			}
			else
			{
				button3.Enabled = false;
			}
		}



		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox2.SelectedIndex > -1)
			{
				button5.Enabled = true;
				listBox1.ClearSelected();
				webBrowser1.DocumentText = SM.GetPage(listOfAttachedFi[listBox2.SelectedIndex].ToString());
			}
			else
			{
				button5.Enabled = false;
			}
		}



		private void button6_Click(object sender, EventArgs e)
		{
			var listOfFi = SM.SearchAll();
			if (listOfFi.Count() == 0)
			{
				label5.Text = "Нічого не знайдено";
			}
			else
			{
				label5.Text = "Всі документи";
			}

			listOfSearchedFi.Clear();
			listBox1.Items.Clear();
			foreach (var a in listOfFi)
			{

				if (!listOfAll.ContainsKey(a))
				{
					listOfAll[a] = 0;
					listOfSearchedFi.Add(a);
				}
				else
				{
					if (listOfAll[a] == 0 || listOfAll[a] == 2)
						listOfSearchedFi.Add(a);
				}
			}
			ReloadLists();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			switch (listOfAll[listOfAttachedFi[listBox2.SelectedIndex]])
			{
				case 3:
					listOfAll[listOfAttachedFi[listBox2.SelectedIndex]] = 0;
					break;
				case 1:
					listOfAll[listOfAttachedFi[listBox2.SelectedIndex]] = 2;
					break;
			}
			listOfSearchedFi.Insert(0, listOfAttachedFi[listBox2.SelectedIndex]);
			listOfAttachedFi.RemoveAt(listBox2.SelectedIndex);
			var temp = listBox2.SelectedItem;
			listBox1.Items.Insert(0, temp);
			listBox2.Items.RemoveAt(listBox2.SelectedIndex);
			listBox1.SetSelected(listBox1.Items.IndexOf(temp), true);
			if (listOfAttachedFi.Count() == 0)
				button1.Enabled = false;
		}
		private void button3_Click(object sender, EventArgs e)
		{
			switch (listOfAll[listOfSearchedFi[listBox1.SelectedIndex]])
			{
				case 0:
					listOfAll[listOfSearchedFi[listBox1.SelectedIndex]] = 3;
					break;
				case 2:
					listOfAll[listOfSearchedFi[listBox1.SelectedIndex]] = 1;
					break;
			}
			listOfAttachedFi.Add(listOfSearchedFi[listBox1.SelectedIndex]);
			listOfSearchedFi.RemoveAt(listBox1.SelectedIndex);
			var temp = listBox1.SelectedItem;
			listBox2.Items.Add(temp);
			listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			listBox2.SetSelected(listBox2.Items.IndexOf(temp), true);
			button1.Enabled = true;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			var temp = new issuesAttachResult(currentIssueID, listOfAttachedFi, listOfAll);
			if (temp.ShowDialog() == DialogResult.OK)
			{
				DialogResult = DialogResult.OK;
			}
			else
			{
				this.Show();
			}

		}
		private void ReloadLists()
		{
			listBox2.Items.Clear();
			foreach (var a in listOfAttachedFi)
			{
				if (listOfAll[a] == 1 || listOfAll[a] == 3)
				{
					listBox2.Items.Add(SM.GetPrewiew(a));
				}
			}
			foreach (var a in listOfSearchedFi)
			{
				if (listOfAll[a] == 0 || listOfAll[a] == 2)
				{
					listBox1.Items.Add(SM.GetPrewiew(a));
				}
			}
			webBrowser1.DocumentText = "";
		}
		private void button4_Click(object sender, EventArgs e)
		{

			var listOfFi = SM.SearchLine(textBox2.Text);
			if (listOfFi.Count() == 0)
			{
				label5.Text = "Нічого не знайдено";
			}
			else
			{
				label5.Text = "Знайдені документи";
			}
			listOfSearchedFi.Clear();
			listBox1.Items.Clear();
			foreach (var a in listOfFi)
			{

				if (!listOfAll.ContainsKey(a))
				{
					listOfAll[a] = 0;
					listOfSearchedFi.Add(a);
				}
				else
				{
					if (listOfAll[a] == 0 || listOfAll[a] == 2)
						listOfSearchedFi.Add(a);
				}
			}
			ReloadLists();
		}

		private void issuesAttachDocs_Load(object sender, EventArgs e)
		{
			var temp = db.GetRows("issues_documents", "document_code", "issue_id=" + DBUtil.ValidateForSQL(currentIssueID));
			foreach (var a in temp)
			{
				listOfAttachedFi.Add((string)a[0]);
				listOfAll[(string)a[0]] = 1;
			}
			if (listOfAttachedFi.Count() > 0)
				button1.Enabled = true;
			temp = db.GetRows("issues", "name, description", "issue_id=" + DBUtil.ValidateForSQL(currentIssueID));
			textBox2.Text = (string)temp[0][1] + " " + (string)temp[0][0];
			button4_Click(sender, e);
		}
	}
}
