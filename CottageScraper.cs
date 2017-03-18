using System;
using System.Collections.Generic;
using System.Linq;

namespace CottageScraper
{
    public class CottageScraper
    {
        public static void Main()
        {
            var treeCollection = new Dictionary<string, List<int>>();         

            var input = Console.ReadLine();

            double sumOfAllLogs = 0;
            int count = 0;

            while (input != "chop chop")
            {
                
                var parts = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                var type = parts[0];
                var height = int.Parse(parts[1]);

                sumOfAllLogs += height;
                count += 1;

                if (!treeCollection.ContainsKey(type))
                {
                    treeCollection[type] = new List<int>();
                }

                treeCollection[type].Add(height);

                input = Console.ReadLine();
            }
            
            var typeOfTree = Console.ReadLine();

            var minLength = int.Parse(Console.ReadLine());

            var priceMeter = sumOfAllLogs / count;
            var pricePerMeter = Math.Round(priceMeter, 2);

            var usedLogs = treeCollection[typeOfTree]
                .Where(x => x > minLength)
                .ToList();

            var sumUsedLogs = usedLogs.Sum();

            double usedLogsPrise = Math.Round((sumUsedLogs * pricePerMeter), 2);

            var difference = sumOfAllLogs - sumUsedLogs;

            double unusedLogsPrice = Math.Round((difference * pricePerMeter*0.25),2);

            var totalLogsPrice = Math.Round((usedLogsPrise + unusedLogsPrice), 2);

            Console.WriteLine("Price per meter: ${0:F2}", pricePerMeter);
            Console.WriteLine("Used logs price: ${0:F2}", usedLogsPrise);
            Console.WriteLine("Unused logs price: ${0:F2}", unusedLogsPrice);
            Console.WriteLine("CottageScraper subtotal: ${0:f2}", totalLogsPrice);

        }
    }
}
