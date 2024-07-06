using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Fibonacci(long n)
        {
            List<long> fib = new List<long>{0,1,1};
            int i=3, sum=2;
            for (i = 3; i <= n; i++)
            {
                long x = fib[i-1] + fib[i-2];
                fib.Add(x);
                sum += (int)x;
            }
            return sum;
        }
        public long Solve(long n)
        {
            return (Fibonacci(n) % 10);
        }
    }
}
