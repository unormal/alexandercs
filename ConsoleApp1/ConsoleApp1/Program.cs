using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Present : IComparable
    {
        public Present()
        {
            l = 0;
            w = 0;
            h = 0;
        }

        public Present( int startl, int startw, int starth )
        {
            l = startl;
            w = startw;
            h = starth;
        }

        public int l,w,h;

        public int GetSurfaceArea()
        {
            return 2*l*w + 2*w*h + 2*h*l;
        }
        public int GetSmallestPerimeter()
        {
            var x = new List<int>();

            x.Add(l + w + l + w);
            x.Add(w + h + w + h);
            x.Add(h + l + h + l);

            x.Sort();

            return x[0];
        }

        public int GetExtraPaperRequired()
        {
            var x = new List<int>();

            x.Add(l * w);
            x.Add(w * h);
            x.Add(h * l);

            x.Sort();

            return x[0];
        }
        public int GetExtraRibbonRequired()
        {
            return w*h*l;
        }
        public int GetPaperRequired()
        {
            return GetSurfaceArea() + GetExtraPaperRequired();
        }
        public int GetRibbonRequired()
        {
            return GetSmallestPerimeter() + GetExtraRibbonRequired();
        }

        public int CompareTo(object obj)
        {
            Present p = obj as Present;
            return GetSurfaceArea().CompareTo(p.GetSurfaceArea());        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string[] input = File.ReadAllLines("input.txt");

            var presents = new List<Present>();

            foreach (string s in input)
            {
                string[] x = s.Split('x');
                Present p = new Present(int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]));

                presents.Add(p);
            }
            int answer = 0;

            foreach (Present p in presents)
            {
                answer += p.GetPaperRequired();
            }



            Console.WriteLine();
            Console.WriteLine("Paper: " + answer);

            answer = 0;

            foreach (Present p in presents)
            {
                answer += p.GetRibbonRequired();
            }

            presents.Sort();

            Console.WriteLine("Ribbon: " + answer);
            Console.ReadKey();
        }
    }
}
