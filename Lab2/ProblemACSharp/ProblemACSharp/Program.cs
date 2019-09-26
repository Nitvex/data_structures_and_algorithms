using System.Collections.Generic;
using System.IO;

namespace ProblemACSharp{
    class Graph{
        int size;
        HashSet<int>[] edges;

        public Graph(int n){
            size = n;
            edges = new HashSet<int>[size];
            for (int i = 0; i < size; ++i)
                edges[i] = new HashSet<int>();
        }

        public void addEdge(int from, int to){
            edges[from - 1].Add(to - 1);
        } 

        public void topSort(StreamWriter output){          
            string[] color = new string[size];
            for (int i = 0; i < size; ++i) color[i] = "white";
            int current;
            Stack<int> s = new Stack<int>();
            List<int> topsort = new List<int>();
            for (int i = 0; i < size; ++i){
                if (color[i] == "white"){
                    s.Push(i);
                    while (s.Count > 0){
                        current = s.Peek();
                        if (color[current] == "gray"){
                            color[current] = "black"; 
                            topsort.Insert(0, s.Pop());
                            continue;
                        }
                        else if (color[current] == "black"){
                            s.Pop();
                            continue;
                        }
                        color[current] = "gray";
                        foreach (int v in edges[current]){
                            if (color[v] == "white"){
                                s.Push(v);
                            }
                            else if (color[v] == "gray"){   //We found a cycle                          
                                output.WriteLine("-1");
                                output.Flush();
                                return;
                            }
                        }
                    }
                }
            }
            foreach (int v in topsort) output.Write((v + 1)+" ");
            output.Flush();
        }
    }

    class Program{
        static void Main(string[] args){
            StreamReader output = new StreamReader("topsort.in");
            string[] nm = output.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; ++i){
                // Adding edges to Graph
                string[] edge = output.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from,to);
            }            
            g.topSort(new StreamWriter("topsort.out"));
        }
    }
}