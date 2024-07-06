using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            // write your code here
            // throw new NotImplementedException();
            long m = seq1.Count();
            long n = seq2.Count();
            long[,] D = new long[m+1, n+1];
            for (int i = 0; i <= m; i++)
                D[i, 0] = 0;
            for (int j = 0; j <= n; j++)
                D[0, j] = 0;
            for (int a = 1; a <= m; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    if (seq1[a-1] == seq2[b-1])
                    {
                        D[a, b] = D[a-1, b-1] + 1;
                    }
                    else
                    {
                        D[a, b] = Math.Max(D[a-1, b] , D[a, b-1]);
                    }
                }
            }
            return D[m, n];
        }
    }
}
