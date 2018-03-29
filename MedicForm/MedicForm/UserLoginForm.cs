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
using MedicForm;

namespace UserLoginForm
{
	public partial class UserLogin : Form
	{
		DBManager db = new DBManager();

		public UserLogin()
		{
			InitializeComponent();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			//db.Connect();

			string login = DBUtil.AddQuotes(loginTB.Text);
			string pass = DBUtil.AddQuotes(passTB.Text);

			var user = db.GetRows("user", "*", "user_name=" + login +
				" AND password=" + pass);

			if (user.Count > 0){
                MessageBox.Show("Користувача знайдено. Id експерта = " + user[0][2].ToString());
                // LoginHandler(Int32.Parse(user[0][2].ToString()));
                //  new Main().ShowDialog();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Користувача не знайдено");
                DialogResult = DialogResult.None;
            }

            db.Disconnect();
		}
	}
}
