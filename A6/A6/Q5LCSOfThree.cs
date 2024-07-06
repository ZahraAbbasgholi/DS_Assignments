using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            // write your code here
            // throw new NotImplementedException();
            long m = seq1.Count(), n = seq2.Count(), q = seq3.Count();
            long[, ,] D = new long[m+1, n+1, q+1];
            for (int a = 0; a <= m; a++)
                D[a, 0, 0] = 0;
            for (int b = 0; b <= n; b++)
                D[0, b, 0] = 0;
            for (int c = 0; c <= q; c++)
                D[0, 0, c] = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= q; k++)
                    {
                        if (seq1[i-1] == seq2[j-1] && seq1[i-1] == seq3[k-1])
                        {
                            D[i, j, k] = D[i-1, j-1, k-1] + 1;
                        }
                        else
                        {
                            D[i, j, k] = Math.Max(Math.Max(D[i-1, j, k], D[i, j-1, k]), D[i, j, k-1]);
                        }
                    }
                }
            }
            return D[m, n, q];
        }
    }
}
