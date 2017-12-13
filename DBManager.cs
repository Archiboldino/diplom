using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Sql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Data
{
	public interface Mapper<T>
	{
		T Map(IDataReader reader);
	}

	public class DBManager
	{
		private MySqlConnection connection;
		private String connectionString = "Server=localhost;Database=experts;Uid=test;Pwd=testarino123;"; // TODO Default connection string

		//Nikita
		public DBManager()
		{
			try
			{
				connection = new MySqlConnection(connectionString);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DBManager(String connectionString)
		{
			try
			{
				this.connectionString = connectionString;
				connection = new MySqlConnection(connectionString);
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool Connect()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch (Exception ex)
			{
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
				return false;
			}
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
			catch(MySqlException ex)
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
					//res.Add(mapper.Map(reader));
					for(int i = 0; i < reader.FieldCount; i++)
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

		public string DeleteFromDB(string table, string colName, string colValue)
		{
			string res = "Deleted";
			try
			{
				Connect();
				string sqlCommand = "DELETE FROM " + table + " WHERE " + colName + " = " + colValue + " ";
				MySqlCommand deleteCmd = new MySqlCommand(sqlCommand, connection);
				deleteCmd.ExecuteNonQuery();
				Disconnect();
			}
			catch (Exception ex) { res = ex.ToString(); }
			return res;
		}

		public string InsertToBD(string table, string list)
		{
			string res = "Inserted";
			try
			{
				Connect();
				string sqlCommand = "INSERT INTO " + table + " VALUES(" + list + ")";
				MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
				insertCmd.ExecuteNonQuery();
				Disconnect();
			}
			catch (Exception ex) { res = ex.ToString(); }
			return res;
		}

		public bool InsertToBD(string table, string[] fieldNames, string[] fieldValues)
		{
			if (fieldNames.Length == fieldValues.Length)
			{
				try
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
					sqlCommand += ")";
					MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
					insertCmd.ExecuteNonQuery();
					return true;
				}
				catch (MySqlException ex)
				{
					throw new Exception(ex.Message);
				}
			}
			else
			{
				return false;
			}
		}
		//"INSERT INTO " + table + "(" + fieldNames[i] + "

		public bool UpdateRecord(string tableName, string[] colNames, string[] colValues)
		{
			if (colNames.Length == colValues.Length)
			{
				try
				{
					Connect();
					string sqlCommand = "UPDATE " + tableName + " SET ";

					for (int i = 1; i < colValues.Length - 1; i++)
					{
						sqlCommand += colNames[i] + "=" + colValues[i] + ", ";
					}
					sqlCommand += colNames[colValues.Length - 1] + "=" + colValues[colValues.Length - 1] + "";
					sqlCommand += " where " + colNames[0] + "=" + colValues[0] + "";
					MySqlCommand insertCmd = new MySqlCommand(sqlCommand, connection);
					Disconnect();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

	}
}