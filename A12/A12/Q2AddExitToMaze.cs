using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            // throw new NotImplementedException();

            Graph g = new Graph(nodeCount);
            for (int i = 0; i < edges.Count(); i++)
                g.addEdge(edges[i][0], edges[i][1]);
            long result = g.NumberOfconnectedComponents();
            return result;

        }
        public class Graph
        {
            public List<List<long>> neighbor_vertices;
            public long V;
            public Graph(long V)
            {
                this.V = V;
                neighbor_vertices = new List<List<long>>();
                for (int i = 0; i <= V; i++)
                    neighbor_vertices.Add(new List<long>());
            }

            public void addEdge(long v, long w)
            {
                neighbor_vertices[(int)v].Add(w);
                neighbor_vertices[(int)w].Add(v);
            }

            public void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;

                for (int i = 0; i < neighbor_vertices[v].Count; i++)
                    if (!visited[neighbor_vertices[v][i]])
                        DFSUtil((int)neighbor_vertices[v][i], visited);

                // foreach (var item in neighbor_vertices[v])
                // {
                //     if (!visited[item])
                //         DFSUtil((int)item, visited);
                // }
            }

            public long NumberOfconnectedComponents()
            {
                bool[] visited = new bool[V+1];

                long count = 0;
                for (int v = 0; v <= V; v++)
                    visited[v] = false;

                for (int v = 1; v <= V; v++)
                {
                    if (visited[v] == false)
                    {
                        DFSUtil(v, visited);
                        count += 1;
                    }
                }
                return count;
            }
        }
    }
}