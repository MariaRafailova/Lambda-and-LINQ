using System;
using System.Collections.Generic;
using System.Linq;

namespace FlattenDictionary
{
    public class FlattenDictionary
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputParams = input.Split(' ');

                if (inputParams[0] != "flatten")
                {
                    string key = inputParams[0];
                    string innerKey = inputParams[1];
                    string innerValue = inputParams[2];

                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, new Dictionary<string, string>());
                    }
                    
                        dictionary[key][innerKey] = innerValue;                   
                }
                else
                {
                    string key = inputParams[1];

                    dictionary[key] = dictionary[key]
                        .ToDictionary(x => x.Key + x.Value, x => "flatten");
                }
                           
                input = Console.ReadLine();
            }

            var orderedDictionary = dictionary
            .OrderByDescending(x => x.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in orderedDictionary)
            {
                Console.WriteLine("{0}", item.Key);

                var orderedInnerDictionary = item.Value
                    .Where(x => x.Value != "flatten")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);

                var flattenValues = item.Value
                    .Where(x => x.Value == "flatten")
                    .ToDictionary(x => x.Key, x => x.Value);

                int count = 1;

                foreach (var entry in orderedInnerDictionary)
                {
                    Console.WriteLine("{0}. {1} - {2}", count, entry.Key, entry.Value);
                    count++;
                }

                foreach (var flattenEntry in flattenValues)
                {
                    Console.WriteLine("{0}. {1}", count, flattenEntry.Key);
                    count++;
                }
            }

        }
    }
}
