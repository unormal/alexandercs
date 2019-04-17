using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Data;

namespace ConsoleApp1
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            var xl = new HashSet<int>();

            bool br = false;

            int x = 0;
            string[] str = File.ReadAllLines("input.txt");
            int i = 0;
            while (true)
            {
                //Console.WriteLine(str[i]);
                
                if (str[i].Substring(0, 1)=="-")
                {
                    x -= int.Parse(str[i].Substring(1));
                } else
                {
                    x += int.Parse(str[i].Substring(1));
                }

                
                if (xl.Contains(x))
                {
                     break;
                }

                xl.Add(x);

                if (i==str.Length-1) {
                    i=0;
                } else
                {
                    i++;
                }
            }
            Console.WriteLine();
            Console.Write("Answer is: ");
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
