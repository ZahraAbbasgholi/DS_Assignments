using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery : Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        { 
            this.ExcludeTestCaseRangeInclusive(5,5);
        }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            //write your code here
            // throw new NotImplementedException();
            int n = points.Count();
            long[] result = new long[n];
            for (int i = 0; i < n; i++)
            {
                int c = Counter(points[i], startSegments, endSegment);
                result[i] = c;
            }
            return result;
        }

        public int Counter(long v, long[] startSegments, long[] endSegment)
        {
            int count = 0, size = startSegments.Count();
            for (int j = 0; j < size; j++)
            {
                if (v > startSegments[j] && v < endSegment[j])
                {
                    count++;
                }
            }
            return count;
        }
    }
}