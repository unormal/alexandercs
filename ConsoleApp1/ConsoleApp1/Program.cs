using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Triangle
    {
        public int a;
        public int b;
        public int c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool isPossible()
        {
            if ((a + b) > c && (b + c) > a && (c + a) > b)
            {
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            
            var trianglepoints = new Dictionary<int,List<int>>();


            for (int i = 0;i<input.Length;i++) {
                trianglepoints.Add(i,input[i].Trim().Replace("    ", " ").Replace("   ", " ").Replace("  "," ").Split(' ').Select( e => int.Parse(e)).ToList());
            }
            var triangles = new List<Triangle>();

            foreach (var tri in trianglepoints.Values)
            {
                triangles.Add(new Triangle(tri[0],tri[1],tri[2]));
            }

            int sum=0;
            foreach (var tri in triangles)
            {
                if (tri.isPossible())
                {
                    sum+=1;
                }
            }

            Console.WriteLine();
            Console.WriteLine("answer: "+sum);
            Console.ReadKey();
        }
    }
}
