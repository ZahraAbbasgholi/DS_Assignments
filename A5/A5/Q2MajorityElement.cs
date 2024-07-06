using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement : Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            //write your code here
            // throw new NotImplementedException();
            Array.Sort(a);
            long key = a[0], count = 1;
            for (int i = 1; i < n; i++)
            {
                if (a[i] == key)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    key = a[i];
                }
                if (count > n/2)
                    return 1;
            }
            return 0;
        }
    }
}