using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            throw new NotImplementedException();
            // int i = 0, j = (int)n;
            // List<long> selected_num = new List<long>();
            // while (true)
            // {
            //     if (numbers[i] > 0)
            //     {
            //         while (true)
            //         {
            //             if (numbers[j] > 0)
            //                 break;
            //             j--;
            //         }
            //         break;
            //     }
            //     i++;
            // }
            // for (int k = i; k <= j; k++)
            //     selected_num.Add(numbers[k]);
            // return selected_num.Sum();
        }
    }
}
