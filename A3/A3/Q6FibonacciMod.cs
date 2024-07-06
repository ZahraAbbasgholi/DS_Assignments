using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            List<int> fib_mod_b = new List<int>{0 , 1};
            for (int i = 2; i <= a; i++)
            {
                fib_mod_b.Add((int)((fib_mod_b[i-1] + fib_mod_b[i-2]) % b));
            }
            return fib_mod_b[(int)a];
        }
    }
}
