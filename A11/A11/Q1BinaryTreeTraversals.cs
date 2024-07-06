using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) {
            ExcludeTestCaseRangeInclusive(43, 49);
        }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        long[][] result;
        List<long> key;
        List<long> left;
        List<long> right;
        public long[][] Solve(long[][] nodes)
        {
            key = new List<long>();
            left = new List<long>();
            right = new List<long>();
            for (int i = 0; i < nodes.Length; i++)
            {
                key.Add(nodes[i][0]);
                left.Add(nodes[i][1]);
                right.Add(nodes[i][2]);
            }
            // throw new NotImplementedException();
            result = new long[3][];
            result[0] = new long[key.Count];
            result[1] = new long[key.Count];
            result[2] = new long[key.Count];

            i = 0; j = 0; k = 0;
            InOrder();
            PreOrder();
            PostOrder();
            return result;
        }

        public void InOrder()
        {
            InOrderTraversal(0);
        }
        public int i = 0;
        public void InOrderTraversal(long v)
        {
            if (v == -1)
                return;
            InOrderTraversal(left[(int)v]);
            result[0][i] = key[(int)v];
            i++;
            InOrderTraversal(right[(int)v]);
        }
        public void PreOrder()
        {
            PreOrderTraversal(0);
        }
        public int j = 0;
        public void PreOrderTraversal(long v)
        {
            if (v == -1)
                return;
            result[1][j] = key[(int)v];
            j++;
            PreOrderTraversal(left[(int)v]);
            PreOrderTraversal(right[(int)v]);
        }
        public void PostOrder()
        {
            PostOrderTraversal(0);
        }
        public int k = 0;
        public void PostOrderTraversal(long v)
        {
            if (v == -1)
                return;
            PostOrderTraversal(left[(int)v]);
            PostOrderTraversal(right[(int)v]);
            result[2][k] = key[(int)v];
            k++;
        }
    }
}