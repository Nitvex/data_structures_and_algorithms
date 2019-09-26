using System;
using System.Collections.Generic;

namespace ProblemCCSharp
{
    class Program
    {
        struct Edge
        {
            public int to;
            public int weight;

            public Edge(int to, int weight)
            {
                this.to = to;
                this.weight = weight;
            }
        }
        public class PriorityQueue
        {
            static int[] lengths;
            static int[] vertices;

            static int tempForLengths;
            static int tempForVertices;

            static int size;

            public PriorityQueue(int Count)
            {
                size = 0;
                lengths = new int[Count];
                vertices = new int[Count];
            }

            private void Swap(int child, int parent)
            {
                tempForLengths = lengths[child];
                tempForVertices = vertices[child];
                lengths[child] = lengths[parent];
                vertices[child] = vertices[parent];
                lengths[parent] = tempForLengths;
                vertices[parent] = tempForVertices;
            }

            public void Add(int length, int vertex)
            {
                lengths[size] = length;
                vertices[size] = vertex;
                int child = size++; 
                int parent;
                while (child > 0)
                {
                    parent = (child - 1) / 2;
                    if (lengths[child] >= lengths[parent])
                    {
                        break;
                    }
                    Swap(child, parent);
                    child = parent;
                }
                return;
            }

            public int ExtractMin()
            {
                int min = vertices[0]; 
                Swap(0, --size);
                int parent = 0;
                int leftChild, rightChild;
                int smallest;
                while (true)
                {
                    leftChild = parent * 2 + 1; 
                    smallest = leftChild;
                    if (leftChild >= size)
                    {
                        break;
                    }
                    rightChild = leftChild + 1;
                    //finding the smallest child
                    if (rightChild < size && lengths[rightChild] < lengths[leftChild])
                    {
                        smallest = rightChild; 
                    }
                    if (lengths[parent] <= lengths[smallest])
                    {
                        break; 
                    }
                    Swap(smallest, parent); 
                    parent = smallest;
                }
                return min;
            }

            public void DecreaseKey(int length, int vertex)
            {
                int min = 0, max = size, i;
                while (min < max)
                {
                    i = min + (max - min) / 2;
                    if (vertices[i] == vertex)
                    {
                        if (length < lengths[i])
                        {
                            lengths[i] = length;
                            int child = i;
                            int parent;
                            while (child > 0)
                            {
                                parent = (child - 1) / 2;
                                if (lengths[child] >= lengths[parent])
                                { 
                                    break;
                                }
                                Swap(child, parent);
                                child = parent;
                            }
                            return;
                        }
                    }
                    else if (vertices[i] < vertex)
                    {
                        max = i;
                    }
                    else
                    {
                        min = i + 1;
                    }
                }
                Add(length, vertex);
            }

            public int Size()
            {
                return size;
            }
        }

        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            List<Edge>[] edges = new List<Edge>[n];
            for (int i = 0; i < n; i++)
            {
                edges[i] = new List<Edge>();
            }
            int from, to, w;
            string[] Line;
            for (int i = 0; i < m; i++)
            {
                Line = Console.ReadLine().Split(' ');
                from = int.Parse(Line[0]) - 1;
                to = int.Parse(Line[1]) - 1;
                w = int.Parse(Line[2]);
                Edge edge = new Edge(to, w);
                edges[from].Add(new Edge(to, w));
                edges[to].Add(new Edge(from, w));
            }
            
            int[] lengths = new int[n];
            for (int i = 0; i < n; i++)
            {
                lengths[i] = int.MaxValue;
            }
            lengths[0] = 0;
            PriorityQueue Q = new PriorityQueue(m);
            Q.Add(0, 0);
            int length;
            while (Q.Size() > 0)
            {
                from = Q.ExtractMin();
                for (int i = 0; i < edges[from].Count; i++)
                {
                    to = edges[from][i].to;
                    w = edges[from][i].weight;
                    length = lengths[from] + w;
                    if (lengths[to] > length)
                    {
                        lengths[to] = length;
                        Q.DecreaseKey(length, to);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(lengths[i] + " ");
            }
        }
    }    
}