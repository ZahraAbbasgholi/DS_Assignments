using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long gcd(long a, long b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a > b)
                return gcd(b , a%b);
            if (b > a)
                return gcd(a , b%a);
            return 0;
        }
        public long Solve(long a, long b)
        {
            return (a / gcd(a, b)) * b;
        }

    }
}
