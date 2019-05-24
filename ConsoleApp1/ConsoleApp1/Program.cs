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
            string[] input = File.ReadAllLines("input.txt");
            
            var code = "";

            int x=0;
            int y=2;

            string[,] pad = new string[5,5];
            pad[0,0] = "X"; pad[1,0] = "X"; pad[2,0] = "1"; pad[3,0] = "X"; pad[4,0] = "X";
            pad[0,1] = "X"; pad[1,1] = "2"; pad[2,1] = "3"; pad[3,1] = "4"; pad[4,1] = "X";
            pad[0,2] = "5"; pad[1,2] = "6"; pad[2,2] = "7"; pad[3,2] = "8"; pad[4,2] = "9";
            pad[0,3] = "X"; pad[1,3] = "A"; pad[2,3] = "B"; pad[3,3] = "C"; pad[4,3] = "X";
            pad[0,4] = "X"; pad[1,4] = "X"; pad[2,4] = "D"; pad[3,4] = "X"; pad[4,4] = "X";


            foreach (string str in input)
            {
                foreach (char dir in str)
                {
                    if (dir=='L' && pad[Math.Max(0,x-1),y] != "X" && x!=0)
                    {
                        x-=1;
                    } else if (dir== 'R' && pad[Math.Min(4,x+1), y] != "X" && x!=4)
                    {
                        x+=1;
                    } else if (dir=='U' && pad[x, Math.Max(0,y-1)] != "X" && y!=0)
                    {
                        y-=1;
                    } else if (dir=='D' && pad[x, Math.Min(4,y+1)] != "X" && y!=4)
                    {
                        y+=1;
                    }
                }
                code = code + pad[x,y];
            }



            Console.WriteLine();
            Console.WriteLine("answer: "+code);
            Console.ReadKey();
        }
    }
}
