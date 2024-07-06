using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            long result = 1;
            var start = startTimes.ToList();
            var end = endTimes.ToList();
            start.Sort();
            for (int i = 0; i < tenantCount; i++)
            {
                int idx = Array.FindIndex(startTimes, x => x == start[i]);
                end[i] = endTimes[idx];
                endTimes[idx] = 0;
                startTimes[idx] = 0;
            }
            long min_end = end.Min();
            int j = 0;
            while (end.Count != 0)
            {
                if (start[j] > min_end)
                {
                    min_end = end.Min();
                    result++;
                }
                else
                {
                    end.RemoveAt(j);
                    start.RemoveAt(j);
                }
            }
            return result;
        }
    }
}
