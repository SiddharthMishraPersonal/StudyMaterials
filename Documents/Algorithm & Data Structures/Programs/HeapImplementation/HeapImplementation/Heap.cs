using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{

  class Node
  {
    public int StockValue = 0;
    public int Priority = 0;
    public Node ParentNode = null;
    public Node LeftNode = null;
    public Node RightNode = null;
  }

  class Heap
  {
    Node[] heapNodes = new Node[15];
    private int currentHeapIndex = -1;
    public void Insert(int value)
    {
      Node newNode = new Node() { Priority = 0, StockValue = value };

      if (currentHeapIndex == heapNodes.Length)
        throw new Exception("heap is full");
      else
      {
        currentHeapIndex++;
        heapNodes[currentHeapIndex] = newNode;
        ShiftUp(currentHeapIndex);
      }
    }

    private void ShiftUp(int nodeIndex)
    {
      int parentIndex;
      Node tempNode;

      if (nodeIndex != 0)
      {
        parentIndex = GetParentIndex(nodeIndex);
        if (heapNodes[parentIndex].StockValue > heapNodes[nodeIndex].StockValue)
        {
          tempNode = heapNodes[parentIndex];
          heapNodes[parentIndex] = heapNodes[nodeIndex];
          heapNodes[nodeIndex] = tempNode;
          ShiftUp(parentIndex);
        }
      }
    }

    private int GetParentIndex(int nodeIndex)
    {
      int parentIndex = Int32.Parse((nodeIndex / 2).ToString());

      return parentIndex;
    }

    public void DisplayHeap()
    {
      int count = 0;
      foreach (var heapNode in heapNodes)
      {
        if (heapNode != null)
        {
          Console.WriteLine(heapNode.StockValue);
        }
      }
    }
  }
}
