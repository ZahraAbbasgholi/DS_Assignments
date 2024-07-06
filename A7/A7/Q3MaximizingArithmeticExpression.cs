using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            // throw new NotImplementedException();
            List<long> digits = new List<long>();
            List<char> ops = new List<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (i % 2 == 0)
                    digits.Add(long.Parse(expression[i].ToString()));
                else
                    ops.Add(expression[i]);
            }
            long digCount = digits.Count();
            long[,] min = new long[digCount, digCount];
            long[,] max = new long[digCount, digCount];
            for (int i = 0; i < digCount; i++)
            {
                min[i, i] = digits[i];
                max[i, i] = digits[i];
            }
            for (int s = 0; s < digCount; s++)
            {
                for (int i = 0; i < digCount-s-1; i++)
                {
                    int j = i+s+1;
                    (min[i, j], max[i, j]) = MinAndMax(i, j, max, min, ops);
                }
            }
            return max[0, digCount-1];
        }

        private (long min, long max) MinAndMax(int i, int j, long[,] max, long[,] min, List<char> ops)
        {
            long m = long.MaxValue, M = long.MinValue;
            for (int k = i; k < j; k++)
            {
                long a = Calculate(max[i, k], max[k+1, j], ops[k]);
                long b = Calculate(max[i, k], min[k+1, j], ops[k]);
                long c = Calculate(min[i, k], max[k+1, j], ops[k]);
                long d = Calculate(min[i, k], min[k+1, j], ops[k]);
                List<long> l = new List<long>{a, b, c, d};
                m = minimum(l, m);
                M = maximum(l, M);
            }
            return (m, M);
        }

        private long maximum(List<long> l, long M)
        {
            long max_v = l.Max();
            if (max_v > M)
                return max_v;
            return M;
        }

        private long minimum(List<long> l, long m)
        {
            long min_v = l.Min();
            if (min_v < m)
                return min_v;
            return m;
        }

        private long Calculate(long x, long y, char op)
        {
            if (op == '+')
                return x + y;
            if (op == '-')
                return x - y;
            if (op == '*')
                return x * y;
            return 0;
        }
    }
}
