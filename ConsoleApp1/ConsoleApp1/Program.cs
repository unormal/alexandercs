using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Rect
    {
        public int id;
        public int x, y;
        public int w, h;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string input = File.ReadAllText("input.txt");

            int answer = 0;

            for (int i = 0; i<input.Length; i++)
            {
                if (input[i]=='(')
                {
                    answer+=1;
                } else if (input[i]==')')
                {
                    answer-=1;
                }
                if (answer==-1)
                {
                    answer=i+1;
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Answer: " + answer);
            Console.ReadKey();
        }
    }
}
