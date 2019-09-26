using System.Collections.Generic;
using System.IO;

namespace ProblemCCSharp { 
    class Graph{
        int size;
        HashSet<int>[] edges;
        enum Color{
            white,
            gray,
            black
        }
        public Graph(int n){
            size = n;
            edges = new HashSet<int>[size];
            for (int i = 0; i < size; i++)
                edges[i] = new HashSet<int>();
        }

        public void addEdge(int from, int to){
            edges[from - 1].Add(to - 1);
            edges[to - 1].Add(from - 1);
        }

        public void isBipartite(StreamWriter output){           
            Color[] color = new Color[size];           
            bool[] isEven = new bool[size];
            int current;
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < size; i++){
                isEven[i] = false;
                if (color[i] == Color.white){
                    s.Clear();
                    s.Push(i);
                    while (s.Count > 0){
                        current = s.Peek();
                        if (color[current] == Color.gray){
                            color[current] = Color.black; 
                            s.Pop();
                            continue;
                        }
                        else if (color[current] == Color.black){
                            s.Pop();
                            continue;
                        }
                        color[current] = Color.gray;
                        foreach (int j in edges[current]){ 
                            if (color[j] == Color.white){
                                isEven[j] = !isEven[current];
                                s.Push(j);
                            }
                            // Cycle is found and has an odd length
                            else if (color[j] == Color.gray && isEven[j] == isEven[current]){
                                output.WriteLine("NO");
                                output.Flush();
                                return;
                            }
                        }
                    }
                }
            }
            output.WriteLine("YES");
            output.Flush();
        }
    }

    class Program {
        static void Main(string[] args){
            StreamReader input = new StreamReader("bipartite.in");
            string[] nm = input.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; i++){
                // Adding edges to Graph
                string[] edge = input.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from, to);
            }
            StreamWriter sw = new StreamWriter("bipartite.out");
            g.isBipartite(sw);
        }
    }
}

