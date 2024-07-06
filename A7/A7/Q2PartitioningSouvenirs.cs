using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            // throw new NotImplementedException();
            return Partition(souvenirsCount, souvenirs);
        }

        private long Partition(long souvenirsCount, long[] souvenirs)
        {
            if (souvenirsCount == 0)
                return 0;
            long sum = souvenirs.Sum();
            if (sum % 3 != 0)
                return 0;
            long[,] table = new long[souvenirsCount+1, sum+1];
            for (int i = 0; i <= souvenirsCount; i++)
                for (int j = 0; j <= sum; ++j)
                    table[i, j] = -1;
            return Divisible(souvenirsCount, souvenirs, sum/3, table);
        }

        private long Divisible(long souvenirsCount, long[] souvenirs, long sum, long[,] table)
        {
            if (sum == 0)
                return 1;
            if (souvenirsCount == 0 && sum != 0)
                return 0;
            if (table[souvenirsCount, sum] != -1)
                return table[souvenirsCount, sum];
            if (souvenirs[souvenirsCount-1] > sum)
                return Divisible(souvenirsCount-1, souvenirs, sum, table);
            if (Divisible(souvenirsCount-1, souvenirs, sum, table) != 0 ||
                Divisible(souvenirsCount-1, souvenirs, sum - souvenirs[souvenirsCount-1], table) != 0)
                return table[souvenirsCount, sum] = 1;
            return table[souvenirsCount, sum] = 0;
        }
    }
}
