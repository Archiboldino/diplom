using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Data
{
    public class DBManagerNikita
    {
        private MySqlConnection connection;
        private String connectionString = "Server=localhost;Database=experts;Uid=root;Pwd=13;"; // TODO Default connection string

        //Nikita
        public DBManagerNikita()
        {
            connection = new MySqlConnection(connectionString);
        }

        public DBManagerNikita(String connectionString)
        {
            this.connectionString = connectionString;
            connection = new MySqlConnection(connectionString);
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }

        // Returns single first value according to parameters
        public Object GetValue(String tableName, String fields, String cond)
        {
            //try catch
            try
            {
                MySqlCommand command = new MySqlCommand(getSelectStatement(tableName, fields, cond), connection);

                return command.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private String getSelectStatement(String tableName, String fields, String cond)
        {
            String res = "SELECT " + fields + " FROM " + tableName;
            if (cond != "")
            {
                res += " WHERE " + cond;
            }
            res += ";";

            return res;
        }

        // Returns list of rows
        public List<List<Object>> GetRows(String tableName, String fields, String cond)
        {
            //try catch
            var res = new List<List<Object>>();

            MySqlCommand command = new MySqlCommand(getSelectStatement(tableName, fields, cond), connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<Object> row = new List<object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader[i]);
                    }
                    res.Add(row);
                }
            }
            return res;
        }

        // Update table and return number of updated rows
        public int SetValue(String tableName, String field, String value, String cond)
        {
            //try catch
            MySqlCommand command = new MySqlCommand(getUpdateStatement(tableName, field, value, cond), connection);
            return command.ExecuteNonQuery();
        }

        private string getUpdateStatement(string tableName, string field, string value, string cond)
        {
            String res = "UPDATE " + tableName + " SET " + field + " = " + value + " ;";
            return res;
        }

        /// --IVAN

        public void DeleteFromDB(string table, string colName, string colValue)
        {
            string sqlCommand = "DELETE FROM " + table + " WHERE " + colName + " = " + colValue + " ";
            MySqlCommand deleteCmd = new MySqlCommand(sqlCommand, connection);
            deleteCmd.ExecuteNonQuery();
        }

        public int InsertToBD(string table, string list)
        {
            string sqlCommand = "INSERT INTO " + table + " VALUES(" + list + ")";
            sqlCommand += "select last_insert_id();";
            MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
            return Int32.Parse(insertCmd.ExecuteScalar().ToString());
        }

        public int InsertToBD(string table, string[] fieldNames, string[] fieldValues)
        {
            if (fieldNames.Length == fieldValues.Length)
            {
                string sqlCommand = "INSERT INTO " + table + "(";
                for (int i = 0; i < fieldNames.Length - 1; i++)
                {
                    sqlCommand += " " + fieldNames[i] + ",";
                }
                sqlCommand += fieldNames[fieldNames.Length - 1];
                sqlCommand += ") VALUES(";
                for (int i = 0; i < fieldValues.Length - 1; i++)
                {
                    sqlCommand += " " + fieldValues[i] + ",";
                }
                sqlCommand += fieldValues[fieldNames.Length - 1];
                sqlCommand += ");";
                sqlCommand += "select last_insert_id();";
                MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
                int id = Int32.Parse(insertCmd.ExecuteScalar().ToString());
                return id;
            }
            else
            {
                throw new ArgumentException("Field and Value list dont match.");
            }
        }

        public void InsertToBDWithoutId(string table, string[] fieldNames, string[] fieldValues)
        {
            if (fieldNames.Length == fieldValues.Length)
            {
                string sqlCommand = "INSERT INTO " + table + "(";
                for (int i = 0; i < fieldNames.Length - 1; i++)
                {
                    sqlCommand += " " + fieldNames[i] + ",";
                }
                sqlCommand += fieldNames[fieldNames.Length - 1];
                sqlCommand += ") VALUES(";
                for (int i = 0; i < fieldValues.Length - 1; i++)
                {
                    sqlCommand += " " + fieldValues[i] + ",";
                }
                sqlCommand += fieldValues[fieldNames.Length - 1];
                sqlCommand += ");";
                MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
                insertCmd.ExecuteNonQuery();
            }
            else
            {
                throw new ArgumentException("Field and Value list dont match.");
            }
        }

        //"INSERT INTO " + table + "(" + fieldNames[i] + "

        public int UpdateRecord(string tableName, string[] colNames, string[] colValues)
        {
            if (colNames.Length == colValues.Length)
            {
                string sqlCommand = "UPDATE " + tableName + " SET ";

                for (int i = 1; i < colValues.Length - 1; i++)
                {
                    sqlCommand += colNames[i] + "=" + colValues[i] + ", ";
                }
                sqlCommand += colNames[colValues.Length - 1] + "=" + colValues[colValues.Length - 1] + "";
                sqlCommand += " where " + colNames[0] + "=" + colValues[0] + "";
                MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
                return insertCmd.ExecuteNonQuery();
            }
            else
            {
                throw new ArgumentException("Field and Value list dont match.");
            }
        }
    }
}