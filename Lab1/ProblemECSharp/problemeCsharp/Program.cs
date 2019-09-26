using System.Collections.Generic;
using System.Linq;
//using System.IO;
using System;

namespace problemeCsharp
{
    class Program
    {
        static public int[] BFS(List<int>[] vu,int count,int source)
        {
            int[] d = new int[count];
            for (int i=0; i < count; i++){
                d[i] = -1; 
            }
            d[source] = 0;
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(source);
            while (Q.Count>0) {
                int current = Q.Dequeue();
                for (int i = 0; i < vu[current].Count; i++) {                    
                    if ((d[vu[current][i]] == -1)||
                        (d[vu[current][i]] > d[current]+1)){
                        d[vu[current][i]] = d[current] + 1;
                        Q.Enqueue(vu[current][i]);
                    }
                }
            }
            return d;
        }
        static void Main(string[] args)
        {
            //FileStream fileIn = new FileStream("pathbge1.in", FileMode.Open, FileAccess.Read);
            //FileStream fileOut = new FileStream("pathbge1.out", FileMode.Create, FileAccess.Write);
           /* using (FileStream fileIn = new FileStream("pathbge1.in", FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileOut = new FileStream("pathbge1.out", FileMode.Create, FileAccess.Write))
                {*/
                    int[] nm = Console.ReadLine().Trim().Split(' ').Select(x=>int.Parse(x)).ToArray();
                    int n = nm[0];
                    int m = nm[1];
                    List<int>[] arr = new List<int>[n];                    
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = new List<int>();    
                    }
                    for (int i = 0; i < m; i++)
                    {
                       int[] arr1 = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                       if (!arr[arr1[0] - 1].Contains(arr1[1]- 1)){
                            arr[arr1[0] - 1].Add(arr1[1] - 1);
                            arr[arr1[1] - 1].Add(arr1[0] - 1);
                       }                      
                    }
                    int[] lengths = new int[n];
                    lengths=BFS(arr,n,0);
                    for(int i=0; i<lengths.Length-1;i++){
                            Console.Write(lengths[i]+" ");
                    }
                   Console.Write(lengths[lengths.Length-1]);
                }
           /* }

        }*/
    }
}
