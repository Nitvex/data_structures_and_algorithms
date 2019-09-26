using System.Collections.Generic;
using System.IO;
namespace ProblemCCSharp{ 
    class Graph{
        int size;
        HashSet<int>[] directEdges;
        HashSet<int>[] reversedEdges;
        enum Color{
            white,
            gray,
            black
        }
        public Graph(int n){
            size = n;
            directEdges = new HashSet<int>[size];
            reversedEdges = new HashSet<int>[size];
            for (int i = 0; i < size; i++){
                directEdges[i] = new HashSet<int>();
                reversedEdges[i] = new HashSet<int>();
            }
        }

        public void addEdge(int from, int to){
            directEdges[from - 1].Add(to - 1);
            reversedEdges[to - 1].Add(from - 1);
        }

        public void directDFS(int v, ref bool[] color, ref List<int> topsort){
            color[v] = true;
            foreach (int vertex in directEdges[v]){
                if (!color[vertex]){
                    directDFS(vertex, ref color, ref topsort);
                }
            }
            topsort.Add(v);
        }

        public void reversedDFS(int v, ref int[] components, int amount){
            components[v] = amount;
            foreach (int vertex in reversedEdges[v]){
                if (components[vertex] == 0){
                    reversedDFS(vertex, ref components, amount);
                }
            }
        }

        public void Condensation(StreamWriter output){
            bool[] color = new bool[size];
            int[] components = new int[size];
            List<int> topsort = new List<int>();
            for (int i = 0; i < size; i++){
                color[i] = false;
                components[i] = 0;
            }
            for (int i = 0; i < size; ++i){
                if (!color[i]){ //vertex is not visited
                    directDFS(i, ref color, ref topsort);
                }
            }
            int amount = 0;
            topsort.Reverse();
            foreach (int v in topsort){
                if (components[v] == 0){
                    reversedDFS(v, ref components, ++amount);
                }
            }
            output.WriteLine(amount);
            for (int i = 0; i < size; ++i){
                output.Write(components[i]+" ");
            }
            output.WriteLine();
            output.Flush();
        }
    }

    class Program{
        static void Main(string[] args){
            // Making new Thread to increase max stack size. Getting time limit exceeded otherwise.
            /*According to MSDN
             * public Thread(
	         *      ThreadStart start,
	         *      int maxStackSize
             *   ) 
             **/
            System.Threading.Thread condensation = new System.Threading.Thread(new System.Threading.ThreadStart(Condensation),11111111);
            condensation.Start();
        }
        static void Condensation(){
            StreamReader input = new StreamReader("cond.in");
            string[] nms = input.ReadLine().Split(' ');
            int n = int.Parse(nms[0]);
            int m = int.Parse(nms[1]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; i++)
            {
                // Adding edges to Graph
                string[] edge = input.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from, to);
            }
            StreamWriter sw = new StreamWriter("cond.out");
            g.Condensation(sw);
        }
    }
}

