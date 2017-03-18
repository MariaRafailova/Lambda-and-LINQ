using System;
using System.Linq;

namespace FoldAndSum
{
    public class FoldAndSum
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = input.Length / 4;

            var left = input.Take(k).Reverse().ToArray();
            var right = input.Reverse().Take(k).ToArray();
            var first = left.Concat(right).ToArray();
            var second = input.Skip(k).Take(2 * k).ToArray();

            var sum = first.Select((x, index) => x + second[index]).ToArray();

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
