using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        {
            // this.ExcludeTestCaseRangeInclusive(5, 5);
        }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] Xs, long[] Ys)
        {
            //write your code here
            // throw new NotImplementedException();
            // double minDist = Math.Sqrt(Math.Pow((Xs[0] - Xs[1]), 2) + Math.Pow((Ys[0] - Ys[1]), 2));
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = i + 1; j < n; j++)
            //     {
            //         double d = Math.Sqrt(Math.Pow((Xs[i] - Xs[j]), 2) + Math.Pow((Ys[i] - Ys[j]), 2));
            //         if (d < minDist)
            //             minDist = d;
            //     }
            // }
            // return Math.Round(minDist, 4);


            int mid = (int)n/2;
            double d1 = Search(0, mid, Xs, Ys);
            double d2 = Search(mid+1, (int)n-1, Xs, Ys);
            if (d1 < d2)
                return d1;
            return d2;

            
        }

        public double Search(int low, int high, long[] Xs, long[] Ys)
        {
            double minDist = Math.Sqrt(Math.Pow((Xs[low] - Xs[low+1]), 2) + Math.Pow((Ys[low] - Ys[low+1]), 2));
            if (high > 3)
            {
                int i = low;
                for (int j = low+1; j < high; j++)
                {
                    double d = Math.Sqrt(Math.Pow((Xs[i] - Xs[j]), 2) + Math.Pow((Ys[i] - Ys[j]), 2));
                    if (d < minDist)
                        minDist = d;
                    i++;
                }
            }
            return minDist;
        }
    }
}