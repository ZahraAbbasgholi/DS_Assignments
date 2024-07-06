using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            int i = 1;
            List<long> result = new List<long>();
            while (true)
            {
                if (n > 2 * i)
                {
                    result.Add(i);
                    n -= i;
                }
                else
                {
                   result.Add(n);
                   break;
                }
                i++;
            }
            return result.ToArray();
        }
    }
}