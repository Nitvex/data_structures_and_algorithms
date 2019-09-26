using System;
using System.IO;
using System.Linq;
namespace ProblemACSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {                
                int[] nm = sr.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                int n = nm[0];
                int m = nm[1];
                int[,] matrix = new int[n,n];
                for(int i=0; i < m; i++){
                    int[] edge = sr.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                    matrix[edge[0]-1, edge[1]-1] = 1;
                }        

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    for (int i = 0; i < n; i++){
                        for (int j = 0; j < n; j++){
                            if (matrix[i, j] != 1){
                                sw.Write(0+" ");
                            }
                            else{
                                sw.Write(matrix[i,j]+" ");
                            } 
                        }
                        sw.WriteLine();
                    }
                }

            }

        }
    }
}
