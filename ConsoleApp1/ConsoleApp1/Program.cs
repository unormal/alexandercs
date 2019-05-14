using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Event : IComparable
    {
        public DateTime time;
        public string text;
        public int guardid;

        public Event(DateTime time, string text, int guardid)
        {
            this.time = time;
            this.text = text;
            this.guardid = guardid;
        }

        public int CompareTo(object obj)
        {
            var otherEvent = obj as Event;
            return time.CompareTo(otherEvent.time);
        }
    }
    class Program
    {
        static int GetGuardNumber(string str)
        {
            var splitted = str.Split('#');

            return int.Parse(splitted[1].Split(' ')[0]);
        }
        static void Main(string[] args)
        {
            // int, float, double, byte, string <- value types
            // everything else <- reference types

            string[] input = File.ReadAllLines("input.txt");

            int answer = 0;

            var events = new List<Event>();
            var guards = new Dictionary<int,TimeSpan>();


            foreach (string item in input)
            {
                string[] i = item.Split(']');
                events.Add(new Event(DateTime.Parse(i[0].Substring(1)),i[1],-1));
            }
            events.Sort();
            
            int guardid = -1;
            DateTime time = new DateTime();

            TimeSpan amount = new TimeSpan(0);

            foreach (Event ev in events)
            {
                if (ev.text.Contains("Guard"))
                {
                    guardid = GetGuardNumber(ev.text);
                } else if (ev.text.Contains("falls"))
                {
                    time=ev.time;
                } else if (ev.text.Contains("wakes"))
                {
                    amount += ev.time - time;

                    if (!guards.ContainsKey(guardid))
                    {
                        guards.Add(guardid, amount);
                    }
                    else
                    {
                        guards[guardid] += amount;
                    }
                    amount = new TimeSpan(0);
                }

                ev.guardid = guardid;
            }
            
            double longest = double.MinValue;
            int longestMinute = -1;
            int longestMinuteGuard = -1;
            int longestGuard = -1;

            foreach( var guard in guards )
            {
                if( guard.Value.TotalMinutes > longest )
                {
                    longest = guard.Value.TotalMinutes;
                    longestGuard = guard.Key;
                }
            }

            var listofguards = guards.Keys.ToList();

            var minutecount = new Dictionary<int, int>(); // minute,times

            int sleepminute = 0;

            int longestminutecount = int.MinValue;

            foreach( int currentguard in listofguards )
            {
                minutecount.Clear();
                foreach (Event ev in events)
                {
                    if (ev.guardid == currentguard)
                    {
                        if (ev.text.Contains("falls"))
                        {
                            sleepminute=ev.time.Minute;
                        } else if (ev.text.Contains("wakes"))
                        {
                            for (int i=sleepminute;i<ev.time.Minute;i++)
                            {
                                if (minutecount.ContainsKey(i))
                                {
                                    minutecount[i]+=1;
                                } else
                                {
                                    minutecount.Add(i, 1);
                                }
                                if( minutecount[i] > longestminutecount )
                                {
                                    longestMinute=i;
                                    longestMinuteGuard=currentguard;
                                    longestminutecount=minutecount[i];
                                }
                            }
                        }
                    }
                }
            }


            answer = longestMinuteGuard*longestMinute;

            Console.WriteLine();
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
