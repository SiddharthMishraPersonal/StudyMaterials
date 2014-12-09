using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
  abstract class AbstractQueue<T> where T : IComparable<T>
  {
    private int _rear = -1;
    public int Rear
    {
      get
      {
        return _rear;
      }
      set
      {
        _rear = value;
      }
    }

    private int _front = -1;
    public int Front
    {
      get
      {
        return _front;
      }
      set
      {
        _front = value;
      }
    }

    private int _itemCount = 0;
    public int ItemCount
    {
      get
      {
        _itemCount = 0;
        if (Rear >= 0 && Front >= 0)
          _itemCount = Front - Rear + 1;
        return _itemCount;
      }
    }


    public bool IsEmpty()
    {
      return (ItemCount == 0);
    }

    public bool IsFull()
    {
      return (ItemList.Count() == ItemCount);
    }


    public void Display()
    {
      for (int i = Front; i >= Rear; i--)
      {
        Console.WriteLine(string.Format("Queue[{0}] : {1}", i, ItemList[i]));
      }

      Console.WriteLine("\n**************\n");

    }

    public int Compare(T x, T y) { return x.CompareTo(y); }

    private T[] _itemList;
    public T[] ItemList
    {
      get
      {
        return _itemList;
      }
      set
      {
        _itemList = value;
      }
    }

    abstract public void Insert(T item);
    abstract public T Remove();
    abstract public T Remove(T item);
    abstract public T PeekMin();
    abstract public T PeekMax();

  }
}
