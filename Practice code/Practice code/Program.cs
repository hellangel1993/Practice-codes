using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Practice_code
{
    public delegate void SumOfNumbersCallBack(int SumOfNumber);
    class Program
    {
        public static void PrintSum(int sum)
        {
            Console.WriteLine("Sum of number: "+sum);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("target number");
            int target = Convert.ToInt32(Console.ReadLine());

            SumOfNumbersCallBack callBack = new SumOfNumbersCallBack(PrintSum);

            Number number = new Number(target, callBack);
            Thread T1 = new Thread(new ThreadStart(number.PrintSumOfNumbers));
            T1.Start();
        }
    }
    class Number
    {
        int _target;
        SumOfNumbersCallBack _callBackMethod;
        public Number(int target,SumOfNumbersCallBack callBackMethod)
        {
            this._target = target;
            _callBackMethod = callBackMethod;
        }
        public void PrintSumOfNumbers()
        {
            int sum = _target;
            for (int i =1; i < _target; i++)
            {
                sum =sum+i;
            }

            _callBackMethod?.Invoke(sum);
        }
    }
}
