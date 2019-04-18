using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Data;

namespace ConsoleApp1
{
    

    class Program
    {
        static bool DiffersByOne( string a, string b)
        {
            int z = 0;
            if (b.Length != a.Length) {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) z++;
            }

            if (z==1) return true;

            return false;
        }

        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string[] input = File.ReadAllLines("input.txt");
            string x = "";


            for (int i = 0; i<input.Length; i++) { 
                foreach (string s in input)
                {
                    if (DiffersByOne(s, input[i]))
                    {
                        x = s.ToString() + "," + input[i].ToString();
                        Console.WriteLine(x);
                        break;
                    }
                }
            }

            string[] parts = x.Split(',');

            int y = 0;

            for (int i = 0; i<parts[0].Length; i++)
            {
                if (parts[0][i]!=parts[1][i])
                {
                    y = i;
                    break;
                }
            }

            string answer = parts[0].Remove(y,1);

            Console.WriteLine();
            Console.WriteLine("Answer: " + answer);
            Console.ReadKey();
        }
    }
}
