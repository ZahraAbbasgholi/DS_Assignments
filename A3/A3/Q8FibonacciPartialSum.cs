using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Fibonacci(long n, long m)
        {
            List<long> fib = new List<long> { 0, 1, 1 };
            int i = 3;
            long sum = 0;
            for (i = 3; i <= n; i++)
            {
                fib.Add(fib[i - 1] + fib[i - 2]);
                if (i >= m)
                    sum += fib[i];
            }
            return sum;
        }

        public long fib(long n)
        {
            int f0 = 0;
            int f1 = 1;
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
            {
                int rem = (int)(n % 60);
                if (rem == 0)
                    return 0;
                for (int i = 2; i < rem + 3; i++)
                {
                    int f = (f0 + f1) % 60;
                    f0 = f1;
                    f1 = f;
                }
                return f1;
            }
        }
        public long Solve(long a, long b)
        {
            if (a >= b)
            {
                return (int)Math.Abs(fib(a) -
                              fib(b - 1)) % 10;
            }
            if (b > a)
            {
                return (int)Math.Abs(fib(b) -
                              fib(a - 1)) % 10;
            }

            return 0;
        }
    }
}
