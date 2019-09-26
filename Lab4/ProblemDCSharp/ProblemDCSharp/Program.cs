using System;

namespace ProblemDCSharp
{
    class Program
    {
        struct Edge
        {
            public int from; 
            public int to; 
            public decimal weight; 

            public Edge(int from, int to, decimal weight)
            {
                this.from = from;
                this.to = to;
                this.weight = weight;
            }
        }

        static void DFS(ref Edge[] edges, ref bool[] isInNegativeCycle, int vertex)
        {
            isInNegativeCycle[vertex] = true;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i].from == vertex && !isInNegativeCycle[edges[i].to])
                {
                    DFS(ref edges, ref isInNegativeCycle, edges[i].to);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] nms = Console.ReadLine().Split(' ');
            int n = int.Parse(nms[0]);
            int m = int.Parse(nms[1]);
            long s = long.Parse(nms[2]) - 1;
            Edge[] edges = new Edge[m];
            int from, to;
            long weight;           
            string[] Line;
            for (long i = 0; i < m; i++)
            {
                Line = Console.ReadLine().Split(' ');
                from = int.Parse(Line[0]) - 1;
                to = int.Parse(Line[1]) - 1;
                weight = long.Parse(Line[2]);               
                edges[i] = new Edge(from, to, weight);
            }
           
            decimal[] lengths = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                lengths[i] = decimal.MaxValue;
            }
            lengths[s] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // doing relaxations
                    if (lengths[edges[j].from] < decimal.MaxValue)
                    {
                        if (lengths[edges[j].to] > lengths[edges[j].from] + edges[j].weight)
                        {
                            lengths[edges[j].to] = lengths[edges[j].from] + edges[j].weight;
                        }
                    }
                }
            }
            
            //Afterwards making relaxations, we've found the shortest ways. So if we find shorter way here
            //for some vertex, it means it is in negative cycle
            bool[] isInNegativeCycle = new bool[n];
            for (int j = 0; j < m; j++)
            {
                if (lengths[edges[j].from] < decimal.MaxValue)
                {
                    if (lengths[edges[j].to] > lengths[edges[j].from] + edges[j].weight)
                    {
                        if (!isInNegativeCycle[edges[j].to])
                        {
                            DFS(ref edges, ref isInNegativeCycle, edges[j].to);
                        }
                    }
                }
            }
           
            for (int i = 0; i < n; i++)
            {               
                if (isInNegativeCycle[i])
                {
                    Console.WriteLine("-");
                }
                else if (lengths[i] == decimal.MaxValue)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine(lengths[i]);
                }
            }
        }
    }
}