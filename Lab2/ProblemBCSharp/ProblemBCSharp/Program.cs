using System.Collections.Generic;
using System.IO;

namespace ProblemBCSharp{ 
    class Graph{
        int size;
        HashSet<int>[] edges;

        public Graph(int n){
            size = n;
            edges = new HashSet<int>[size];
            for (int i = 0; i < size; i++)
                edges[i] = new HashSet<int>();
        }

        public void addEdge(int from, int to){
            edges[from - 1].Add(to - 1);
        }
        
        public void hasCycle(StreamWriter output){           
            string[] color = new string[size];
            for (int i = 0; i < size; ++i)
                color[i] = "white";           
            int[] reversedCyclePath = new int[size];
            int current;
            Stack<int> s = new Stack<int>();
            int times = 0;
            for (int i = 0; i < size; ++i){
                if (color[i] =="white"){
                    s.Clear();
                    s.Push(i);
                    times = 0;
                    while (s.Count>0 || times==0){
                        times++;
                        current = s.Peek();
                        if (color[current] =="gray"){
                            color[current] = "black"; 
                            s.Pop();
                            continue;
                        }
                        color[current] = "gray";
                        foreach (int j in edges[current]){
                            if (color[j] =="white"){
                                reversedCyclePath[j] = current;
                                s.Push(j);
                            }
                            else if (color[j] =="gray"){ //Cycle is found
                                output.WriteLine("YES");
                                List<int> cyclePath = new List<int>();
                                /*Moving backwards*/
                                for (int v = current; v != j; v = reversedCyclePath[v]) cyclePath.Add(v); // Adding vertexes in reversed order
                                cyclePath.Add(j);  // Adding first vertex
                                cyclePath.Reverse(); //To make path from start to end
                                foreach (int vertex in cyclePath)
                                    output.Write((vertex + 1)+" ");
                                output.Flush();
                                return;
                            }
                        }
                    }                    
                }
            }
            output.WriteLine("NO");
            output.Flush();
        }

    }

    class Program{
        static void Main(string[] args){
            StreamReader input = new StreamReader("cycle.in");
            string[] nm = input.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; ++i){
                // Adding edges to Graph
                string[] edge = input.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from, to);
            }
            StreamWriter sw = new StreamWriter("cycle.out");
            g.hasCycle(sw);
            
        }
    }
}

