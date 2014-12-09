using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
  class Program
  {
    static void Main(string[] args)
    {
      HashTable hashTable = new HashTable();
      hashTable.Insert("siddharth", "tea");
      hashTable.Insert("Prinks", "Coffee");
      hashTable.Insert("Ashwin", "Beer");
      hashTable.Insert("Niketan", "Coffee");

      hashTable.DisplayHash();
      string input = "r";
      while (!input.ToLower().Equals("q"))
      {
        input = Console.ReadLine();
        hashTable.GetNode(input);
      }
       
    }
  }
}
