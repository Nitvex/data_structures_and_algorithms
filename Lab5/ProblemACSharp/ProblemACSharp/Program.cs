using System;

namespace ProblemACSharp
{
    class Program
    {
        static int findFlow(int vertex, ref int destination, ref int[,] capacity, ref bool[] isVisited, int flow)
        {
            if (vertex == destination)
            {
                return flow;
            }
            isVisited[vertex] = true;
            for (int v = 0; v < isVisited.Length; v++)
                if (!isVisited[v] && capacity[vertex, v] > 0)
                {
                    int addedFlow = findFlow(v, ref destination, ref capacity, ref isVisited, Math.Min(flow, capacity[vertex, v]));
                    if (addedFlow > 0)
                    {
                        capacity[vertex, v] -= addedFlow;
                        capacity[v, vertex] += addedFlow;
                        return addedFlow;
                    }
                }
            return 0;
        }

        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            int[,] capacity = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    capacity[i, j] = 0;
                }
            }
            string[] Line;
            for (int i = 0; i < m; i++)
            {
                Line = Console.ReadLine().Split(' ');
                int from = int.Parse(Line[0])-1;
                int to = int.Parse(Line[1])-1;
                int cap = int.Parse(Line[2]);
                capacity[from, to] = cap;
            }

            int destination = n - 1;
            bool[] isVisited = new bool[n];
            int flow = 0, addedFlow = 1;
            while (addedFlow > 0)
            {
                for (long i = 0; i < n; i++)
                {
                    isVisited[i] = false;
                }
                addedFlow = findFlow(0, ref destination, ref capacity, ref isVisited, int.MaxValue);
                flow += addedFlow;
            }
            Console.WriteLine(flow);
        }        
    }
}