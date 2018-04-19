using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Management;
using System.Reflection;

namespace Installer
{

    internal class Program
    {

        public static void Main()
        {

            string path = Assembly.GetExecutingAssembly().Location;
            path = path.Remove(path.Length - 13, 13);
            string connectionString = "";
            bool fine = false;
            string password = "";
            string username = "expertokot";
            Console.Write("Для створення нового користувача та iмпорту БД\nбудь ласка введiть пароль для користувача root(адмiнiстратор) :");
            while (!fine)
            {
                password = Console.ReadLine();
                connectionString = "Server=localhost;Uid=root;Pwd=" + password + ";";
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    Console.WriteLine("\nДоступ до БД отримано");
                    connection.Close();
                    fine = true;
                }
                catch (Exception)
                {
                    Console.Write("\nНеправильний пароль, доступ до СУБД не отриманий\nВведiть будь-ласка правильний пароль :");
                }
            }

            if (fine)
            {
                Console.WriteLine("\nОперацiя iмпорту бази даних, зачекайте...");
                string ex_con = "";
                while (ex_con != "n")
                {
                    try
                    {
                        string file = path + "experts.sql";
                        Console.WriteLine(file);
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                using (MySqlBackup mb = new MySqlBackup(cmd))
                                {
                                    cmd.Connection = conn;
                                    conn.Open();
                                    mb.ImportFromFile(file);
                                    conn.Close();
                                }
                            }
                        }
                        Console.WriteLine("\nБаза даних успiшно iмпортована.");
                        ex_con = "n";
                    }
                    catch (Exception)
                    {
                        Console.Write("\nБаза даних не iмпортована, спробувати ще раз? y/n   ");
                        ex_con = Console.ReadLine();
                    }
                }
                ex_con = "";
                Console.WriteLine("Операцiя створення користувача");

                while (ex_con != "n")
                {
                    try
                    {
                        using (MySqlConnection Connection = new MySqlConnection(connectionString))
                        using (MySqlCommand Command = new MySqlCommand("DROP USER '" + username + "'@'localhost'", Connection))
                        {
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    password = "1337";
                    try
                    {
                        using (MySqlConnection Connection = new MySqlConnection(connectionString))
                        using (MySqlCommand Command = new MySqlCommand("CREATE USER '" + username + "'@'localhost' IDENTIFIED BY '" + password + "';GRANT ALL PRIVILEGES ON experts.* TO '" + username + "'@'localhost';FLUSH PRIVILEGES;", Connection))
                        {
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                            Console.WriteLine("\nКористувача успiшно створено\nНажмiть будь-яку клавiшу щоб завершити установку");
                            Console.ReadLine();
                            ex_con = "n";
                        }
                    }
                    catch (Exception)
                    {
                        Console.Write("\nКористувача не створено, спробувати ще раз? y/n   ");
                        ex_con = Console.ReadLine();
                    }
                }
            }

            string writePath = path + "c.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(username + " " + password);
            }
        }
    }

}