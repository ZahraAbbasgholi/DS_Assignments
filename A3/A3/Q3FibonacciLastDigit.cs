using System;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<int> fib_rem = new List<int>{0,1,1};
            int i=3;
            for (i = 3; i <= n; i++)
            {
                fib_rem.Add((fib_rem[i-1] + fib_rem[i-2])%10);
            }
            return fib_rem[(int)n];
        }
    }
}
