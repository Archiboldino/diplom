using LawFileBase;
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

namespace experts_jurist
{
    public partial class estimate : Form
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
        /// Змінна для збереження списку заходів.
        /// </summary>
        private List<List<object>> listOfEvents;
        /// <summary>
        /// Змінна для збереження списку завдань.
        /// </summary>
        private List<List<object>> listOfIssues;
        /// <summary>
        /// Змінна для збереження списку файлів, що є результатом пошуку.
        /// </summary>
        private string[] listOfFi = { };
        /// <summary>
        /// Змінна, що вказує чи відображаємо ми зараз заходи. Має значення false, якщо відображаємо завдання.
        /// </summary>
        private bool listOnEvents = false;
        /// <summary>
        /// Змінна для збереження списку прикріплених до поточного заходу файлів.
        /// </summary>
        private List<List<object>> listOfAttachedFi;
        /// <summary>
        /// Вибране завдання.
        /// </summary>
        private string currentIssue = "";
        /// <summary>
        /// Змінна для збереження індексу.
        /// </summary>
		/// <summary>
		/// Конструктор.
		/// </summary>
		public estimate()
        {
            InitializeComponent();
            db = new DBManager();
            db.Connect();
            SM = new SearchManager();
            ReloadData1();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOnEvents)
            {
                if(listBox1.SelectedIndex != 0)
                {
                    ReloadSelected();
				} else
                {
                    listOnEvents = false;
					currentIssue = "";
                    ReloadData1();
                }
            } else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    listOnEvents = true;
                    currentIssue = listOfIssues[listBox1.SelectedIndex][0].ToString();
                    ReloadData2();
                }
            }
        }
		
        private void ReloadData1()
		{
			listBox2.Items.Clear();
			listOfIssues = db.GetRows("issues", "*", "");
            label2.Text = "Список проблем";
            textBox1.Text = "";
            label1.Text = "";
			button1.Enabled = false;
            listBox1.Items.Clear();
            foreach (var row in listOfIssues)
            {
                listBox1.Items.Add(row[1]);
            }
        }
        private void ReloadData2()
        {
            listOfEvents = db.GetRows("event", "*", "issue_id="+ currentIssue);
            label2.Text = "Список заходів";
            listBox1.Items.Clear();
            listBox1.Items.Add("← До проблем");
            foreach (var row in listOfEvents)
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
					listOfAttachedFi = db.GetRows("event_documents", "*", "event_id=" + DBUtil.ValidateForSQL(listOfEvents[listBox1.SelectedIndex - 1][0]));
					button1.Enabled = true;
					ReloadAttached();
				}
				catch (Exception)
				{

				}
                textBox1.Text = listOfEvents[listBox1.SelectedIndex-1][2].ToString();
                switch (listOfEvents[listBox1.SelectedIndex-1][4].ToString())
                {
                    case "":
                        label1.Text = "Законність не перевірена";
                        label1.ForeColor = Color.DarkViolet;
                        break;
                    case "1":
                        label1.Text = "Законність перевірена та підтверджена";
                        label1.ForeColor = Color.Green;
                        break;
                    case "0":
                        label1.Text = "Законність перевірена та не підтверджена";
                        label1.ForeColor = Color.Red;
                        break;
                }
            }
        }
        
        
        private void ReloadAttached()
        {
			textBox3.Text = "";
			listBox2.Items.Clear();
			if (currentIssue != "" && listBox1.SelectedIndex > 0)
            {
				listOfAttachedFi = db.GetRows("event_documents", "*", "event_id=" + DBUtil.ValidateForSQL(listOfEvents[listBox1.SelectedIndex - 1][0]));
                var b = new List<string>();
                foreach (var c in listOfAttachedFi)
                {
                    b.Add(c[1].ToString());
                }
                listOfFi = b.ToArray();
				textBox3.Text = "";
				listBox2.Items.Clear();
				foreach (var g in listOfFi)
				{
					listBox2.Items.Add(SM.GetPrewiew(g));
				}
				webBrowser1.DocumentText = "";
			}
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex >= 0)
			{
				textBox3.Text = listOfAttachedFi[listBox2.SelectedIndex][2].ToString();
                webBrowser1.DocumentText = SM.GetPage(listOfAttachedFi[listBox2.SelectedIndex][1].ToString());
                
            }
            
        }
		

        private void button1_Click(object sender, EventArgs e)
        {
			var tempWin = new attachDocs((int)listOfEvents[listBox1.SelectedIndex - 1][0]);
			if(tempWin.ShowDialog() == DialogResult.OK)
			{
				listBox2_SelectedIndexChanged(sender, e);
			}
        }
		

		
		

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void estimate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

		private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}
	}
}
