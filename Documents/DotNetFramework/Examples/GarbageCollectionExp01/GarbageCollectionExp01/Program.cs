using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GarbageCollectionExp01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a time object that knows to call our TimerCallback
            //method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallBack, null, 0, 2000);

            FinalizeTest fn = new FinalizeTest("siddharth");

            //wait for the user to hit enter
            Console.ReadLine();
        }

        public static void TimerCallBack(object O)
        {
            //Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);

            //Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}
