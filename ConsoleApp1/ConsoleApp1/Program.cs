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
        static Rect CreateRect(string str)
        {
            var r = new Rect();

            str = str.Replace(" ", "");
            str = str.Replace("#", "");

            var parts = str.Split(new char[] { ',', 'x', ':', '@' });

            r.id = int.Parse(parts[0]);
            r.x = int.Parse(parts[1]);
            r.y = int.Parse(parts[2]);
            r.w = int.Parse(parts[3]);
            r.h = int.Parse(parts[4]);

            //map[r.x,r.y] = r.id;
            return r;
        }
        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string[] input = File.ReadAllLines("input.txt");


            List<Rect> rects = new List<Rect>();

            foreach (string line in input) rects.Add(CreateRect(line));

            string[,] map = new string[1000, 1000];

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    map[x, y] = ".";
                }
            }

            foreach (Rect r in rects)
            {
                for (int x = r.x; x < r.x + r.w; x++)
                {
                    for (int y = r.y; y < r.y + r.h; y++)
                    {
                        if (map[x, y] == ".")
                        {
                            map[x, y] = r.id.ToString();
                        }
                        else if (map[x, y][0] == 'X' && map[x, y] != map[x, y] + "," + r.id.ToString())
                        {
                            map[x, y] = map[x, y] + "," + r.id.ToString();
                        }
                        else if (map[x, y] != "X" + "," + map[x, y] + "," + r.id.ToString())
                        {
                            map[x, y] = "X" + "," + map[x, y] + "," + r.id.ToString();
                        }
                    }
                }
            }

            HashSet<int> overlappingIds = new HashSet<int>();
            List<int> ix = new List<int>();
            int answer = 0;

            foreach (string id in map)
            {
                if (id[0] == 'X')
                {
                    foreach (string item in id.Remove(0, 1).Split(','))
                    {
                        if (item != "" && !ix.Contains(int.Parse(item)))
                        {
                            ix.Add(int.Parse(item));
                        }
                    }
                    foreach (int it in ix)
                    {
                        overlappingIds.Add(it);
                    }
                    if (overlappingIds.Count == 1301)
                    {
                        break;
                    }
                }
            }

            for (int t = 1; t < 1302; t++)
            {
                if (!overlappingIds.Contains(t))
                {
                    answer = t;
                    break;
                }
            }


            Console.WriteLine();
            Console.WriteLine("Answer: " + answer);
            Console.ReadKey();
        }
    }
}
