using System;
using System.Text;

namespace ProblemBCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string substring = Console.ReadLine();
            string sentinel = "$";
            string str = substring + sentinel + Console.ReadLine();            
            int prefix = 0;
            int[] prefixes = new int[str.Length];
            int index = 0;
            prefixes[0] = 0;
            int amount = 0;
            StringBuilder output = new StringBuilder(100000000);
            for (int i = 1; i < str.Length; i++)
            {
                while (str[i] != str[prefix] && prefix > 0)
                {
                    prefix = prefixes[prefix - 1];
                }
                if (str[i] == str[prefix])
                {
                    prefix++;
                }
                prefixes[i] = prefix;
                if (prefix == substring.Length)
                {
                    amount++;
                    index = (i - 2 * substring.Length)+1;
                    output.Append(index+" ");                    
                }
            }
            Console.WriteLine(amount);
            Console.Write(output);
        }
    }
}