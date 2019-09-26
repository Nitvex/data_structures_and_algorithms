using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ProblemFCSharp{
    struct Vertex{
        public int n, m;
        public Vertex(int n, int m){
            this.n = n;
            this.m = m;
        }
    }
    class Program{
        static void Main(string[] args){            
            using (StreamReader sr = new StreamReader("input.txt")){
                using (StreamWriter sw = new StreamWriter("output.txt")){
                    string[] nm = sr.ReadLine().Split(' ');
                    int n = int.Parse(nm[0]);
                    int m = int.Parse(nm[1]);
                    char[,] labyrinth = new char[n, m];
                    Vertex Start = new Vertex();
                    for (int i = 0; i < n; ++i){
                        string tmp = sr.ReadLine();
                        for (int j = 0; j < m; ++j)
                        {
                            if (tmp[j] == 'S'){                                
                                Start.n = i;
                                Start.m = j;
                            }
                            labyrinth[i, j] = tmp[j];
                        }
                    }
                    Queue<Vertex> Q = new Queue<Vertex>();
                    Q.Enqueue(Start);
                    while (Q.Count > 0){
                        Vertex v = Q.Dequeue();
                        if (v.n > 0){
                            if (labyrinth[v.n - 1, v.m] == '.'){
                                labyrinth[v.n - 1, v.m] = 'U';
                                Q.Enqueue(new Vertex((int)(v.n - 1), v.m));
                            }
                            else if (labyrinth[v.n - 1, v.m] == 'T'){                                
                                Stack<char> Path = new Stack<char>();
                                Path.Push('U');
                                while (labyrinth[v.n, v.m] != 'S'){                                    
                                    Path.Push(labyrinth[v.n, v.m]);
                                    switch (labyrinth[v.n, v.m]){
                                        case 'U':
                                                v.n += 1;
                                                break;
                                        case 'D':
                                                v.n -= 1;
                                                break;
                                        case 'L':
                                                v.m += 1;
                                                break;
                                        case 'R':
                                                v.m -= 1;
                                                break;
                                    }
                                }
                                sw.WriteLine(Path.Count);                               
                                while (Path.Count > 0){
                                    sw.Write(Path.Pop());
                                }
                                return;
                            }
                        }
                        if (v.n < n - 1){
                            if (labyrinth[v.n + 1, v.m] == '.'){
                                labyrinth[v.n + 1, v.m] = 'D';
                                Q.Enqueue(new Vertex((int)(v.n + 1), v.m));
                            }
                            else if (labyrinth[v.n + 1, v.m] == 'T'){                                
                                Stack<char> Path = new Stack<char>();
                                Path.Push('D');
                                while (labyrinth[v.n, v.m] != 'S'){                                    
                                    Path.Push(labyrinth[v.n, v.m]);
                                    switch (labyrinth[v.n, v.m]){
                                        case 'U':
                                                v.n += 1;
                                                break;
                                        case 'D':
                                                v.n -= 1;
                                                break;
                                        case 'L':
                                                v.m += 1;
                                                break;
                                        case 'R':
                                                v.m -= 1;
                                                break;
                                    }
                                }
                                sw.WriteLine(Path.Count);                                
                                while (Path.Count > 0){
                                    sw.Write(Path.Pop());
                                }
                                return;
                            }
                        }
                        if (v.m > 0){
                            if (labyrinth[v.n, v.m - 1] == '.'){
                                labyrinth[v.n, v.m - 1] = 'L';
                                Q.Enqueue(new Vertex(v.n, (int)(v.m - 1)));
                            }
                            else if (labyrinth[v.n, v.m - 1] == 'T'){                                
                                Stack<char> Path = new Stack<char>();
                                Path.Push('L');
                                while (labyrinth[v.n, v.m] != 'S'){
                                    Path.Push(labyrinth[v.n, v.m]);                                   
                                    switch (labyrinth[v.n, v.m]){
                                        case 'U':
                                                v.n += 1;
                                                break;
                                        case 'D':
                                                v.n -= 1;
                                                break;
                                        case 'L':
                                                v.m += 1;
                                                break;
                                        case 'R':
                                                v.m -= 1;
                                                break;
                                    }
                                }
                                sw.WriteLine(Path.Count);                                
                                while (Path.Count > 0){
                                    sw.Write(Path.Pop());
                                }
                                return;
                            }
                        }
                        if (v.m < m - 1){
                            if (labyrinth[v.n, v.m + 1] == '.'){
                                labyrinth[v.n, v.m + 1] = 'R';
                                Q.Enqueue(new Vertex(v.n, (int)(v.m + 1)));
                            }
                            else if (labyrinth[v.n, v.m + 1] == 'T'){                                
                                Stack<char> Path = new Stack<char>();
                                Path.Push('R');
                                while (labyrinth[v.n, v.m] != 'S'){                                    
                                    Path.Push(labyrinth[v.n,v.m]);
                                    switch (labyrinth[v.n, v.m]){
                                        case 'U':
                                                v.n += 1;
                                                break;
                                        case 'D':
                                                v.n -= 1;
                                                break;
                                        case 'L':
                                                v.m += 1;
                                                break;
                                        case 'R':
                                                v.m -= 1;
                                                break;
                                    }
                                }
                                sw.WriteLine(Path.Count);                                
                                while (Path.Count > 0){
                                    sw.Write(Path.Pop());
                                }
                                return;
                            }
                        }
                    }
                    sw.WriteLine("-1");                    
                }
            }
        }
    }
}