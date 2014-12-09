using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesInCSharp
{
  public class BaseC
  {
    public int x;

    public void Invoke()
    {
      Console.WriteLine("BaseC");
    }
  }
  public class DerivedC : BaseC
  {
   new public void Invoke()
    {
      Console.WriteLine("DerivedC");
    }
  }















  class BaseClass
  {
    public virtual void Method1()
    {
      Console.WriteLine("Base - Method1");
    }

    public virtual void Method2()
    {
      Console.WriteLine("Base - Method2");
    }
  }

  class DerivedClass : BaseClass
  {
    public override void Method1()
    {
      Console.WriteLine("Derived - Method1");
    }

    public new void Method2()
    {
      Console.WriteLine("Derived - Method2");
    }
  }
}
