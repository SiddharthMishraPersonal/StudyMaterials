using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapImplementation
{
  class HeapTree
  {
    private Node rootNode = null;
    private Node lastNode = null;

    public void Insert(int value)
    {
      Node newNode = new Node() { Priority = 0, StockValue = value };

      if (lastNode == null)
      {
        lastNode = newNode;
        rootNode = newNode;
      }

      //Insert Left if Left is empty.
      if (lastNode.LeftNode == null)
      {
        lastNode.LeftNode = newNode;
        newNode.ParentNode = lastNode;
      }

      //Insert Right if Left is full and right is empty. And then shift the LastNode pointer to newNode
      if (lastNode.LeftNode != null && lastNode.RightNode == null)
      {
        lastNode.RightNode = newNode;
        newNode.ParentNode = lastNode;
        lastNode = newNode;
      }

      ShiftUp(newNode);
    }

    private void ShiftUp(Node newNode)
    {
      Node parentNode;
      Node tempNode;
      parentNode = getParentNode(newNode);
      if (parentNode.StockValue > newNode.StockValue)
      {
        tempNode = parentNode;
        parentNode = newNode;
        newNode = tempNode;

        ShiftUp(parentNode);
      }
    }

    private Node getParentNode(Node currentNode)
    {
      Node parentNode = null;

      parentNode = currentNode.ParentNode;

      return parentNode;
    }


  }
}
