using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Data;

namespace ConsoleApp1
{
    

    class Program
    {
        static bool CheckForNOfAnyLetter( string str, int n )
        {
            var charcount = new Dictionary<char,int>();
            for (int i = 0; i<str.Length; i++)
            {
                if (!charcount.ContainsKey(str[i])) {
                    charcount[str[i]] = 1;
                } else
                {
                    charcount[str[i]] += 1;             
                }
            }

            foreach( var value in charcount.Values )
            {
                if (value==n) {
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string[] input = File.ReadAllLines("input.txt");



            int answer = x1 * x2;
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
