using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class DBManager
{
    private MySqlConnection connection;
    private String connectionString = "Server=localhost;Database=experts;Uid=root;Pwd=13; charset=utf8;"; // TODO Default connection string

    //Nikita
    public DBManager()
    {
        try
        {
            connection = new MySqlConnection(connectionString);
            Connect();
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.ToString());
        }
    }

    public DBManager(String connectionString)
    {
        try
        {
            this.connectionString = connectionString;
            connection = new MySqlConnection(connectionString);
            Connect();
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.ToString());
        }
    }

    public bool Connect()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (Exception)
        {
             // MessageBox.Show(ex.ToString());
            return false;
        }
    }

    public bool Disconnect()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
              MessageBox.Show(ex.ToString());
            return false;
        }
    }

    // Returns single first value according to parameters
    public Object GetValue(String tableName, String fields, String cond)
    {
        try
        {
            MySqlCommand command = new MySqlCommand(getSelectStatement(tableName, fields, cond), connection);
            Console.WriteLine(command.CommandText);
            return command.ExecuteScalar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return 0; }
    }

    private String getSelectStatement(String tableName, String fields, String cond)
    {
        string res = "";
        try
        {
            res = "SELECT " + fields + " FROM " + tableName;
            if (cond != "")
            {
                res += " WHERE " + cond;
            }
            res += ";";

            return res;
        }
        catch (Exception ex) { res = ex.ToString(); }
        return res;
    }

    // Returns list of rows
    public List<List<Object>> GetRows(String tableName, String fields, String cond)
    {
        try
        {
            var res = new List<List<Object>>();

            MySqlCommand command = new MySqlCommand(getSelectStatement(tableName, fields, cond), connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var currentRow = new List<Object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        currentRow.Add(reader[i]);
                    }
                    res.Add(currentRow);
                }
            }
            return res;
        }
        catch (Exception ex) {
            MessageBox.Show(ex.ToString());
            return null; }
    }

    // Update table and return number of updated rows
    public int SetValue(String tableName, String field, String value, String cond)
    {
        try
        {
            MySqlCommand command = new MySqlCommand(getUpdateStatement(tableName, field, value, cond), connection);
            return command.ExecuteNonQuery();
        }
        catch (Exception ex) { MessageBox.Show(ex.ToString()); return 0; }
    }

    private string getUpdateStatement(string tableName, string field, string value, string cond)
    {
        String res = "";
        try
        {
            res = "UPDATE " + tableName + " SET " + field + " = " + value + " ;";
            return res;
        }
        catch (Exception ex) { res = ex.ToString(); }
        return res;
    }

    /// --IVAN

    public string DeleteFromDB(string table, string colName, string colValue)
    {
        string res = "Deleted";
        try
        {
            string sqlCommand = "DELETE FROM " + table + " WHERE " + colName + " = " + colValue + ";";
            MySqlCommand deleteCmd = new MySqlCommand(sqlCommand, connection);
            deleteCmd.ExecuteNonQuery();
        }
        catch (Exception ex) { res = ex.ToString(); }
        return res;
    }

    public string DeleteFromDB(string table, string[] colName, string[] colValue)
    {
        if (colName.Length == colValue.Length)
        {
            if (colName.Length > 1)
            {
                string sqlCommand = "";
                string res = "Deleted";
                try
                {
                    sqlCommand = "DELETE FROM " + table + " WHERE ";
                    for (int i = 0; i < colName.Length - 1; i++)
                    {
                        sqlCommand += colName[i] + " = " + colValue[i] + " AND ";
                    }
                    sqlCommand += "" + colName[colName.Length - 1] + " = " + colValue[colValue.Length - 1] + ";";
                    MySqlCommand deleteCmd = new MySqlCommand(sqlCommand, connection);
                    deleteCmd.ExecuteNonQuery();
                }
                catch (Exception ex) { res = ex.ToString() + "\n" + sqlCommand; }
                return res;
            }
            else
            {
                string colname = colName[0];
                string colvalue = colValue[0];
                return DeleteFromDB(table, colname, colvalue);
            }
        }
        else { return "Кількість полів та значень різна"; }
    }

    public int InsertToBD(string table, string list)
    {
        string sqlCommand = "INSERT INTO " + table + " VALUES(" + list + ");select last_insert_id();";
        MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
        insertCmd.ExecuteNonQuery();
        return (int)insertCmd.ExecuteScalar();
    }

    public int InsertToBD(string table, string[] fieldNames, string[] fieldValues)
    {
        if (fieldNames.Length == fieldValues.Length)
        {
            string sqlCommand = "INSERT INTO " + table + "(";
            for (int i = 0; i < fieldNames.Length - 1; i++)
            {
                sqlCommand += "" + fieldNames[i] + ",";
            }
            sqlCommand += "" + fieldNames[fieldValues.Length - 1] + "";
            sqlCommand += ") VALUES(";
            for (int i = 0; i < fieldValues.Length - 1; i++)
            {
                sqlCommand += "" + fieldValues[i] + ",";
            }
            sqlCommand += "" + fieldValues[fieldValues.Length - 1] + "";
            sqlCommand += ");";
            sqlCommand += "select last_insert_id();";
            MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
            // insertCmd.ExecuteNonQuery();
            return Int32.Parse(insertCmd.ExecuteScalar().ToString());
        }
        else { throw new ArgumentException("fieldNames.Length != fieldValues.Length"); }
    }

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