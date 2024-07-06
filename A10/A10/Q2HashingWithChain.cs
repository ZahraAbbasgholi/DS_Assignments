using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);
        Dictionary<long, List<string>> hash_list;
        List<string> result;
        public static long bucket = 0;
        public string[] Solve(long bucketCount, string[] commands)
        {
            bucket = bucketCount;
            hash_list = new Dictionary<long, List<string>>();
            for (int i = 0; i < bucketCount; i++)
            {
                hash_list[i] = new List<string>();
            }
            result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                hash = ((hash * x) + str[i]) % p;
            }
            if (bucket == 0)
                return hash;
            return hash % bucket;
        }

        public void Add(string str)
        {
            long CalculateHash = PolyHash(str, 0, 0, 1000000007, 263);
            if (!hash_list[CalculateHash].Contains(str))
            {
                hash_list[CalculateHash].Add(str);
            }
        }
        public void Delete(string str)
        {
            long CalculateHash = PolyHash(str, 0, 0, 1000000007, 263);
            if (hash_list[CalculateHash].Contains(str))
            {
                hash_list[CalculateHash].Remove(str);
            }
        }
        public string Find(string str)
        {
            long CalculateHash = PolyHash(str, 0, 0, 1000000007, 263);
            if (hash_list[CalculateHash].Contains(str))
                return "yes";
            else
                return "no";
        }
        public string Check(int i)
        {
            if (hash_list[i].Count == 0)
            {
                return "-";
            }
            string CheckStr = string.Empty;
            for (int j = hash_list[i].Count-1; j >= 0; j--)
            {
                CheckStr += $"{hash_list[i][j]} ";
            }
            return CheckStr.TrimEnd();
        }
    }
}
