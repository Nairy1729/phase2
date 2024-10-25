using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6};
            var squared = list.Select(x => x * x);
            Console.WriteLine(string.Join(" ",squared));
            var even = list.FindAll(x => x % 2 == 0);
            Console.WriteLine(string.Join(" ",even));
            Console.ReadLine();

        }
    }
}
