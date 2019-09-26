using System;
using System.Text;
namespace ProblemCCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int prefix = 0;
            int[] prefixFunction = new int[str.Length];
            prefixFunction[0] = 0;
            StringBuilder output = new StringBuilder("0 ", 10000000);
            for (int i = 1; i < str.Length; i++)
            {
                while (prefix > 0 && str[i] != str[prefix])
                {
                    prefix = prefixFunction[prefix - 1];
                }
                if (str[i] == str[prefix])
                {
                    prefix++;
                }
                prefixFunction[i] = prefix;
                output.Append(prefix+" ");
            }
            Console.WriteLine(output);
        }
    }
}