using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveDartData
{
  class Program
  {
    private static SqlConnection sqlConn = new SqlConnection();
    private static SqlDataReader sqlReader;
    private static string _sourceDatabaseName = "";
    private static string _useDBString = string.Format("USE {0}  ", _sourceDatabaseName);
    private static string _sourceDBConnStr = ConfigurationManager.ConnectionStrings["sourceDatabase"].ConnectionString;
    private static string _destinationDBConnStr = ConfigurationManager.ConnectionStrings["destinationDatabase"].ConnectionString;
    private static string _createDartDBSqlScriptLocation = ConfigurationManager.AppSettings["CreateDBScript"].ToString();

    static void Main(string[] args)
    {
      //Collect DB details
      var dbParam = InitializeDbParam();

      DestinationDatabase destination = new DestinationDatabase(dbParam);
      //destination.CreateDatabase(dbParam);
      //destination.CreateSchemaForDatabase(dbParam);
      //destination.GetTableList();
      //destination.GetStartTimeYearList();
      var insertQueries = destination.ReadTableData("[dbo].[MetaData]", dbParam);
      //SqlDataReader wellPropsReader = destination.ReadTableData("[dbo].[WellProps]");
      destination.InsertDataIntoTable("[dbo].[MetaData]", insertQueries, dbParam);
      Console.ReadKey();
    }

    private static DatabaseParam InitializeDbParam()
    {
      DatabaseParam dbParam = new DatabaseParam();
      
      string serverName = ConfigurationManager.AppSettings["DestinationDBServer"].ToString();
      dbParam.ServerName = serverName;
      
      string sourceDatabaseName = ConfigurationManager.AppSettings["SourceDataBaseName"].ToString();
      dbParam.SourceDatabaseName = sourceDatabaseName;

      dbParam.DatabaseName = "Dart_2013";
      dbParam.LoginName = "sa";
      dbParam.LoginPassword = "qaz123!@#";

      dbParam.LogFileName = "Dart_2013.ldf";
      dbParam.LogPathName = string.Format(@"{0}\{1}", @"C:\DARTBackup", dbParam.LogFileName);
      dbParam.LogFileSize = "10MB";
      dbParam.LogFileGrowth = "10MB";

      dbParam.DataFileName = "Dart_2013.mdf";
      dbParam.DataPathName = string.Format(@"{0}\{1}", @"C:\DARTBackup", dbParam.DataFileName);
      dbParam.DataFileSize = "2048MB";
      dbParam.DataFileGrowth = "10MB";
      return dbParam;
    }
  }
}
