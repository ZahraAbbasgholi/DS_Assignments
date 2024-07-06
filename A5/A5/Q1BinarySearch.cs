using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] a, long[] b)
        {
            //write your code here
            // throw new NotImplementedException();
            int size = a.Count();
            int sizeB = b.Count();
            long[] result = new long[sizeB];
            for (int i = 0; i < sizeB; i++)
                result[i] = BinarySearch(a, 0, size - 1, b[i]);
            return result;
        }

        public long BinarySearch(long[] a, int low, int high, long key)
        {
            if (high < low)
                return -1;
            int mid = low + ((high - low) / 2);
            if (key == a[mid])
                return mid;
            if (key < a[mid])
                return BinarySearch(a, low, mid - 1, key);
            else
                return BinarySearch(a, mid + 1, high, key);
        }
    }
}
