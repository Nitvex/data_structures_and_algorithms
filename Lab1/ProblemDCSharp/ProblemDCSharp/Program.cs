using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace problemeCsharp
{
    class Program
    {
        static public int[] BFS(List<int>[] vu, int count, int source,int[] components,int current_component)
        {
            components[source] = current_component;
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(source);
            while (Q.Count > 0)
            {
                int current = Q.Dequeue();
                for (int i = 0; i < vu[current].Count; i++) /* number of children */
                {
                    if (components[vu[current][i]] == 0)
                    {
                        components[vu[current][i]] = current_component;
                        Q.Enqueue(vu[current][i]);
                    }
                }
            }
            return components;
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("components.in"))
            {
                using (StreamWriter sw = new StreamWriter("components.out"))
                {

                    int[] nm = sr.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                    int n = nm[0];
                    int m = nm[1];
                    List<int>[] arr = new List<int>[n];
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = new List<int>();
                    }
                    for (int i = 0; i < m; i++)
                    {
                        int[] arr1 = sr.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                        if (!arr[arr1[0] - 1].Contains(arr1[1] - 1))
                        {
                            arr[arr1[0] - 1].Add(arr1[1] - 1);
                            arr[arr1[1] - 1].Add(arr1[0] - 1);                           
                        }
                    }



                    int[] components = new int[n];
                    int current_component = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (components[i] == 0)
                        {
                            current_component++;
                            components = BFS(arr, n, i, components, current_component);
                        }

                    }
                    sw.WriteLine(current_component);
                    for (int i = 0; i < n; i++)
                    {
                        sw.Write(components[i] + " ");
                    }
                }
            }
        }
    }
}
