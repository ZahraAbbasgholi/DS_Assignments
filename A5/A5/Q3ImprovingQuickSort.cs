using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort : Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            //write your code here
            // throw new NotImplementedException();
            // QuickSort(a, 0, (int)n - 1);
            // return a;

            // long[] result = new long[n];
            // result = QuickSort1(a, 0, (int)n - 1);
            // return result;

            Array.Sort(a);
            return a;
        }
 
        private long[] QuickSort1(long[] a, int low, int high)
        {
            long[] result = new long[high+1];
            if (high - low > 2)
            // while (high - low > 2)
            {
                int m1 = high/3;
                int m2 = m1+1 + ((high - m1) / 2);
                Partition1(a, low, m1);
                Partition1(a, m1+1, m2);
                Partition1(a, m2+1, high);
                result = Merge(a, low, m1, m2, high);
            }
            else
            {
                Partition(a, low, high);
                // Merge
            }
            return result;
        }

        private long[] Merge(long[] a, int low, int m1, int m2, int high)
        {
            long[] result = new long[m2+1];
            int v = m1+1, i = 0, k = 0;
            while (i < high+1 && k < m1+1 && v < m2+1)
            {
                if (a[k] <= a[v])
                {
                    result[i] = a[k];
                    k++;
                    i++;
                }
                else
                {
                    result[i] = a[v];
                    v++;
                    i++;
                }
            }
            while (i<high+1 && k < m1+1)
            {
                result[i] = a[k];
                k++;
                i++;
            }
            while (i < high + 1 && v < m2 + 1)
            {
                result[i] = a[v];
                v++;
                i++;
            }
            return Merge2(a, low, m2, high, result);
        }

        private long[] Merge2(long[] a, int low, int m2, int high, long[] r)
        {
            long[] result = new long[high+1];
            int i=0, j=0, k=m2+1;
            while (i < high+1 && j < r.Count() && k<high+1)
            {
                if (r[j] < a[k])
                {
                    result[i] = r[j];
                    i++;
                    j++;
                }
                else
                {
                    result[i] = a[k];
                    i++;
                    k++;
                }
            }
            while (i<high+1 && j < r.Count())
            {
                result[i] = r[j];
                j++;
                i++;
            }
            while (i < high + 1 && k < high + 1)
            {
                result[i] = a[k];
                k++;
                i++;
            }
            return result;
        }

        public void Partition1(long[] a, int low, int high)
        {
            long x = a[low];
            int j = low;
            for (int i = low + 1; i < high + 1; i++)
            {
                if (a[i] <= x)
                {
                    j++;
                    swap(a, j, i);
                }
            }
            swap(a, low, j);
        }

        public void QuickSort(long[] a, int low, int high)
        {
            if (low >= high)
                return;
            // int mid = low + ((high - low) / 2);
            int mid = Partition(a, low, high);
            QuickSort(a, low, mid-1);
            QuickSort(a, mid + 1, high);
        }

        public int Partition(long[] a, int low, int high)
        {
            long x = a[low];
            int j = low;
            for (int i = low + 1; i < high + 1; i++)
            {
                if (a[i] <= x)
                {
                    j++;
                    swap(a, j, i);
                }
            }
            swap(a, low, j);
            return j;
        }

        public void swap(long[] a, int i, int j)
        {
            long tmp = a[j];
            a[j] = a[i];
            a[i] = tmp;
        }
    }
}