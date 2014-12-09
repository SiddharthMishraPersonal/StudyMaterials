using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArchiveDartData
{
  public struct DatabaseParam
  {
    public string ServerName;
    public string DatabaseName;
    public string SourceDatabaseName;
    public object LoginName;
    public object LoginPassword;
    //Data file parameters
    public string DataFileName;
    public string DataPathName;
    public string DataFileSize;
    public string DataFileGrowth;
    //Log file parameters
    public string LogFileName;
    public string LogPathName;
    public string LogFileSize;
    public string LogFileGrowth;
  }

  public class DestinationDatabase
  {

    private string _destinationSqlConnectionString = "";
    private string _sourceSqlConnectionString = "";

    public DestinationDatabase(DatabaseParam dbParam)
    {
      _destinationSqlConnectionString = string.Format("SERVER = {0}; DATABASE = {1}; User ID = {2}; Pwd = {3};",
        dbParam.ServerName, dbParam.DatabaseName,
        dbParam.LoginName, dbParam.LoginPassword);
      _sourceSqlConnectionString = string.Format("SERVER = {0}; DATABASE = {1}; User ID = {2}; Pwd = {3};",
        dbParam.ServerName, dbParam.SourceDatabaseName,
        dbParam.LoginName, dbParam.LoginPassword);
    }

    public void CreateDatabase(DatabaseParam dbParam)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          //tmpConn.ConnectionString = "SERVER = " + dbParam.ServerName +
          //                   "; DATABASE = master; User ID = sa; Pwd = qaz123!@#";

          sqlConnection.ConnectionString = string.Format("SERVER = {0}; DATABASE = {1}; User ID = {2}; Pwd = {3};",
           dbParam.ServerName, "master",
           dbParam.LoginName, dbParam.LoginPassword);

          string sqlCreateDBQuery = " CREATE DATABASE "
                               + dbParam.DatabaseName
                               + " ON PRIMARY "
                               + " (NAME = N'" + dbParam.DataFileName + "', "
                               + " FILENAME = '" + dbParam.DataPathName + "', "
                               + " SIZE = 2MB,"
                               + " FILEGROWTH =" + dbParam.DataFileGrowth + ") "
                               + " LOG ON (NAME = N'" + dbParam.LogFileName + "', "
                               + " FILENAME = '" + dbParam.LogPathName + "', "
                               + " SIZE = 1MB, "
                               + " FILEGROWTH =" + dbParam.LogFileGrowth + ") ";
          using (SqlCommand sqlCommand = new SqlCommand(sqlCreateDBQuery, sqlConnection))
          {
            sqlConnection.Open();
            Console.WriteLine(sqlCreateDBQuery);
            sqlCommand.ExecuteNonQuery();

            Console.WriteLine("Database has been created successfully!");
          }
        }
      }
      catch (Exception ex)
      {

        Console.WriteLine(ex.ToString());
      }

    }

    public void CreateSchemaForDatabase(DatabaseParam dbParam)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          //tmpConn.ConnectionString = "SERVER = " + dbParam.ServerName +
          //                   "; DATABASE = master; User ID = sa; Pwd = qaz123!@#";
          sqlConnection.ConnectionString = string.Format("SERVER = {0}; DATABASE = {1}; User ID = {2}; Pwd = {3};",
            dbParam.ServerName, dbParam.DatabaseName,
            dbParam.LoginName, dbParam.LoginPassword);

          var createDbScriptFilePath = ConfigurationManager.AppSettings["CreateDBScript"];
          string sqlCreateDbQuery = Utilities.ReadSqlScript(createDbScriptFilePath); ;
          sqlCreateDbQuery = sqlCreateDbQuery.Replace("[@DartDBName]", string.Format("[{0}]", dbParam.DatabaseName));

          IEnumerable<string> commandStrings = Regex.Split(sqlCreateDbQuery.Trim(), @"^\s*GO\s*$",
                           RegexOptions.Multiline | RegexOptions.IgnoreCase);

          sqlConnection.Open();
          foreach (var commandString in commandStrings)
          {
            using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
            {
              Console.WriteLine(sqlCreateDbQuery);
              sqlCommand.ExecuteNonQuery();
              Console.WriteLine("Database has been created successfully!");
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

    }

    public IList<string> GetTableList()
    {
      List<string> tableList = new List<string>();

      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          sqlConnection.ConnectionString = _sourceSqlConnectionString;
          string sqlCreateDBQuery = Queries.SysTables;

          using (SqlCommand sqlCommand = new SqlCommand(sqlCreateDBQuery, sqlConnection))
          {
            sqlConnection.Open();
            Console.WriteLine(sqlCreateDBQuery);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
              if (reader["name"] != DBNull.Value)
              {
                string tableName = reader["name"].ToString();
                tableList.Add(tableName);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return tableList;
    }


    public List<string> GetStartTimeYearList()
    {
      var yearList = new List<string>();
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          sqlConnection.ConnectionString = _destinationSqlConnectionString;
          string sqlCreateDBQuery = Queries.StartTimeQuery;

          using (SqlCommand sqlCommand = new SqlCommand(sqlCreateDBQuery, sqlConnection))
          {
            sqlConnection.Open();
            Console.WriteLine(sqlCreateDBQuery);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
              if (reader["runp_date"] != DBNull.Value)
              {
                DateTime dateTime = new DateTime();
                DateTime.TryParse(reader["runp_date"].ToString(), out dateTime);
                string year = dateTime.Year.ToString();
                if (!yearList.Contains(year))
                  yearList.Add(year);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return yearList;
    }

    /// <summary>
    /// Reads Data for each table.
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public List<string> ReadTableData(string tableName, DatabaseParam dbParam)
    {
      SqlDataReader reader = null;
      List<string> insertQueries = new List<string>();
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          sqlConnection.ConnectionString = _sourceSqlConnectionString;
          string sqlSelectQuery = Queries.GenericSelectTableQuery;

          sqlSelectQuery = sqlSelectQuery.Replace("@Table", tableName.ToUpperInvariant());

          SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, sqlConnection);

          sqlConnection.Open();
          Console.WriteLine(sqlSelectQuery);
          reader = sqlCommand.ExecuteReader();

          string identity_On = string.Format("SET IDENTITY_INSERT {0} ON", tableName);
          insertQueries.Add(identity_On);


          while (reader.Read())
          {
            string sqlQuery = string.Format("INSERT INTO {0} ", tableName);
            string columnNames = "";
            string values = "";
            for (int i = 0; i < reader.FieldCount; i++)
            {
              if (values != "")
              {
                values += ", ";
              }

              if (columnNames != "")
              {
                columnNames += ", ";
              }

              string columnName = reader.GetName(i);
              if (!string.IsNullOrEmpty(columnName))
                columnNames += string.Format("[{0}]", columnName);

              if (reader[i].Equals(DBNull.Value))
                values += string.Format("{0}", "NULL");
              else
                values += string.Format("'{0}'", reader[i].ToString());
            }
            sqlQuery = string.Format("{0} ({1})", sqlQuery, columnNames);
            sqlQuery = string.Format("{0} VALUES ({1})", sqlQuery, values);

            insertQueries.Add(sqlQuery);
          }

          string identity_Off = string.Format("SET IDENTITY_INSERT {0} OFF", tableName);
          insertQueries.Add(identity_Off);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return insertQueries;
    }

    public void InsertDataIntoTable(string tableName, List<string> insertQueries, DatabaseParam dbParam)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
          sqlConnection.ConnectionString = string.Format("SERVER = {0}; DATABASE = {1}; User ID = {2}; Pwd = {3};",
            dbParam.ServerName, dbParam.DatabaseName,
            dbParam.LoginName, dbParam.LoginPassword);
          sqlConnection.Open();
          foreach (var insertQuery in insertQueries)
          {
            using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
            {
              int result = sqlCommand.ExecuteNonQuery();
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

  }
}
