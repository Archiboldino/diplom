using Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UserLoginForm
{
    public partial class User_editor : Form
    {
        private DBManager db = new DBManager();
        private string userName;

        public User_editor()
        {
            InitializeComponent();
            RefreshDVG();
        }

        private void RefreshDVG()
        {
            UsersDGV.Rows.Clear();
            UsersDGV.Columns.Clear();

            db.Connect();
            DataGridViewTextBoxColumn userName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn password = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn expertType = new DataGridViewTextBoxColumn();

            userName.Name = "Логін";
            password.Name = "Пароль";
            expertType.Name = "Тип експерта";

            UsersDGV.Columns.AddRange(new DataGridViewColumn[] { userName, password, expertType });

            var users = new List<List<Object>>();
            users = db.GetRows("user", "user_name,password,id_of_expert", "");

            int usersLength = users.Count;
            //int propCount = users[0].Count;

            for (int i = 0; i < usersLength; i++)
            {
                this.UsersDGV.Rows.Add(users[i][0].ToString(), users[i][1].ToString(), users[i][2].ToString());
            }

            db.Disconnect();
        }

        private void EditCurrentUser(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRow = this.UsersDGV.CurrentCell.RowIndex;
            string userName = this.UsersDGV.Rows[currentRow].Cells[0].Value.ToString();
            string userPassword = this.UsersDGV.Rows[currentRow].Cells[1].Value.ToString();
            string userType = this.UsersDGV.Rows[currentRow].Cells[2].Value.ToString();

            this.userName = DBUtil.AddQuotes(userName);

            this.UsernameTextBox.Text = userName;
            this.PasswordTextBox.Text = userPassword;
            this.ExperTypeTextBox.Text = userType;
        }

        private void UpdateCurrentUser(object sender, EventArgs e)
        {
            string userName = DBUtil.AddQuotes(this.UsernameTextBox.Text.Replace('\'', '`'));
            string userPassword = DBUtil.AddQuotes(this.PasswordTextBox.Text.Replace('\'', '`'));
            string userType = DBUtil.AddQuotes(this.ExperTypeTextBox.Text.Replace('\'', '`'));

            string[] updateCols = new string[] { "user_name", "user_name", "password", "id_of_expert" };
            string[] updateVals = new string[] { this.userName, userName, userPassword, userType };

            db.Connect();
            db.UpdateRecord("user", updateCols, updateVals);
            db.Disconnect();

            RefreshDVG();
        }

        private void AddNewUser(object sender, EventArgs e)
        {
            string userName = DBUtil.AddQuotes(this.UsernameTextBox.Text.Replace('\'', '`'));
            string userPassword = DBUtil.AddQuotes(this.PasswordTextBox.Text.Replace('\'', '`'));
            string userType = DBUtil.AddQuotes(this.ExperTypeTextBox.Text.Replace('\'', '`'));

            string[] fields = new string[] { "user_name", "password", "id_of_expert" };
            string[] values = new string[] { userName, userPassword, userType };

            db.Connect();

            db.InsertToBD("user", fields, values);

            db.Disconnect();

            RefreshDVG();
        }

        private void deleteCurrentUser(object sender, EventArgs e)
        {
            string userName = DBUtil.AddQuotes(this.UsernameTextBox.Text.Replace('\'', '`'));
            string userPassword = DBUtil.AddQuotes(this.PasswordTextBox.Text.Replace('\'', '`'));
            string userType = DBUtil.AddQuotes(this.ExperTypeTextBox.Text.Replace('\'', '`'));

            db.Connect();

            db.DeleteFromDB("user", "user_name", userName);

            db.Disconnect();

            RefreshDVG();
        }
    }
}