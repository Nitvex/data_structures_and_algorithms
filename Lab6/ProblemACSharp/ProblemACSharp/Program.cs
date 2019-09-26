using System;
namespace ProblemACSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string substring = Console.ReadLine();
            string str = Console.ReadLine();
            int i = str.IndexOf(substring);
            int index=0;
            int[] numbers = new int[10000];
            while (i != -1)
            {
                numbers[index]=i;
                index++;
                i = str.IndexOf(substring, i + 1);
            }
            Console.WriteLine(index);
            for (i = 0; i < index; i++)
            {
                Console.Write((numbers[i] + 1)+" ");
            }
        }
    }
}