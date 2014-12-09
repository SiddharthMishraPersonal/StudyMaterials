using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupingRadioButtons.Helper
{
  class ResourceOperations
  {
    public static void WriteToResourceFile(string key, string value)
    {
      Properties.Settings.Default.ArchivedPath = "";
    }
  }
}
