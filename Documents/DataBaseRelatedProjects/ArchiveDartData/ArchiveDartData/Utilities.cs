using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveDartData
{
 public class Utilities
  {

   public static string ReadSqlScript(string filePath)
   {
     string fileContent = File.ReadAllText(filePath);

     return fileContent;
   }

  }
}
