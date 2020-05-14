using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Middle m =new Middle(new Final());

            m.PerformAction("Hello").Wait();

            Console.ReadLine();
        }


        
    }
}
