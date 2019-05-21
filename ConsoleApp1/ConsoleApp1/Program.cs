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
            string input = File.ReadAllText("input.txt");
            
            bool reaction = true;

            var lengths = new List<int>();

            string oldinput = input;

            for( char c = 'a'; c <= 'z'; c++ )
            {
                input=input.Replace((""+c).ToLower(),"");
                input=input.Replace((""+c).ToUpper(),"");
                while (reaction == true)
                {
                    reaction = false;
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (input.Substring(i - 1, 1).Equals(input.Substring(i, 1), StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (input.Substring(i - 1, 1) != input.Substring(i, 1))
                            {
                                input = input.Remove(i - 1, 2);
                                reaction = true;
                            }
                        }
                    }
                }
                reaction = true;
                lengths.Add(input.Length);
                input = oldinput;
            }

            lengths.Sort();

            Console.WriteLine(input);
            Console.WriteLine();
            Console.WriteLine("answer: "+lengths[0]);
            Console.ReadKey();
        }
    }
}
