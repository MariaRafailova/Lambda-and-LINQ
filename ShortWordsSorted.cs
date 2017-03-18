using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    public class ShortWordsSorted
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split(new[] { ' ', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?'}, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length < 5)
                .Distinct()
                .OrderBy(w => w)
                .ToList();

            Console.WriteLine(string.Join(", ", words));
        }
    }
}
