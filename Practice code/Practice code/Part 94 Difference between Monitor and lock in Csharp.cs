using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Practice_code
{
    class Part_94_Difference_between_Monitor_and_lock_in_Csharp
    {
        static int Total = 0;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread T1 = new Thread(Part_94_Difference_between_Monitor_and_lock_in_Csharp.AddOneMillion);
            Thread T2 = new Thread(Part_94_Difference_between_Monitor_and_lock_in_Csharp.AddOneMillion);
            Thread T3 = new Thread(Part_94_Difference_between_Monitor_and_lock_in_Csharp.AddOneMillion);

            T1.Start();
            T2.Start();
            T3.Start();

            T1.Join();
            T2.Join();
            T3.Join();

            Console.WriteLine("Total= " + Total);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
        }

        static object _lock = new object();
        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                bool loackTaken = false;
                //uncomment to see the which function is fast.
                //Interlocked.Increment(ref Total);//this is the inbuild function to increment the variable without crossthreading problem
                Monitor.Enter(_lock,ref loackTaken);
                try
                {
                    Total++;
                }
                finally
                {
                    if (loackTaken)
                    {
                        Monitor.Exit(_lock);
                    }
                }
            }
        }
    }
}
