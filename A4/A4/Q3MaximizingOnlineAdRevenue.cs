using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            List<double> Max_income = new List<double>();
            var ad = adRevenue.ToList();
            ad.Sort();
            var ave = averageDailyClick.ToList();
            ave.Sort();
            for (int i=0; i<slotCount; i++)
                Max_income.Add((double)ad[i] * (double)ave[i]);
            return (long)Max_income.Sum();
        }
    }
}
