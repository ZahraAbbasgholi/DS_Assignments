using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public readonly static int d = 256;
        public long[] Solve(string pattern, string text)
        {
            long p = 1000000007;
            long h = 1;
            long pHash = 0;
            long tHash = 0;
            int i , j;
            List<long> result = new List<long>();
            for (i = 0; i < pattern.Length - 1; i++)
            {
                h = (h * d) % p;
            }
            for (i = 0; i < pattern.Length; i++)
            {
                pHash = ((d * pHash) + pattern[i]) % p;
                tHash = ((d * tHash) + text[i]) % p;
            }
            for (i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (pHash == tHash)
                {
                    for (j = 0; j < pattern.Length; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }
                    if (j == pattern.Length)
                    {
                        result.Add(i);
                    }
                }
                if (i < text.Length - pattern.Length)
                {
                    tHash = (d * (tHash - (text[i] * h)) + text[i + pattern.Length]) % p;
                    if (tHash < 0)
                        tHash += p;
                }
            }
            return result.ToArray();
        }

        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            var H = new long[T.Length - P + 1];
            string S = string.Empty;
            for (int i = T.Length - P; i < T.Length; i++)
            {
                S += T[i];
            }
            H[T.Length - P] = Q2HashingWithChain.PolyHash(S, 0, 0, p, x);
            long y = 1;
            for (int j = 1; j < P; j++)
            {
                y = (y * x) % p;
            }
            for (int k = T.Length - P - 1; k >= 0; k--)
            {
                H[k] = (((x * H[k+1]) + T[k]) - (y * T[k + P])) % p;
            }
            return H;
        }
    }
}
