using System;

namespace ProblemBCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nmk = Console.ReadLine().Split(' ');
            int n = int.Parse(nmk[0]);
            int m = int.Parse(nmk[1]);
            int k = int.Parse(nmk[2]);
            bool[,] graph = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    graph[i, j] = false;
                }
            }
            string[] Line;
            int from, to;
            for (int i = 0; i < k; i++)
            {
                Line = Console.ReadLine().Split(' ');
                from = int.Parse(Line[0]) - 1;
                to = int.Parse(Line[1]) - 1;
                graph[from, to] = true;
            }            

            bool[] isVisited = new bool[n];
            int[] matching = new int[m];
            for (int i = 0; i < m; i++)
            {
                matching[i] = -1;
            }
            int amount = 0;
            for (int v = 0; v < n; v++)
            {
                for (int i = 0; i < n; i++)
                {
                    isVisited[i] = false;
                }
                // if Kuhn returns true it means current matching is not max
                if (Kuhn(v, ref graph, ref isVisited, ref matching))
                {
                    amount++;
                }
            }
            Console.WriteLine(amount);            
        }

        static bool Kuhn(int u, ref bool[,] graph, ref bool[] isVisited, ref int[] matching)
        {
            if (isVisited[u])
            {
                return false;
            }
            isVisited[u] = true;
            for (int v = 0; v < graph.GetLength(1); v++)
            {
                if (graph[u, v])
                {
                    // vertex is not matched or augmenting path could be found
                    if (matching[v] == -1 || Kuhn(matching[v], ref graph, ref isVisited, ref matching))
                    {
                        // reversing uv to vu
                        matching[v] = u;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}