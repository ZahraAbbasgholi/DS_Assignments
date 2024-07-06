using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) {
            ExcludeTestCaseRangeInclusive(47,49);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        List<long> result;
        List<long> key;
        List<long> left;
        List<long> right;
        public bool Solve(long[][] nodes)
        {
            // throw new NotImplementedException();
            key = new List<long>();
            left = new List<long>();
            right = new List<long>();
            for (int i = 0; i < nodes.Length; i++)
            {
                key.Add(nodes[i][0]);
                left.Add(nodes[i][1]);
                right.Add(nodes[i][2]);
            }
            
            bool b = IsBinarySearchTree(nodes);
            return b;
        }
        public bool IsBinarySearchTree(long[][] nodes)
        {
            if (nodes.Length == 0)
                return true;
            result = new List<long>();
            inorder(0);
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i] <= result[i-1])
                    return false;
            }
            return true;
        }
        public void inorder(long x)
        {
            if (x != -1)
            {
                inorder(left[(int)x]);
                result.Add(key[(int)x]);
                inorder(right[(int)x]);
            }
        }
    }
}
