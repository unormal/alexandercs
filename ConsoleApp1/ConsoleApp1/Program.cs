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
            int distance = 0;
            int x=0;
            int y=0;
            int dir=0;
            int answer=-1;
            
            var positions = new List<Position>();
            string[] input = File.ReadAllText("input.txt").Split(new char[]{',',' '});
            

            bool brk=false;
            while (answer == -1) {
                foreach (var item in input)
                {
                    if (brk) break;
                    if (item != "")
                    {
                        Console.WriteLine("step = " + item);
                        if (item.Substring(0,1)=="R")
                        {
                            dir+=1;
                            if (dir==4)
                            {
                                dir=0;
                            }
                        } else
                        {
                            dir-=1;
                            if (dir==-1)
                            {
                                dir=3;
                            }
                        }
                        if (dir==0)
                        {
                            for (int i = 0;i< int.Parse(item.Substring(1));i++) {
                                y+=1;
                                Console.WriteLine("pos = " + x + "," + y);
                                if (positions.Any(pos => (pos.x == x && pos.y == y)))
                                {
                                    answer = Math.Abs(x) + Math.Abs(y);
                                    brk = true;
                                    break;
                                }

                                positions.Add(new Position(x, y));
                            }
                        } else if (dir==1)
                        {
                            for (int i = 0; i < int.Parse(item.Substring(1)); i++)
                            {
                                x +=1;
                                Console.WriteLine("pos = " + x + "," + y);
                                if (positions.Any(pos => (pos.x == x && pos.y == y)))
                                {
                                    answer = Math.Abs(x) + Math.Abs(y);
                                    brk = true;
                                    break;
                                }

                                positions.Add(new Position(x, y));
                            }
                        } else if (dir==2)
                        {
                            for (int i = 0; i < int.Parse(item.Substring(1)); i++)
                            {
                                y -=1;
                                Console.WriteLine("pos = " + x + "," + y);
                                if (positions.Any(pos => (pos.x == x && pos.y == y)))
                                {
                                    answer = Math.Abs(x) + Math.Abs(y);
                                    brk = true;
                                    break;
                                }

                                positions.Add(new Position(x, y));
                            }
                        } else if (dir==3)
                        {
                            for (int i = 0; i < int.Parse(item.Substring(1)); i++)
                            {
                                x -=1;
                                Console.WriteLine("pos = " + x + "," + y);
                                if (positions.Any(pos => (pos.x == x && pos.y == y)))
                                {
                                    answer = Math.Abs(x) + Math.Abs(y);
                                    brk=true;
                                    break;
                                }

                                positions.Add(new Position(x, y));
                            }
                        }
                    }
                }
            }

            distance = Math.Abs(x) + Math.Abs(y);

            Console.WriteLine();
            Console.WriteLine("answer: "+answer);
            Console.ReadKey();
        }
    }
}
