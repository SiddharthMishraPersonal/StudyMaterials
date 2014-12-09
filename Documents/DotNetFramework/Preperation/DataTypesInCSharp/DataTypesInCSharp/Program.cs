using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesInCSharp
{
  class Program
  {
    static void Main(string[] args)
    {
      uint a, b;

      a = 11;
      b = 2;
      Console.WriteLine("0x{0:x}",a);
     

      Console.WriteLine(Operators.foo(a, b));

      Console.WriteLine(a & b);
      Console.WriteLine(a ^ b);

      BaseC bc = new BaseC();
      bc.Invoke();

      DerivedC d = new DerivedC();
      d.Invoke();

      BaseClass bcc = new BaseClass();
      DerivedClass dc = new DerivedClass();
      BaseClass bcdc = new DerivedClass();

      // The following two calls do what you would expect. They call
      // the methods that are defined in BaseClass.
      bcc.Method1();
      bcc.Method2();
      // Output:
      // Base - Method1
      // Base - Method2


      // The following two calls do what you would expect. They call
      // the methods that are defined in DerivedClass.
      dc.Method1();
      dc.Method2();
      // Output:
      // Derived - Method1
      // Derived - Method2


      // The following two calls produce different results, depending 
      // on whether override (Method1) or new (Method2) is used.
      bcdc.Method1();
      bcdc.Method2();
      // Output:
      // Derived - Method1
      // Base - Method2

      Console.ReadKey();
    }
  }
}
