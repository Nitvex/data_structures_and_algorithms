using System.IO;
using System.Linq;
namespace ProblemACSharp
{
    class Program
    {
        static int Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int[] nm = sr.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                    int n = nm[0];
                    int m = nm[1];                    
                    int[,] matrix = new int[n,n];
                    bool isPrinted = false;
                    for(int i=0; i < n; i++){
                        for (int j=0; j < n; j++){
                            matrix[i,j] = 0;
                        }
                    }
                    for (int i = 0; i < m; i++){
                        int[] arr = sr.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                        int begin = arr[0];
                        int end = arr[1];                        
                        if ((matrix[end - 1, begin - 1] == 1) ||
                            (matrix[begin-1,end-1]==1)){
                            sw.Write("YES");
                            isPrinted = true;
                            break;
                        }
                        matrix[begin - 1, end - 1] = 1;
                        matrix[end - 1, begin - 1] = 1;
                    }
                    if (!isPrinted){
                        sw.Write("NO");
                    }
                }
            }
            return 0;
        }
    }
}
