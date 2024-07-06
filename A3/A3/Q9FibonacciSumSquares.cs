using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            // throw new NotImplementedException();
            long S = (fib(n-1) + fib(n)) * (fib(n));
            return S % 10;
        }

        public long fib(long n)
        {
            // throw new NotImplementedException();
            List<long> fibo = new List<long>{0,1,1};
            int i=3;
            for (i = 3; i <= n; i++)
            {
                fibo.Add(fibo[i-1] + fibo[i-2]);
            }
            return fibo[(int)n];
        }
    }
}
