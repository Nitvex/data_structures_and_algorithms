using System;
using System.Collections.Generic;
using System.IO;

namespace ProblemCCSharp { 
    class Program {
        class Edge {        
            public int from;
            public int to;
            public int weight;
            public Edge(int from, int to, int weight) { 
            
                this.from = from;
                this.to = to;
                this.weight = weight;
            }

            public static int Compare(Edge a, Edge b) { 
            
                return a.weight.CompareTo(b.weight);
            }

            public static void MergeComponents(ref int[] array, int firstComponent, int secondComponent) {             
                for (int i = 0; i < array.Length; i++) {                 
                    if (array[i] == firstComponent) {                     
                        array[i] = secondComponent;
                    }
                }
            }
        }

        static void Main(string[] args) {         
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < m; i++) {             
                string[] edge = Console.ReadLine().Split(' ');
                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);
                int weight = int.Parse(edge[2]);
                edges.Add(new Edge(from,to,weight));
            }
            edges.Sort(new Comparison<Edge>(Edge.Compare));
            int[] components = new int[n + 1];
            /*
             * components[i]==0 means is i vertex is separated (not in any component)              
             **/
            for (int i = 1; i <= n; i++) {
                components[i] = 0;
            }
            int component = 0; 
            int MSTWeight = 0;
            foreach (var edge in edges) {             
                if (components[edge.from] == 0) {                 
                    MSTWeight += edge.weight;                    
                    if (components[edge.to] == 0) {
                        ++component;
                        components[edge.from] = component;
                        components[edge.to] = component;
                    }
                    else {                    
                        components[edge.from] = components[edge.to];
                    }
                }
                else {                 
                    if (components[edge.to] == 0) {                   
                        MSTWeight += edge.weight;
                        components[edge.to] = components[edge.from];
                    }
                    else { // vetices are in different components and there is an edge to match them                   
                        if (components[edge.from] != components[edge.to]) { //cycle otherwise                       
                            MSTWeight += edge.weight;
                            Edge.MergeComponents(ref components, components[edge.from], components[edge.to]);
                        }
                    }
                }
            }
            Console.WriteLine(MSTWeight);
        }
    }
}