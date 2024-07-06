using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }
        List<Tuple<long, long>> result = new List<Tuple<long, long>>();

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            result.RemoveRange(0, result.Count);
            result = new List<Tuple<long, long>>();
            BuildHeap(array);
            return result.ToArray();
        }

        public void BuildHeap(long[] array)
        {
            int size = array.Count();
            for (int i = size / 2; i >= 0; i--)
            {
                SiftDown(i, size, array);
            }
        }

        public void SiftDown(int i, int size, long[] array)
        {
            int minIdx = i;
            int r = RightChild(i);
            int l = LeftChild(i);
            if (l < size && array[l] < array[minIdx])
                minIdx = l;
            if (r < size && array[r] < array[minIdx])
                minIdx = r;
            if (i != minIdx)
            {
                swap(array, i, minIdx);
                SiftDown(minIdx, size, array);
            }
        }

        public void swap(long[] array, long i1, long i2)
        {
            long tmp = array[i2];
            array[i2] = array[i1];
            array[i1] = tmp;
            var x = Tuple.Create(i1, i2);
            result.Add(x);
        }

        public int RightChild(int i)
        {
            return (2 * i) + 2;
        }

        public int LeftChild(int i)
        {
            return (2 * i) + 1;
        }
    }
}