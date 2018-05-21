using oprForm;
using System;
using System.Windows.Forms;
using Experts_Economist;

namespace monitor
{
    static class Program
    {
        static UserLoginForm.UserLoginForm logIn;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            logIn = new UserLoginForm.UserLoginForm();
            logIn.LoginHandler += ChooseWindow;
            Application.Run(logIn);
        }

        private static void ChooseWindow(int expertId, int userId)
        {
            Form form;
            switch (expertId)
            {
                case 1:
                    form = new Golovna(expertId);
                    form.FormClosed += (s, e) => logIn.Visible = true;
                    form.Show();
                    break;
                case 2:
                    MessageBox.Show("Ecol");
                    logIn.Visible = true;
                    break;
                case 3:
                    MessageBox.Show("Med");
                    //form = new Main();
                    //form.FormClosed += (s, e) => logIn.Visible = true;
                    //form.Show();
                    break;
                case 4:
                    MessageBox.Show("Law");
                    logIn.Visible = true;
                    break;
                case 5:
                    form = new MainForm(expertId, userId);
                    form.FormClosed += (s, e) => logIn.Visible = true;
                    form.Show();
                    break;
            }
        }
    }
}
