using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions : Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            //write your code here
            // throw new NotImplementedException();
            // int Count = 0;
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = i+1; j < n; j++)
            //     {
            //         if (a[i] > a[j])
            //             Count++;
            //     }
            // }
            // return Count;

            // int i = 0;
            // int m = (int)n;
            // while (m > 0)
            // {
            //     for (int j = i + 1; j < n; j++)
            //     {
            //         if (a[i] > a[j])
            //             Count++;   
            //     }
            //     i++;
            //     m--;
            // }
            // return Count;

            // int Count = Partition(a, 0, n);
            // return Count;

            int c = Partition2(a, 0, n-1);
            return c;
        }

        private int Partition2(long[] a, int low, long high)
        {
            long mid = low + ((high - low) / 2);
            long[] left = new long[mid-low+1];
            long[] right = new long[high-mid];
            for (int i = 0; i <= mid; i++)
            {
                left[i] = a[i];
            }
            for (int j = 0; j <= high-mid; j++)
            {
                right[j] = a[mid + j];
            }
            int c = 0;
            c += Counter(left, low, mid);
            c += Counter(right, mid+1, high);
            for (int k = 0; k <= mid; k++)
            {
                c += Counter2(left[k], right, mid+1, high);
            }
            return c;
        }

        private int Counter2(long key, long[] arr, long low, long high)
        {
            int Count = 0;
            for (int i = 0; i <= high; i++)
            {
                if (key > arr[i])
                    Count++;
            }
            return Count;
        }

        private int Counter(long[] arr, long low, long mid)
        {
            int Count = 0, m = (int)mid, i = (int)low;
            while (m > 0)
            {
                for (int j = i + 1; j <= mid; j++)
                {
                    if (arr[i] > arr[j])
                        Count++;   
                }
                i++;
                m--;
            }
            return Count;
        }

        private int Partition(long[] a, long low, long high)
        {
            // throw new NotImplementedException();
            int c = 0;
            if (high > low)
            {
                long mid = low + ((high - low) / 2);
                c += Partition(a, low, mid);
                c += Partition(a, mid+1, high);
                c += Merge(a, low, mid, high-1);
                
            }
            return c;
        }

        private int Merge(long[] a, long low, long mid, long high)
        {
            int Count = 0;
            int i = (int)low, m = (int)high;
            while (m > 0)
            {
                for (int j = i + 1; j < high; j++)
                {
                    if (a[i] > a[j])
                        Count++;   
                }
                i++;
                m--;
            }
            return Count;
            // for (int i = 0; i < mid; i++)
            // {
            //     r[i] = a[low + i];
            // }
            // i = 0; j = 0;
            // for (i = 0; i < left.Count(); i++)
            // {
            //     for (j = 0; j < right.Count(); j++)
            //     {
            //         if (left[i] > right[j])
            //             Count++;
            //     }
            // }
            // for (int k = 0; k < left.Count(); k++)
            // {
            //     for (int q = k+1; q < left.Count()-1; q++)
            //         if (left[k] > left[q])
            //             Count++;
            // }
            // for (int z = 0; z < right.Count(); z++)
            // {
            //     for (int w=z+1; w < right.Count()-1; w++)
            //         if (right[z] > right[w])
            //             Count++;
            // }
            // return Count;
        }
    }
}
