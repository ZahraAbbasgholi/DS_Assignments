using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            //Write your code here
            // throw new NotImplementedException();
            return Table(W, goldBars);
        }

        private long Table(long W, long[] goldBars)
        {
            long goldlen = goldBars.Length;
            long[,] table = new long[goldlen+1, W+1];
            // for (int i = 0; i < length; i++)
            // {
                
            // }
            for (int g = 1; g < goldlen+1; g++)
            {
                for (int w = 1; w < W+1; w++)
                {
                    table[g, w] = table[g-1, w];
                    if (goldBars[g-1] <= w)
                    {
                        long weight = table[g-1, w - goldBars[g-1]] + goldBars[g-1];
                        if (table[g, w] < weight)
                            table[g, w] = weight;
                    }
                }
            }
            return table[goldlen, W];
        }
    }
}
