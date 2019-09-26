using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace problemeCsharp
{
    class Program
    {
        static public int[] BFS(List<int>[] vu, int count, int source)
        {
            int[] d = new int[count];
            for (int i = 0; i < count; i++)
            {
                d[i] = -1;
            }
            d[source] = 0;
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(source);
            while (Q.Count > 0)
            {
                int current = Q.Dequeue();
                for (int i = 0; i < vu[current].Count; i++)
                {
                    if ((d[vu[current][i]] == -1) ||
                        (d[vu[current][i]] > d[current] + 1))
                    {
                        d[vu[current][i]] = d[current] + 1;
                        Q.Enqueue(vu[current][i]);
                    }
                }
            }
            return d;
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int[] nm = sr.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                    int n = nm[0];
                    int m = nm[1];
                    List<int>[] arr = new List<int>[n];                   
                    int[,] labyrinth = new int[100,100];
                    int SourceN, SourceM, TargetN, TargetM;
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = new List<int>();
                        string s = sr.ReadLine().Trim();                        
                        for (int j = 0; j < m; j++)
                        {
                            switch (s[j])
                            {
                                case '.':
                                    labyrinth[i,j] = 1;
                                    break;
                                case '#':
                                    labyrinth[i,j] = int.MaxValue;
                                    break;
                                case 'S':
                                    labyrinth[i,j] = 1;
                                    SourceN = i;
                                    SourceM = j;
                                    break;
                                case 'T':
                                    labyrinth[i,j] = -1;
                                    TargetN = i;
                                    TargetM = j;
                                    break;
                            }
                        }
                    }
                    for(int i=0; i < n; i++){
                        for (int j = 0; j < m; j++){
                            sw.Write(labyrinth[i,j]+" ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }        
    }
}
