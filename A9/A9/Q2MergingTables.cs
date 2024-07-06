using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        public List<long> rank = new List<long>{};
        public List<long> parent = new List<long>{};
        public List<long> result = new List<long>{};
        

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            rank.RemoveRange(0, rank.Count);
            parent.RemoveRange(0, parent.Count);
            result.RemoveRange(0, result.Count);

            int size = targetTables.Count();
            for (int i = 0; i < size; i++)
            {
                MakeSet(i, tableSizes);
            }
            for (int j = 0; j < size; j++)
            {
                Union(targetTables[j]-1, sourceTables[j]-1, tableSizes);
            }
            return result.ToArray();
        }

        public void MakeSet(int i, long[] tableSizes)
        {
            parent.Add(i);
            rank.Add(tableSizes[i]);   
        }

        public void Union(long i, long j, long[] tableSizes)
        {
            long i_id = Find(i);
            long j_id = Find(j);
            if (i_id == j_id)
            {
                if (tableSizes[i_id] == 0)
                    result.Add(tableSizes.Max());
                else
                    result.Add(tableSizes[i_id]);
                return;
            }
            if (rank[(int)i_id] > rank[(int)j_id])
                parent[(int)j_id] = i_id;
            else
            {
                parent[(int)i_id] = j_id;
                if (rank[(int)i_id] == rank[(int)j_id])
                    rank[(int)j_id] = rank[(int)j_id] + 1; 
            }
            if (tableSizes[i_id] == 0)
            {
                tableSizes[parent[(int)i_id]] += tableSizes[j_id];
            }
            if (tableSizes[j_id] == 0)
            {
                tableSizes[i_id] += tableSizes[parent[(int)j_id]];
            }
            if (tableSizes[i_id] == 0 && tableSizes[j_id] == 0)
            {
                tableSizes[parent[(int)i_id]] += tableSizes[parent[(int)j_id]];
            }
            else
            {
                tableSizes[i_id] += tableSizes[j_id];
                tableSizes[j_id] = 0;
            }
            if (result.Count() != 0)
            {
                result.Add(tableSizes.Max());
            }
            else
                result.Add(tableSizes[i_id]);
        }
        public long Find(long a)
        {
            List<long> parent_to_update = new List<long>();
            while (a != parent[(int)a])
            {
                parent_to_update.Append(parent[(int)a]);
                a = parent[(int)a];
            }
            foreach (var item in parent_to_update)
                parent[(int)item] = a;
            return a;
        }
    }
}
