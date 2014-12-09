using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
  class Program
  {
    static void Main(string[] args)
    {

      f(9, 12);

      Heap heap = new Heap();
      heap.Insert(8);
      heap.Insert(3);
      heap.Insert(9);
      heap.Insert(5);
      heap.Insert(2);
      heap.Insert(7);
      heap.Insert(1);
      heap.Insert(4);
      heap.Insert(6);
      heap.Insert(0);


      heap.DisplayHeap();

      Console.ReadKey();
    }


    static uint f(uint a, uint b)
    {
      uint c = 0;
      Console.WriteLine(a > 0 ? f((a & b) << 1, a ^ b) : b);
      return c;
    }

    private static void merge()
    {
      int[] first =
      new int[5];
      int[] second = new int[7];
      int[] third = new int[3];
      int[] result = new int[];

    }

  }
}
