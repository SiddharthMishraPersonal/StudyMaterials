using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveDartData
{
  public class Queries
  {
    public const string SysTables = "SELECT * FROM sys.Tables";
    public const string StartTimeQuery = "SELECT [run_fk] ,[runp_name] ,Convert(Datetime, [runp_value]) as runp_date ,[runp_ts]"
      + " FROM [dbo].[RunProps]"
      + " where runp_name = 'Start Time'";

    public const string SelectMetaDataTableQuery = "SELECT [meta_pk] ,[meta_tablename] ,[meta_eventtype]"
      +",[meta_attrname],[meta_refcount],[meta_description]"
      +",[meta_type],[meta_customtype],[meta_system]"+
      ",[meta_hidden],[meta_alwayspass],[meta_default]"
      +",[meta_path] FROM [dbo].[MetaData]";

    public const string GenericSelectTableQuery = "SELECT * FROM @Table";

  }
}
