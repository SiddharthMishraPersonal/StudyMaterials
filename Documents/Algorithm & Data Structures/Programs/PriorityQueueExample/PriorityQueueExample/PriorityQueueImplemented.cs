using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueExample
{

  class Node
  {
    public string Stock;
    public int Priority = 1;
  }

  internal class PriorityQueueImplemented
  {
    private Node[] priorityQueue = new Node[5];
    private int front = -1;
    private int rear = -1;

    public void Enqueue(string stock)
    {
      Node newNode = new Node() { Priority = 1, Stock = stock };

      //Check whether queue is empty
      if (front < 0 && rear < 0)
      {
        front++;
        rear++;
        priorityQueue[front] = newNode;
        return;
      }

      //First look for the item in Queue. If exists, increase it's priority and then sort queue on priority.
      Node lookupNode = PeekStock(stock);
      if (lookupNode != null)
      {
        lookupNode.Priority++;
        BubbleSort();
        return;
      }

      //Check whether queue is Full
      if (rear == priorityQueue.Length - 1)
      {
        //Replace lowest priority. Here rear will be pointing lowest priority.
        priorityQueue[rear] = null;
        priorityQueue[rear] = newNode;
        BubbleSort();
        return;
      }

      //If in between.
      rear++;
      priorityQueue[rear] = newNode;
      BubbleSort();
    }

    private void BubbleSort()
    {
      for (int i = 0; i < priorityQueue.Length; i++)
      {
        if (priorityQueue[i] == null)
          break;
        for (int j = i; j < priorityQueue.Length; j++)
        {
          Node temp;
          if (priorityQueue[j] == null)
            break;

          if (priorityQueue[i].Priority < priorityQueue[j].Priority)
          {
            temp = priorityQueue[i];
            priorityQueue[i] = priorityQueue[j];
            priorityQueue[j] = temp;
          }
        }
      }
    }

    public void Dequeue()
    {

    }

    public Node PeekMin()
    {
      Node element = null;

      return element;
    }

    public Node PeekMax()
    {
      Node element = null;

      return element;
    }

    public void DeleteMin()
    {

    }

    public Node PeekStock(string stock)
    {
      Node stoclNode = null;

      foreach (var node in priorityQueue)
      {
        if (node != null && node.Stock.Equals(stock))
        {
          stoclNode = node;
          break;
        }
      }

      return stoclNode;
    }

    public void Display()
    {
      foreach (var node in priorityQueue)
      {
        if (node != null)
          Console.WriteLine(string.Format("Stock: {0}-{1}\n\n", node.Stock, node.Priority));
      }
    }
  }
}
