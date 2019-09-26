using System.IO;
namespace ProblemECSharp { 
    class Program{
        static void Main(string[] args){
            using (StreamReader sr = new StreamReader("hamiltonian.in")) {
                using (StreamWriter sw = new StreamWriter(("hamiltonian.out"))) {                    
                    string[] nm = sr.ReadLine().Split(' ');
                    int n = int.Parse(nm[0]);
                    int m = int.Parse(nm[1]);
                    int[] edgesIn = new int[n];
                    int[] edgesOut = new int[n];
                    for (int i = 0; i < n; i++){
                        edgesIn[i] = 0;
                        edgesOut[i] = 0;
                    }
                    int from, to;
                    string[] Line;
                    for (int i = 0; i < m; i++){
                        Line = sr.ReadLine().Split(' ');
                        from = int.Parse(Line[0]) - 1;
                        to = int.Parse(Line[1]) - 1;
                        edgesOut[from]++;
                        edgesIn[to]++;
                    }
                    int vertexes_wo_edgesIn = 0, vertexes_wo_edgesOut = 0;
                    for (int i = 0; i < n; i++) {
                        if (edgesIn[i] == 0)
                        {
                            if (vertexes_wo_edgesIn > 0)
                            {
                                sw.Write("NO");                                
                                return;
                            }
                            vertexes_wo_edgesIn++;
                        }
                        if (edgesOut[i] == 0){
                            if (vertexes_wo_edgesOut > 0){
                                sw.Write("NO");
                                return;
                            }
                            vertexes_wo_edgesOut++;
                        }
                    }
                    sw.Write("YES");
                }
            }
        }
    }
}