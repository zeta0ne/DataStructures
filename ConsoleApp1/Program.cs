using System;
using DataStructures;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList AA = new ArrayList(new int[0]);
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                AA.AddToEnd(rnd.Next(1, 10));
                Console.Write(AA[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(AA.GetIndexByValue(3));

            //ArrayList AA2 = new ArrayList(new int[0]);

            //for (int i = 0; i < 300; i++)
            //{
            //    AA2.AddToEnd(4);
            //}
            //AA2.RemoveNElementsFromBeginning(50);
            //Console.WriteLine(AA2.Length);

        }
    }
}
