using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Person
    {
        public string name = "";
        public string birthday = "";
        public void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(birthday);
        }
    }
}
