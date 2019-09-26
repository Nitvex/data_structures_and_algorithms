using System.Collections.Generic;
using System.IO;
namespace ProblemCCSharp {
    class Graph {
       public int size;
       public HashSet<int>[] Edges;       
        enum Color{
            white,
            gray,
            black
        }
        public Graph(int n) {
            size = n;
            Edges = new HashSet<int>[size];           
            for (int i = 0; i < size; i++) {
                Edges[i] = new HashSet<int>();                
            }
        }

        public void addEdge(int from, int to) {
            Edges[from - 1].Add(to - 1);
            Edges[to - 1].Add(from-1);
        }
    }

    class Program {
        static void Main(string[] args) {
            StreamReader input = new StreamReader("input.txt");
            string[] nms = input.ReadLine().Split(' ');
            int n = int.Parse(nms[0]);
            int m = int.Parse(nms[1]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; i++) {
                // Adding edges to Graph
                string[] edge = input.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from, to);
            }
            using (StreamWriter sw=new StreamWriter("output.txt")){
                for (int i = 0; i < g.Edges.Length; i++) {
                    sw.Write(g.Edges[i].Count+" ");
                }
            } 
        }  
    }
}

