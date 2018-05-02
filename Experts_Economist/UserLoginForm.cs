using Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Experts_Economist
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        public int userId = 0;
        private DBManager db = new DBManager();

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = "'" + loginTB.Text + "'";
            string pass = "'" + passTB.Text + "'";

            List<List<Object>> user = new List<List<Object>>();
            try
            {
                user = db.GetRows("user", "*", "user_name=" + login +
                    " AND password=" + pass);
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка, перевірте правильність вводу");
                return;
            }
            if (user.Count > 0)
            {
                //  MessageBox.Show("Вхід. Id експерту " + user[0][2].ToString());
                Hide();
                Golovna gol = new Golovna(Int32.Parse(user[0][2].ToString()));
                gol.ShowDialog();
                gol = null;
                Show();
            }
            else
            {
                MessageBox.Show("Помилка, перевірте правильність вводу");
                DialogResult = DialogResult.None;
            }
        }

        private void UserLogin_Leave(object sender, EventArgs e)
        {
            loginTB.Text = "";
            passTB.Text = "";
        }

        private void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
            }
        }

        private void passTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
            }
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}