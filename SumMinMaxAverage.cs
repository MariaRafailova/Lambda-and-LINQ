using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMinMaxAverage
{
    public class SumMinMaxAverage
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }

            var sum = nums.Sum();
            var min = nums.Min();
            var max = nums.Max();
            var average = nums.Average();

            Console.WriteLine($"Sum = {sum} \nMin = {min}  \nMax = {max}  \nAverage = {average}");
        }
    }
}
