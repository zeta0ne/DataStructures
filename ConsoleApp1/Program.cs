using System;
using DataStructures;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList AA = new ArrayList(new int[0]);

            for (int i = 0; i < 300; i++)
            {
                AA.AddToEnd(4);
            }
            AA.RemoveNElementsFromBeginning(50);
            Console.Write(AA.Length);
           
        }
    }
}
