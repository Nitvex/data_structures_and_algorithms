using System.Collections.Generic;
using System.IO;
namespace ProblemCCSharp{ 
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
        }

        public void playGame(StreamWriter output, int startPoint){
            Color[] color = new Color[size];
            for (int i = 0; i < size; ++i) color[i] = Color.white;
            bool[] isWinningVertex = new bool[size];
            int current;
            bool winning_vertex;
            Stack<int> s = new Stack<int>();
            s.Push(startPoint);
            while (s.Count > 0){
                current = s.Peek();
                if (color[current] == Color.gray){                    
                    winning_vertex = false;
                    foreach (int v in edges[current]){
                        if (!isWinningVertex[v]){
                            winning_vertex = true;
                        }
                    }
                    isWinningVertex[current] = winning_vertex;
                    color[current] = Color.black; 
                    s.Pop();
                    continue;
                }
                else if (color[current] == Color.black){
                    s.Pop();
                    continue;
                }
                color[current] = Color.gray;
                foreach (int v in edges[current]){
                    if (color[v] == Color.white){
                        s.Push(v);
                    }
                }
            }
            output.WriteLine(isWinningVertex[startPoint] ? "First player wins" : "Second player wins");
            output.Flush();           
        }
    }

    class Program{
        static void Main(string[] args){
            StreamReader input = new StreamReader("game.in");
            string[] nms = input.ReadLine().Split(' ');
            int n = int.Parse(nms[0]);
            int m = int.Parse(nms[1]);
            int start = int.Parse(nms[2]);
            Graph g = new Graph(n);
            for (int i = 0; i < m; i++)
            {
                // Adding edges to Graph
                string[] edge = input.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                g.addEdge(from, to);
            }
            StreamWriter sw = new StreamWriter("game.out");
            g.playGame(sw,start-1);
        }
    }
}

