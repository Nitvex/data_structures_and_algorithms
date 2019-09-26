using System;
using System.Collections.Generic;
using System.IO;

namespace ProblemDCSharp { 
    class Program {     
        struct Edge {         
            public int to; 
            public int weight; 
            public Edge(int to, int weight) {             
                this.to = to;
                this.weight = weight;
            }
        }            

        static void DFS(int v, ref List<Edge>[] edges, ref bool[] isVisited) {         
            isVisited[v] = true;
            foreach (var e in edges[v]) {
                if (!isVisited[e.to]) { 
                    DFS(e.to, ref edges, ref isVisited);
                }
            }
        }

        static bool isReachable(int root, ref List<Edge>[] edges, int n) {                    
            bool[] isVisited = new bool[n + 1];
            for (int i = 1; i <= n; i++) {
                isVisited[i] = false;
            }
            DFS(root, ref edges, ref isVisited);
            for (int i = 1; i <= n; i++) {
                if (!isVisited[i]) { 
                    return false;
                }
            }
            return true;
        }        

        struct Components {         
            public int[] components;
            public int number_of_component;
            public Components(int amount,int n) {
                components = new int[amount + 1];
                number_of_component = n;
            }
        }

        static void straightDFS(int v, ref List<Edge>[] edges, ref bool[] isVisited, ref List<int> topSort) {
            isVisited[v] = true;
            foreach (var e in edges[v]) {             
                if (!isVisited[e.to]) { 
                    straightDFS(e.to, ref edges, ref isVisited, ref topSort);
                }
            }
            topSort.Add(v);
        }

        static void reversedDFS(int v, ref List<Edge>[] reversed, ref int[] components, int number_of_component) {         
            components[v] = number_of_component;
            foreach (var e in reversed[v]) { 
                if (components[e.to] == 0) {                 
                    reversedDFS(e.to, ref reversed, ref components, number_of_component);
                }
            }
        }

        static Components Condensation(List<Edge>[] edges, int n) {
            bool[] isVisited = new bool[n + 1];
            Components c = new Components(n + 1, 0);
            List<int> topSort = new List<int>();
            for (int i = 1; i <= n; i++) {
                isVisited[i] = false;
                c.components[i] = 0;
            }
            for (int i = 1; i <= n; i++) {
                if (!isVisited[i]) {
                    straightDFS(i, ref edges, ref isVisited, ref topSort);
                }
            }
            List<Edge>[] reversed = new List<Edge>[n + 1];
            for (int v = 1; v <= n; v++) {
                reversed[v] = new List<Edge>();
            }
            for (int v = 1; v <= n; v++) {
                foreach (var e in edges[v]) {
                    reversed[e.to].Add(new Edge(v, e.weight));
                }
            }
            topSort.Reverse();
            foreach (var v in topSort) {
                if (c.components[v] == 0) {
                    reversedDFS(v, ref reversed, ref c.components, ++c.number_of_component);
                }
            }
            return c;
        }

        static long Chinese(List<Edge>[] edges, int n, int root) { 
            long MSTWeight = 0;            
            if (!isReachable(root, ref edges, n)) {
                return -1;
            }
            //Wieghts of min edges, incoming to each vertex
            int[] minEdges = new int[n + 1];
            for (int v = 1; v <= n; v++) {
                minEdges[v] = int.MaxValue;
            }
            //Finding min weights
            for (int v = 1; v <= n; v++) {
                foreach (var edge in edges[v]) {
                    if (edge.weight < minEdges[edge.to]) {
                        minEdges[edge.to] = edge.weight;
                    }
                }
            }            
            for (int v = 1; v <= n; v++) {
                if (v != root) {
                    MSTWeight += minEdges[v];
                }
            }
            //descent to zero edges
            List<Edge>[] zeroEdges = new List<Edge>[n + 1];
            for (int i = 1; i <= n; i++) {
                zeroEdges[i] = new List<Edge>();
            }
            for (int v = 1; v <= n; v++) {
                foreach (var edge in edges[v]) {
                    if (edge.weight == minEdges[edge.to]) {
                        zeroEdges[v].Add(new Edge(edge.to, 0));
                    }
                }
            }           
            if (isReachable(root, ref zeroEdges, n)) {
                return MSTWeight;
            }
            //Making a condensation and adding new Edges(min weight) between components
            Components c = Condensation(zeroEdges, n);
            List<Edge>[] newEdges = new List<Edge>[c.number_of_component + 1];
            for (int i = 1; i <= c.number_of_component; i++) {
                newEdges[i] = new List<Edge>();
            }
            for (int v = 1; v <= n; v++) {
                foreach (var edge in edges[v]) { 
                    if (c.components[v] != c.components[edge.to]) {
                        newEdges[c.components[v]].Add(new Edge(c.components[edge.to], edge.weight - minEdges[edge.to]));
                    }
                }
            }
            //Finding MST for new graph
            MSTWeight += Chinese(newEdges, c.number_of_component, c.components[root]);
            return MSTWeight;
        }

        static void Main(string[] args) {
            //using (StreamReader sr = new StreamReader("chinese.in")) {
                //using (StreamWriter sw = new StreamWriter("chinese.in")) {
                    string[] nm = Console.ReadLine().Split(' ');
                    int n = int.Parse(nm[0]);
                    int m = int.Parse(nm[1]);
                    List<Edge>[] edges = new List<Edge>[n + 1];
                    for (int i = 1; i <= n; i++) {
                        edges[i] = new List<Edge>();
                    }
                    int from, to;
                    int weight;
                    string[] line;
                    for (int i = 0; i < m; i++) {
                        line = Console.ReadLine().Split(' ');
                        from = int.Parse(line[0]);
                        to = int.Parse(line[1]);
                        weight = int.Parse(line[2]);
                        edges[from].Add(new Edge(to, weight));
                    }
                    long mst = Chinese(edges, n, 1);
                    if (mst != -1) {
                        Console.WriteLine("YES");
                        Console.WriteLine(mst);
                    }
                    else {
                        Console.WriteLine("NO");
                    }
               // }
            //}
        }
    }
}