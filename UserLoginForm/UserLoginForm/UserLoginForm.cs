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

namespace UserLoginForm
{
	public partial class UserLoginForm : Form
	{
		DBManager db = new DBManager();


        public delegate void Login(int expertId, int userId);
        public event Login LoginHandler;



		public UserLoginForm()
		{
			InitializeComponent();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			db.Connect();

			string login = DBUtil.AddQuotes(loginTB.Text);
			string pass = DBUtil.AddQuotes(passTB.Text);

			var user = db.GetRows("user", "*", "user_name=" + login +
				" AND password=" + pass);

			if (user.Count > 0){
                //MessageBox.Show("User found. Expert id is" + user[0][2].ToString());
                LoginHandler(Int32.Parse(user[0][2].ToString()), Int32.Parse(user[0][3].ToString()));
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("No user found");
            }
				

			db.Disconnect();
		}
	}
}
