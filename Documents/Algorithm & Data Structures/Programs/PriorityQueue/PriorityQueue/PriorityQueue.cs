using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueue
{
  class PriorityQueue<T> : AbstractQueue<T> where T : IComparable<T>
  {

    public PriorityQueue(int queueLength)
      : base()
    {
      this.ItemList = new T[queueLength];
    }

    public override void Insert(T item)
    {
      //Boundary condition: If Queue is empty.
      if (this.IsEmpty())
      {
        ItemList[++Front] = item;
        Rear++;
        return;
      }

      //Boundary condition: If Queue is full
      if (this.IsFull())
        return;

      //If the new item is less then the Top item then shift Queue items to find 
      //new item's appropriate place
      if (this.Compare(item, ItemList[Front]) < 0)
      {
        int position;

        //iterate from Front to Rear and compare each item
        for (position = Front; position >= Rear; position--)
        {
          //if new item is less than Queued item then Shift Queued item one up.
          //And compare with another Queued item.
          if (Compare(item, ItemList[position]) < 0)
          {
            ItemList[position + 1] = ItemList[position];
            continue;
          }
          break;
        }
        ItemList[position + 1] = item;
        Front++;
      }
      if (this.Compare(item, ItemList[Front]) > 0)
      {
        ItemList[++Front] = item;
      }
    }

    public override T Remove()
    {
      T item = default(T);
      try
      {
        //Check if Queue is empty.
        if (IsEmpty())
          return item;

        if (IsFull())
        {
          item = ItemList[Rear++];
          return item;
        }

        if (ItemCount == 1)
        {
          item = ItemList[Rear++];
          Front = -1;
          Rear = -1;
          return item;
        }

        item = ItemList[Rear++];
        return item;

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return item;
    }

    public override T Remove(T item)
    {
      throw new NotImplementedException();
    }

    public override T PeekMin()
    {
      throw new NotImplementedException();
    }

    public override T PeekMax()
    {
      throw new NotImplementedException();
    }
  }
}
