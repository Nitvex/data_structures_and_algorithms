using System;
using System.IO;

namespace ProblemACSharp { 
    class Program {
        /*Trying to find shorter way*/
        static void relax(ref bool[] isVisited,ref long[,] matrix, ref long[] weights,long vertex, long n)  {
            for (long i = 0; i < n; i++) {
                if (weights[vertex] + matrix[vertex, i] < weights[i] &&
                    weights[vertex] != long.MaxValue &&
                    matrix[vertex, i] != -1 &&                    
                    !isVisited[i]) {
                    weights[i] = weights[vertex] + matrix[vertex, i];
                }
            }
        }

        static void Main(string[] args) {
            //using (StreamReader sr = new StreamReader("pathmgep.in"))
            //{
                //using (StreamWriter sw = new StreamWriter("pathmgep.out"))
                //{
                    string[] nsf = Console.ReadLine().Split(' ');
                    long n = long.Parse(nsf[0]);
                    long s = long.Parse(nsf[1]) - 1;
                    long f = long.Parse(nsf[2]) - 1;
                    long[,] matrix = new long[n, n];
                    string[] Line;
                    for (long i = 0; i < n; i++)
                    {
                        Line = Console.ReadLine().Split(' ');
                        for (long j = 0; j < n; j++)
                        {
                            matrix[i, j] = long.Parse(Line[j]);
                        }
                    }
                    long[] weights = new long[n];
                    bool[] isVisited = new bool[n];
                    for (long i = 0; i < n; i++)
                    {
                        weights[i] = long.MaxValue;
                        isVisited[i] = false;
                    }
                    weights[s] = 0;
                    long vertex = 0;
                    long min;
                    for (long k = 0; k < n; k++)
                    {
                        min = long.MaxValue;
                        for (long i = 0; i < n; i++)
                        {
                            if (!isVisited[i] && weights[i] < min)
                            {
                                min = weights[i];
                                vertex = i;
                            }
                        }
                        isVisited[vertex] = true;
                        relax(ref isVisited, ref matrix, ref weights, vertex, n);
                    }
                    if (weights[f] != long.MaxValue)
                    {
                        Console.WriteLine(weights[f]);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
               // }
            //}
        }
    }
}