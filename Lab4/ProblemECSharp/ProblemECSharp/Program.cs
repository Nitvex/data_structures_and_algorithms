using System;
using System.Collections.Generic;

namespace problemECSharp
{
    class Program
    {
        static int infinity = 1000000000;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string[] Line;            
            for (int i = 0; i < n; i++)
            {
                Line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Line[j]);
                }
            }            
            int[] lengths = new int[n];
            for (int i = 0; i < n; i++)
            {
                lengths[i] = infinity;
            }
            lengths[0] = 0;
            int[] predecessor = new int[n];
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (lengths[j] > lengths[i] + matrix[i, j])
                        {
                            lengths[j] = lengths[i] + matrix[i, j];
                            predecessor[j] = i;
                        }
                    }
                }
            }
            
            int firstVertexInCycle = int.MaxValue;
            bool hasCycle = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    /*Cycle is found*/
                    if (lengths[j] > lengths[i] + matrix[i, j])
                    {
                        firstVertexInCycle = j;
                        hasCycle = true;
                        break;
                    }
                }
            }
            
            if (hasCycle)
            {
                List<int> cycle = new List<int>();                
                for (int i = 0; i < n - 1; i++)
                {
                    firstVertexInCycle = predecessor[firstVertexInCycle];
                }
                cycle.Add(firstVertexInCycle);
                for (int v = predecessor[firstVertexInCycle]; v != firstVertexInCycle; v = predecessor[v])
                {
                    cycle.Insert(0,v);
                }
                cycle.Insert(0,firstVertexInCycle);                
                Console.WriteLine("YES");
                Console.WriteLine(cycle.Count);
                foreach (var vertex in cycle)
                {
                    Console.Write((vertex + 1) + " ");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}