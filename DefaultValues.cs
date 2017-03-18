using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultValues
{
    public class DefaultValues
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputParams = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string key = inputParams[0];
                string value = inputParams[1];

                dictionary[key] = value;

                input = Console.ReadLine();
            }

            string defaultValue = Console.ReadLine();

            var unchangedValues = dictionary
                .Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            var changedValues = dictionary
                .Where(x => x.Value == "null")
                .ToDictionary(x => x.Key, x => defaultValue);

            foreach (var item in unchangedValues)
            {
                Console.WriteLine("{0} <-> {1}", item.Key, item.Value);
            }

            foreach (var item in changedValues)
            {
                Console.WriteLine("{0} <-> {1}", item.Key, item.Value);
            }
        }
    }
}
