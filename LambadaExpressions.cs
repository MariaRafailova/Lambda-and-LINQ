using System;
using System.Collections.Generic;
using System.Linq;

namespace LambadaExpressions
{
    public class LambadaExpressions
    {
        private static object selector;

        public static void Main()
        {
            var lambadaExpressions = new Dictionary<string, Dictionary<string, string>>();

            var inputLine = Console.ReadLine();

            while (inputLine != "lambada")
            {
                string[] inputParams = inputLine.Split(new[] { ' ', '=', '>', '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputParams.Length > 1)
                {
                    string selector = inputParams[0];
                    string selectorObject = inputParams[1];
                    string property = inputParams[2];

                    if (!lambadaExpressions.ContainsKey(selector))
                    {
                        lambadaExpressions.Add(selector, new Dictionary<string, string>());
                    }

                    lambadaExpressions[selector][selectorObject] = property;
                }
                else
                {
                    lambadaExpressions = lambadaExpressions
                    .ToDictionary(selector => selector.Key, selector => selector.Value.
                    ToDictionary(selectorObject => selectorObject.Key,
                    selectorObject => selectorObject.Key + "." + selectorObject.Value));
                }

                inputLine = Console.ReadLine();
            }

            lambadaExpressions
                .ToList()
                .ForEach(selector => selector.Value
                .ToList()
                .ForEach(selectorObject => Console.WriteLine("{0} => {1}.{2}",
                selector.Key, selectorObject.Key, selectorObject.Value)));
        }
    }
}
