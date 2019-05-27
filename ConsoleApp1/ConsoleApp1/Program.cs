using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string oldinput = File.ReadAllText("input.txt");
            
            var input = new List<int>();

            foreach (var item in oldinput)
            {
                input.Add(int.Parse(""+item));
            }

            int sum = 0;
            int half = input.Count/2;
            int next;

            for (int i=0;i<input.Count;i++)
            {
                next = input[(i+half)%input.Count];
                if (input[i]==next)
                {
                    sum+=input[i];
                }
            }

            Console.WriteLine();
            Console.WriteLine("answer: "+sum);
            Console.ReadKey();
        }
    }
}
