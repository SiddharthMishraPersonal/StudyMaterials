using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueue
{
  public interface IQueue<T> 
  {
    T[] ItemList { get; }
    /// <summary>
    /// Calculates itemcount on the basis of Front and Rear positions.
    /// </summary>
    int ItemCount { get; }
    int Rear { get; set; }
    int Front { get; set; }
    void Display();
    bool IsEmpty();
    bool IsFull();
    void Insert(T item);
    T Remove();
    T Remove(T item);
    T PeekMin();
    T PeekMax();
  }
}
