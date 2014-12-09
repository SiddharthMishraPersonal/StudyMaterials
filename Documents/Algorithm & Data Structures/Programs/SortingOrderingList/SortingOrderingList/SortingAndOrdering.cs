using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingOrderingList
{
  static class SortingAndOrdering
  {
    static List<int> list = new List<int>();
    static Random rand = new Random(35);

    public static void Initialize()
    {
      for (int i = 0; i < 10; i++)
      {
        list.Add(rand.Next(30, 200));
      }
    }

    public static void Sort()
    {
      if (list.Count <= 0)
        Initialize();

      foreach (int item in list)
      {
        Console.WriteLine(item);
      }

      int temp;

      for (int i = 0; i < list.Count; i++)
      {
        for (int j = 0; j < list.Count - 1; j++)
        {
          if (list[j] <= list[j + 1])
          {
            temp = list[j];
            list[j] = list[j + 1];
            list[j + 1] = temp;
          }
        }
      }

      Console.WriteLine("Sorted list\n");

      foreach (int item in list)
      {
        Console.WriteLine(item);
      }

    }
  }
}
