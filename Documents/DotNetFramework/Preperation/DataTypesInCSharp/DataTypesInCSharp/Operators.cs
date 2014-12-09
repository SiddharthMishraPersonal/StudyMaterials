using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesInCSharp
{
  class Operators
  {
   public static uint foo(uint a, uint b)
   {
     uint c = (a > 0 ? foo((a & b) << 1, a ^ b) : b);
     Console.WriteLine(c);
      return c;
    }
  }
}
