using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,0
            };
            var result = list.FilterWithYield(x => x % 2 == 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();

        }
    }
}
