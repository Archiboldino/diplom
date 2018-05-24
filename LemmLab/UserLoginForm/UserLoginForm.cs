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
using experts_jurist;
using Experts_Economist;
namespace UserLoginForm
{
	public partial class UserLogin : Form
	{
		DBManager db = new DBManager();

		public UserLogin()
		{
			InitializeComponent();
		}

		public int userId;
		private void loginBtn_Click(object sender, EventArgs e)
		{

			string login = DBUtil.ValidateForSQL(loginTB.Text);
			string pass = DBUtil.ValidateForSQL(passTB.Text);

			db.Connect();
			var user = db.GetValue("user", "id_of_user", "user_name=" + login +
				" AND password=" + pass);
			var userExpertId = db.GetValue("user", "id_of_expert", "user_name=" + login +
				" AND password=" + pass);
			db.Disconnect();

			if (user != null)
			{
				switch ((int)userExpertId)
				{
					case (4):
						Hide();
						new mainWin((int)user).ShowDialog();
						loginTB.Text = "";
						passTB.Text = "";
						Show();
						break;
					default:
						Hide();
						new Golovna((int)userExpertId).ShowDialog();
						loginTB.Text = "";
						passTB.Text = "";
						Show();
						break;
				}
			}
			else
			{
				MessageBox.Show("No user found");
			}


		}

		private void UserLogin_Load(object sender, EventArgs e)
		{

		}

		private void UserLogin_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				if (passTB.Text == "") passTB.Focus();
				else
				{
					if (loginTB.Text == "") loginTB.Focus();
					else
						loginBtn_Click(sender, e);
				}
			}
		}

		private void loginTB_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				passTB.Focus();
			}
		}
	}
}
