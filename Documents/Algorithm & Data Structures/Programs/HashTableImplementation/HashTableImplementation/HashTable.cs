using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
  /// <summary>
  /// Hash table unit.
  /// </summary>
  class Node
  {
    public string person = string.Empty;
    public string drink = string.Empty;
    public Node NextNode = null;
  }

  public class HashTable
  {
    private Node[] hashTableArray = new Node[10];

    /// <summary>
    /// Inserts Key value pair to hashtable
    /// </summary>
    /// <param name="person">Key for hash table.</param>
    /// <param name="drink">Value for hash table.</param>
    public void Insert(string person, string drink)
    {
      int index = Hash(person);
      Node node = new Node();
      node.person = person;
      node.drink = drink;

      if (hashTableArray[index] == null)
      {
        hashTableArray[index] = node;
      }
      else
      {
        Node tempNode = hashTableArray[index];
        while (tempNode.NextNode != null)
        {
          tempNode = tempNode.NextNode;
        }

        tempNode.NextNode = node;
      }
    }

    /// <summary>
    /// Hash Funtion that calculates hash value.
    /// </summary>
    /// <param name="person">Key for hash function</param>
    /// <returns></returns>
    private int Hash(string person)
    {
      int index = -1;
      int hash = person.Sum(ch => (int)ch);
      index = hash % 10;
      return index;
    }

    /// <summary>
    /// Displays all elements in HashTable
    /// </summary>
    public void DisplayHash()
    {
      int count = 0;
      foreach (var node in hashTableArray)
      {
        if (node == null)
          Console.WriteLine(string.Format("Index: {0} NO ELEMENT.\n\n", count));
        else
          Console.WriteLine(string.Format("Index: {0}\nPerson: {1}\nDrink: {2}\n\n", count, node.person, node.drink));

        count++;
      }
    }

    /// <summary>
    /// Gets a specific node from the hashtable.
    /// </summary>
    /// <param name="person">Key for hashtable.</param>
    public void GetNode(string person)
    {
      int index = Hash(person);
      Node node = hashTableArray[index];

      if (node == null)
        Console.WriteLine(string.Format("No details found for '{0}' in HashTable.", person));
      else
        Console.WriteLine(string.Format("Person: {0}\nDrink: {1}\n\n", node.person, node.drink));

    }
  }
}
