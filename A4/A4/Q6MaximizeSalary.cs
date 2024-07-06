using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            string result = "";
            var Digits = numbers.ToList();
            Digits.Sort();
            while (Digits.Count != 0)
            {
                long maxDigit = Digits[0];
                for (int i = 0; i < Digits.Count; i++)
                {
                    if (GreaterOrEqual(Digits[i], maxDigit))
                        maxDigit = Digits[i];
                }
                result += maxDigit;
                Digits.Remove(maxDigit);
            }
            return result;
        }

        private bool GreaterOrEqual(long digit, long maxDigit)
        {
            string result1 = $"{digit}{maxDigit}", result2 = $"{maxDigit}{digit}";
            if (int.Parse(result1) > int.Parse(result2))
                return true;
            return false;
        }
    }
}

