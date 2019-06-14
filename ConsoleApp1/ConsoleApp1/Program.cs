using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var points = new List<Point>();

            foreach (string coord in input)
            {
                var point = coord.Replace(" ","").Split(',');
                points.Add(new Point(int.Parse(point[0]),int.Parse(point[1])));
            }

            char id = 'A';

            bool full=false;

            for (int iy = 0; iy<10; iy++)
            {
                for (int ix = 0; ix<10; ix++)
                {
                    full = false;
                    foreach (Point coord in points)
                    {
                        if (coord.x==ix && coord.y==iy)
                        {
                            Console.Write(id);
                            id++;
                            full=true;
                        }
                    }
                    if (!full)
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
            
            Console.WriteLine(/*Answer*/);
            Console.ReadKey();
        }
    }
}
