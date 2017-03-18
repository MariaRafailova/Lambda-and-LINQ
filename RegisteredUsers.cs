using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace RegisteredUsers
{
    public class RegisteredUsers
    {
        public static void Main()
        {
            Dictionary<string, DateTime> register = new Dictionary<string, DateTime>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputParams = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string username = inputParams[0];
                DateTime registryDate = DateTime.ParseExact(inputParams[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                register[username] = registryDate;

                input = Console.ReadLine();
            }

            Dictionary<string, DateTime> result = register
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}");
            }
        }
    }
}
