using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLoginForm
{
	static class Program
	{
		

        static int userId;
        static UserLoginForm a;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{

            Application.SetCompatibleTextRenderingDefault(false);
            a = new UserLoginForm();
            a.LoginHandler += Callback;
			Application.EnableVisualStyles();
			Application.Run(a);
           
		}

        static void Callback(int id, int uid)
        {
            userId = id;
        }

	}
}
