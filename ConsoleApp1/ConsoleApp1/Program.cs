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
        public List<int> parseLine( string line )
        {
            //...
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            
            var lines = new Dictionary<int,List<int>>();
            var differences = new List<decimal>();
            var even = new List<decimal>();
            var alreadydid = new List<int>();
            for (int i = 0;i<input.Length;i++) {
                lines.Add(i,input[i].Replace('\t',' ').Split(' ').Select( e => int.Parse(e)).ToList());
            }

            bool br=false;
            for (int i = 0; i < lines.Count; i++)
            {
                foreach (var item in lines[i])
                {
                    foreach (var check in lines[i])
                    {
                        if ((decimal)(item) / (decimal)(check) == Math.Floor((decimal)(item / check)) && item!=check && item/check!=0)
                        {
                            even.Add(item / check);
                            alreadydid.Add(item / check);
                            Console.WriteLine(item+","+check+"="+(item/check));
                            br=true;
                            break;
                        }
                    }
                    if (br)
                    {
                        br=false;
                        alreadydid.Clear();
                        break;
                    }
                }
            }

            int sum = 0;
            foreach (int val in even)
            {
                Console.WriteLine(val);
                sum+=val;
            }

            

            Console.WriteLine();
            Console.WriteLine("answer: "+sum);
            Console.ReadKey();
        }
    }
}
