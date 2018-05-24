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
	public partial class issues : Form
	{

		/// <summary>
		/// Екземпляр классу DBManager, що використовується для доступу до бази данних.
		/// </summary>
		private DBManager db;
		/// <summary>
		/// Екземпляр классу SearchManager, що використовується для пошуку по файловій базі законодавчих документів.
		/// </summary>
		private SearchManager SM;
		/// <summary>
		/// Змінна для збереження списку завдань.
		/// </summary>
		private List<List<object>> listOfIssues;
		/// <summary>
		/// Змінна для збереження списку прикріплених до поточного заходу файлів.
		/// </summary>
		private List<List<object>> listOfAttachedFi;
		/// <summary>
		/// Змінна для збереження індексу.
		/// </summary>
		/// <summary>
		/// Конструктор.
		/// </summary>
		public issues()
		{
			InitializeComponent();
			db = new DBManager();
			db.Connect();
			SM = new SearchManager();
			ReloadData1();
		}

		private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1)
			{
				ReloadSelected();
			}
			else
			{
				ReloadData1();
			}
				
					//currentIssue = listOfIssues[listBox1.SelectedIndex][0].ToString();
		}

		private void ReloadData1()
		{
			listBox2.Items.Clear();
			listOfIssues = db.GetRows("issues", "*", "");
			textBox1.Text = "";
			button1.Enabled = false;
			listBox1.Items.Clear();
			foreach (var row in listOfIssues)
			{
				listBox1.Items.Add(row[1]);
			}
		}
		private void ReloadSelected()
		{
			if (listBox1.SelectedIndex != -1)
			{

				try
				{
					listOfAttachedFi = db.GetRows("issues_documents", "*", "issue_id=" + DBUtil.ValidateForSQL(listOfIssues[listBox1.SelectedIndex][0]));
					button1.Enabled = true;
					ReloadAttached();
				}
				catch (Exception)
				{

				}
				textBox1.Text = listOfIssues[listBox1.SelectedIndex][2].ToString();
			}
		}


		private void ReloadAttached()
		{
			textBox3.Text = "";
			listBox2.Items.Clear();
			if ( listBox1.SelectedIndex >= 0)
			{
				listOfAttachedFi = db.GetRows("issues_documents", "*", "issue_id=" + DBUtil.ValidateForSQL(listOfIssues[listBox1.SelectedIndex][0]));
				var b = new List<string>();
				foreach (var c in listOfAttachedFi)
				{
					b.Add(c[1].ToString());
				}
				textBox3.Text = "";
				listBox2.Items.Clear();
				foreach (var g in b)
				{
					listBox2.Items.Add(SM.GetPrewiew(g));
				}
				webBrowser1.DocumentText = "";
			}
		}
		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox2.SelectedIndex >= 0)
			{
				textBox3.Text = listOfAttachedFi[listBox2.SelectedIndex][2].ToString();
				webBrowser1.DocumentText = SM.GetPage(listOfAttachedFi[listBox2.SelectedIndex][1].ToString());

			}

		}


		private void button1_Click(object sender, EventArgs e)
		{
			var tempWin = new issuesAttachDocs((int)listOfIssues[listBox1.SelectedIndex][0]);
			if (tempWin.ShowDialog() == DialogResult.OK)
			{
				listBox1_SelectedIndexChanged(sender, e);
			}
		}

		private void issues_Load(object sender, EventArgs e)
		{
			ReloadData1();
		}
	}
}
