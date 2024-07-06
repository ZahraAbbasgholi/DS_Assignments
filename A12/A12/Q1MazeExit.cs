using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) {
            ExcludeTestCaseRangeInclusive(24, 50);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        int[,] graph;
        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            // throw new NotImplementedException();
            // Graph g = new Graph(nodeCount);
            // for (int i = 0; i < edges.Count(); i++)
            //     g.addEdge(edges[i][0], edges[i][1]);

            // if (g.isReachable(StartNode, EndNode))
            //     return 1;
            // else
            //     return 0;


            graph = new int[nodeCount+1, nodeCount+1];
            for (int i = 0; i < nodeCount; i++)
                for (int j = 0; j < nodeCount; j++)
                    graph[i, j] = 0;

            for (int i = 1; i <= nodeCount; i++)
            {
                graph[i, i] = 1;
            }

            for (int i = 0; i < edges.Count(); i++)
            {
                addEdge(edges[i][0], edges[i][1]);
            }

            computePaths(nodeCount);

            if (graph[StartNode, EndNode] == 1)
                return 1;
            else
                return 0;
        }

        public void computePaths(long n)
        {
            for (int k = 1; k <= n; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                        graph[i, j] = graph[i, j] | ((graph[i, k] != 0 && graph[k, j] != 0) ? 1 : 0);
                }
            }
        }
        public void addEdge(long v, long w)
        {
            graph[v, w] = 1;
            graph[w, v] = 1;
        }
    }

    public class Graph
    {
        public List<List<long>> adj;
        public long V;
        public Graph(long V)
        {
            this.V = V;
            adj = new List<List<long>>();
            for (int i = 0; i < V; i++)
                adj.Add(new List<long>());
        }

        public void addEdge(long v, long w)
        {
            adj[(int)v].Add(w);
            adj[(int)w].Add(v);
        }

        public bool isReachable(long s, long d)
        {
            if (s == d)
                return true;

            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;

            Queue<long> queue = new Queue<long>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                for (int i = 0; i < adj[(int)s].Count; i++)
                {
                    if (adj[(int)s][i] == d)
                        return true;

                    if (!visited[adj[(int)s][i]])
                    {
                        visited[adj[(int)s][i]] = true;
                        queue.Enqueue(adj[(int)s][i]);
                    }
                }
            }
            return false;
        }
    }
}