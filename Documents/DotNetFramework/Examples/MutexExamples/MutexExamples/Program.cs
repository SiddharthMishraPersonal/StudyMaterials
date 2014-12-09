using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexExamples
{
  class Program
  {
    private static Mutex mutex;
    static void Main(string[] args)
    {
      mutex = new Mutex();

      Thread newThread = new Thread(new ThreadStart(StartProcessMethod));
      newThread.Start();

      Thread secondThread = new Thread(new ThreadStart(StartProcessMethod));
      secondThread.Start();

      Console.ReadKey();
    }

    private static void StartProcessMethod()
    {
      Console.WriteLine("starting");
      mutex.WaitOne();
      Console.WriteLine("{0} has entered the protected area",
           Thread.CurrentThread.Name);

      // Place code to access non-reentrant resources here. 

      // Simulate some work.
      Thread.Sleep(2000);

      Console.WriteLine("{0} is leaving the protected area\r\n",
          Thread.CurrentThread.Name);

      // Release the Mutex.
      mutex.ReleaseMutex();
    }
  }
}
