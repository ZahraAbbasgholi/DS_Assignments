using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            // write your code here
            // throw new NotImplementedException();
            long[] minNum = new long[n+1];
            minNum[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                minNum[i] = Random.Shared.NextInt64();
                for (int j = 0; j < 3; j++)
                {
                    if (i >= COINS[j])
                    {
                        long numCoins = minNum[i-COINS[j]] + 1;
                        if (numCoins < minNum[i])
                        {
                            minNum[i] = numCoins;
                        }
                    }
                }
            }
            return minNum[n];
            
            // long count = 0, remain = n;
            // for (int i = 2; i >= 0; i--)
            // {
            //     if (remain == 2)
            //     {
            //         return count+1;
            //     }
            //     if (remain % COINS[i] == 0)
            //     {
            //         long c = remain / COINS[i];
            //         count += c;
            //         remain = remain - (c * COINS[i]);
            //     }
            //     else
            //     {
            //         long c = remain / COINS[i];
            //         count += c;
            //         remain = remain - (c * COINS[i]);
            //     }
            // }
            // return count;
        }
    }
}
