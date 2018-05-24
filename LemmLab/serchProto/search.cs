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
namespace experts_jurist
{
    public partial class search : Form
    {

        SearchManager SM;
        string[] listOfFi = { };
        

        public search()
        {
            SM = new SearchManager();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listOfFi = SM.SearchLine(textBox1.Text);

			if (listOfFi.Count() < 0)
			{
				label1.Text = "Нічого не знайдено";
			}
			else
			{
				label1.Text = "Знайдені документи";
			}
			Reload();
        }

        private void Reload()
        {
            listBox1.Items.Clear();
            foreach (var g in listOfFi)
            {
                listBox1.Items.Add(SM.GetPrewiew(g));
            }
            if (listOfFi.Length > 0)
            {
                listBox1.SelectedIndex = 0;
                webBrowser1.DocumentText = SM.GetPage(listOfFi[0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = SM.GetPage(listOfFi[listBox1.SelectedIndex]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var tempList = SM.SearchLine(textBox1.Text);
			if(tempList.Count()>0)
			{
				listOfFi = tempList;
				Reload();
			}

        }

		private void search_Load(object sender, EventArgs e)
		{
			listOfFi = SM.SearchAll();
			if (listOfFi.Count() < 0)
			{
				label1.Text = "Не знайдено документів в базі";
			}
			else
			{
				label1.Text = "Знайдені документи";
			}
		}
	}
}
