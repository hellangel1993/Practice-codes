using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Practice_code
{
    class Part_97_Performance_of_a_multithreaded_program
    {
        public static void EvenNumberSum()
        {
            double sum = 0;
            for (int i = 0; i < 500000000; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine("Sum of Even Number= {0}", sum);
        }

        public static void OddNumbersSum()
        {
            double sum = 0;
            for (int i = 0; i < 500000000; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine("Sum of the Odd = {0}",sum);
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            EvenNumberSum();
            OddNumbersSum();
            stopwatch.Stop();
            Console.WriteLine("Total time: "+stopwatch.ElapsedTicks);

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            Thread T1 = new Thread(EvenNumberSum);
            Thread T2 = new Thread(OddNumbersSum);
            T1.Start();
            T2.Start();
            T1.Join();
            T2.Join();
            stopwatch1.Stop();
            Console.WriteLine("Total time: " + stopwatch1.ElapsedTicks);
        }
    }
}
