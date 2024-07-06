using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);


        public virtual long Solve(long money)
        {
            long ten = money / 10;
            long five = (money - ten * 10) / 5;
            long one = (money - (ten * 10 + five * 5)) / 1;
            return ten + five + one;
        }
    }
}
