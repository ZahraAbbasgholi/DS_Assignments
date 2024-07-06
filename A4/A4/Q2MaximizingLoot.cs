using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            var weight = weights.ToList();
            var value = values.ToList();
            double result_value = 0;
            List<double> val = new List<double>();
            for (int i = 0; i < value.Count(); i++)
            {
                val.Add((double)value[i] / (double)weight[i]);
            }
            double capa = 0;
            while (capa != capacity)
            {
                double m = val.Max();
                int idx = val.FindIndex(x => x == m);
                double w = (double)weight[idx];
                double n = (double)capacity - capa;
                if (n >= w)
                    capa += w;
                else
                {
                    capa += n;
                    w = n;
                }
                result_value += w * m;
                val.RemoveAt(idx);
                weight.RemoveAt(idx);
                value.RemoveAt(idx);
            }
            return (long)result_value;
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}