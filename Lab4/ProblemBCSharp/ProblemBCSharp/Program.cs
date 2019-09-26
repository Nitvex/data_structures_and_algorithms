using System;

namespace ProblemBCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] nm = Console.ReadLine().Split(' ');
            long n = long.Parse(nm[0]);
            long m = long.Parse(nm[1]);            
            long[,] lengths = new long[n, n];
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < n; j++)
                {  
                    
                    lengths[i, j] = int.MaxValue;
                }
            }
            long from, to,weight;            
            string[] Line;
            for (long i = 0; i < m; i++)
            {
                Line = Console.ReadLine().Split(' ');
                from = long.Parse(Line[0]) - 1;
                to = long.Parse(Line[1]) - 1;
                weight = long.Parse(Line[2]);
                lengths[from, to] = weight;
            }
            for (long i = 0; i < n; i++)
            {
                lengths[i, i] = 0;
            }
            for (long k = 0; k < n; k++)
            {
                for (long i = 0; i < n; i++)
                {
                    for (long j = 0; j < n; j++)
                    {
                        if (lengths[i, j] > lengths[i, k] + lengths[k, j]) { 
                        lengths[i, j] = lengths[i, k] + lengths[k, j];
                        }
                    }
                }
            }            
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < n; j++)
                {
                    Console.Write(lengths[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
