using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueExample
{
  class Program
  {
    static void Main(string[] args)
    {
      PriorityQueueImplemented priorityQueue = new PriorityQueueImplemented();

      Program.BubbleSort();


      priorityQueue.Enqueue("siddharth");
      priorityQueue.Enqueue("Mishra");
      priorityQueue.Enqueue("Prinks");
      priorityQueue.Enqueue("Niketan");
      priorityQueue.Enqueue("Prinks");
      priorityQueue.Enqueue("Richa");
      priorityQueue.Enqueue("siddharth");
      priorityQueue.Enqueue("Pankaj");
      priorityQueue.Enqueue("Deepak");

      priorityQueue.Display();
      Console.ReadKey();
    }

    private static void BubbleSort()
    {
      int[] array = new int[5];

      array[0] = 4;
      array[1] = 6;
      array[2] = 1;
      array[3] = 3;
      array[4] = 2;

      for (int i = 0; i < array.Length; i++)
      {
        for (int j = i; j < array.Length; j++)
        {
          int temp;
          if (array[i] < array[j])
          {
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
          }
        }
      }

      foreach (var i in array)
      {
        Console.WriteLine(i);
      }
    }
  }
}
