using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
  class Queue<T> : AbstractQueue<T> where T : IComparable<T>
  {

    public Queue()
    {

    }

    public override void Insert(T item)
    {
      throw new NotImplementedException();
    }

    public override T Remove()
    {
      throw new NotImplementedException();
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
