using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            // write your code here
            // throw new NotImplementedException();
            long[] table = new long[n];
            table[0] = 0;
            table[1] = 0;
            for (int a = 2; a < 4; a++)
                table[a] = 1;
            for (int i = 4; i < n; i++)
            {
                long minus = table[i - 1];
                long multiply2 = Random.Shared.NextInt64(), multiply3 = Random.Shared.NextInt64();
                if (i % 2 == 0)
                    multiply2 = table[i / 2];
                if (i % 3 == 0)
                    multiply3 = table[i / 3];
                long min = Math.Min(Math.Min(minus, multiply2), multiply3);
                table[i] = min+1;
            }
            List<long> result = new List<long>();
            long num = n;
            result.Add(num);
            while (num != 1)
            {
                long minidx = Min(table, num);
                result.Add(minidx);
                num = minidx;
            }
            result.Reverse();
            return result.ToArray();
        }

        private long Min(long[] table, long num)
        {
            long min = Random.Shared.NextInt64();
            long minidx = 0;

            long minus = table[num - 1];
            long multiply2 = Random.Shared.NextInt64(), multiply3 = Random.Shared.NextInt64();
            if (num % 2 == 0)
                multiply2 = table[num / 2];
            if (num % 3 == 0)
                multiply3 = table[num / 3];
            if (minus <= min)
            {
                min = minus;
                minidx = num-1;
            }
            if (multiply2 <= min)
            {
                min = multiply2;
                minidx = num/2;
            }
            if (multiply3 <= min)
            {
                min = multiply3;
                minidx = num/3;
            }
            // if (multiply2 == minus || multiply2 == multiply3)
            // {
            //     min = multiply2;
            //     minidx = num/2;
            // }
            // if (multiply3 == minus || multiply3 == multiply2)
            // {
            //     min = multiply3;
            //     minidx = num/3;
            // }
            // if (minus < multiply2 && minus < multiply3)
            // {
            //     min = minus;
            //     minidx = num-1;
            // }
            // if (multiply2 < minus && multiply2 < multiply3)
            // {
            //     min = multiply2;
            //     minidx = num/2;
            // }
            // if (multiply3 < minus && multiply3 < multiply2)
            // {
            //     min = multiply3;
            //     minidx = num/3;
            // }
            return minidx;
        }
    }
}