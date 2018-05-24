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
using System.IO;

namespace experts_jurist
{
    public partial class greeting : Form
    {
        DBManager db = new DBManager();
        public greeting(int id)
        {
            InitializeComponent();
            db.Connect();
            string userName = db.GetValue("user", "user_name", "id_of_user=" + id).ToString();
            string curDir = Directory.GetCurrentDirectory();
            var urit = new Uri("about/jurist_about.htm?name=" + userName, UriKind.Relative);
            webBrowser1.Navigate(curDir+ "/about/jurist_about.htm?name=" + userName);
        }

        private void greeting_Load(object sender, EventArgs e)
        {

        }
    }
}
