using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);


        public long Solve(long n)
        {
            List<long> fib = new List<long>{0,1,1};
            int i=3, m=0;
            for (i = 3; i <= n; i++)
            {
                fib.Add(fib[i-1] + fib[i-2]);
            }
            m = (int)n;
            return fib[m];
        }
    }
}
