using System;
using System.Collections.Generic;

namespace ProblemDCSharp
{
    class Program
    {
        static int BFS(ref int[,] edgeFlow, ref int[,] capacity, ref int n)
        {
            int u, destination = n - 1;
            int[] predecessor = new int[n];
            for (u = 0; u < n; u++)
            {
                predecessor[u] = int.MaxValue;
            }
            predecessor[0] = 0;
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            while (q.Count > 0)
            {
                u = q.Dequeue();
                for (int v = 0; v < n; v++)
                {
                    if (predecessor[v] == int.MaxValue && capacity[u, v] - edgeFlow[u, v] > 0)
                    {
                        predecessor[v] = u;
                        if (v == destination)
                        {
                            int w = v;
                            int addedFlow = int.MaxValue;
                            for (u = predecessor[w]; v != 0; v = u, u = predecessor[u])
                            {
                                addedFlow = Math.Min(addedFlow, capacity[u, v] - edgeFlow[u, v]);
                            }
                            for (u = predecessor[w], v = w; v != 0; v = u, u = predecessor[u])
                            {
                                edgeFlow[u, v] += addedFlow;
                                edgeFlow[v, u] -= addedFlow;
                            }
                            return addedFlow;
                        }
                        q.Enqueue(v);
                    }
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            n += 2;
            int[,] edgeFlow = new int[n, n];
            int[,] capacity = new int[n, n];            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    edgeFlow[i, j] = 0;
                    capacity[i, j] = 0;
                }
            }
            int[,] edges= new int[m, 2];
            int[,] minCapacity = new int[n, n];
            int from, to;
            int start = 0, destination = n - 1; 
            int min, max;
            string[] Line;
            for (int i = 0; i < m; i++)
            {
                Line = Console.ReadLine().Split(' ');
                from = int.Parse(Line[0]);
                to = int.Parse(Line[1]);
                min = int.Parse(Line[2]);
                max = int.Parse(Line[3]);

                //Saving edges
                edges[i, 0] = from;
                edges[i, 1] = to;
                minCapacity[from, to] = min;

                //Build new graph adding 2 new vertices: start and destinationination
                capacity[start, to] += min;
                capacity[from, to] = max - min;
                capacity[from, destination] += min;
               
            }
            // Calculate max flow    
            while (BFS(ref edgeFlow, ref capacity, ref n) > 0);
            
            //If cicrculation property is not satisfied for at least 1 vertex, write "NO"
            for (int i = 1; i < n; i++)
            {
                if (edgeFlow[start, i] < capacity[start, i])
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
            for (int i = 0; i < m; i++)
            {
                from = edges[i, 0];
                to = edges[i, 1];
                Console.WriteLine(edgeFlow[from, to] + minCapacity[from, to]);
            }
        }        
    }
}