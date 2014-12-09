using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetDigitsOfNumber
{
  class Program
  {
    static void Main(string[] args)
    {
      int number = 1234; //Storing the number
      int reminder = 0;//Storing reminders

      int noOfDigits = 0;//Number of digits will be stored 

      while (number > 0)
      {
        reminder = number % 10;
        if (reminder > 0)
          noOfDigits++;
        else break;
        number = number / 10;
      }

      Console.WriteLine(noOfDigits);
      Console.ReadKey();
    }
  }
}
