using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueue
{
  class Program
  {
    static void Main(string[] args)
    {
      //Int Queue
      PriorityQueue<Int32> priorityQueue = new PriorityQueue<Int32>(5);
      priorityQueue.Insert(5);
      priorityQueue.Insert(6);
      priorityQueue.Insert(1);
      priorityQueue.Insert(3);
      priorityQueue.Insert(2);
      priorityQueue.Insert(7);

      priorityQueue.Display();

      PriorityQueue<double> priorityQueueDouble = new PriorityQueue<double>(5);
      priorityQueueDouble.Insert(3.5);
      priorityQueueDouble.Insert(0.6);
      priorityQueueDouble.Insert(1.59);
      priorityQueueDouble.Insert(1.44);
      priorityQueueDouble.Insert(2.2);
      priorityQueueDouble.Insert(4.7);

      priorityQueueDouble.Display();

      Console.ReadKey();
    }
  }
}
