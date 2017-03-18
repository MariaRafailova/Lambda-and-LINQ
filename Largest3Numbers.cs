using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    public class Largest3Numbers
    {
        public static void Main()
        {
            var nums = Console.ReadLine()
                .Split(' ')  
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .Take(3)
                .ToList();
            
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
