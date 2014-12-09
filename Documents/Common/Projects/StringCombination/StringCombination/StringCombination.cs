using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCombination
{
  class StringCombination
  {
    public static void GetCombinations(string str)
    {
      List<string> strColl = new List<string>();
      char[] delimeter = " ".ToArray();

      strColl.AddRange(str.Split(delimeter, StringSplitOptions.RemoveEmptyEntries).ToList());

      Display(strColl);
    }

    public static void Display(List<string> strColl)
    {
      foreach (var item in strColl)
      {
        Console.WriteLine(item);
      }
    }
  }
}
