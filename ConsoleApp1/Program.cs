using System;
using DataStructures;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkL = new LinkedList(new int[] { 33, 1, 2 });
            int first = linkL[0];
            Console.WriteLine(first);

        }
    }
}
