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
                int n = int.Parse(sr.ReadLine());
                int[][] arr = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    arr[i]=sr.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                }

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    bool isPrinted = false;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if ( (arr[i][j] == 1) && (arr[j][i]!=1) ||
                                ((i==j) && (arr[i][j]==1)) ){
                                sw.Write("NO");
                                isPrinted = true;
                                break;
                            }
                        }                        
                    }
                    if (!isPrinted){
                        sw.Write("YES");
                    } 
                }

            }

        }
    }
}
