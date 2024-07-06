using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            // write your code here
            // throw new NotImplementedException();
            int m = str2.Length, n = str1.Length;
            var res = EditDistance(str2, m, str1, n);
            return res;
        }

        private int EditDistance(string str1, int m, string str2, int n)
        {
            int[ , ] D = new int[m+1, n+1];
            for (int i = 0; i <= m; i++)
                D[i, 0] = i;
            for (int j = 0; j <= n; j++)
                D[0, j] = j;
            for (int a = 1; a <= m; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    int Insert = D[a, b-1] + 1;
                    int delete = D[a-1, b] + 1;
                    int match = D[a-1, b-1];
                    int mismatch = D[a-1, b-1] + 1;
                    if (str1[a-1] == str2[b-1])
                        D[a, b] = Min(Insert, delete, match);
                    else
                        D[a, b] = Min(Insert, delete, mismatch);
                }
            }
            return D[m, n];
        }

        private int Min(int v1, int v2, int v3)
        {
            if (v1 < v2 && v1 < v3)
                return v1;
            if (v2 < v3 && v2 < v1)
                return v2;
            return v3;
        }
    }
}
