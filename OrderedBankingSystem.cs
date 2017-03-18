using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedBankingSystem
{
    public class OrderedBankingSystem
    {
        public static void Main()
        {
            var banksAccounts = new Dictionary<string, Dictionary<string, decimal>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] inputParams = inputLine.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string bankName = inputParams[0];
                string bankAccountName = inputParams[1];
                decimal bankAccountBalance = decimal.Parse(inputParams[2]);

                if (!banksAccounts.ContainsKey(bankName))
                {
                    banksAccounts.Add(bankName, new Dictionary<string, decimal>());
                }

                if (!banksAccounts[bankName].ContainsKey(bankAccountName))
                {
                    banksAccounts[bankName].Add(bankAccountName, 0);
                }

                banksAccounts[bankName][bankAccountName] += bankAccountBalance;

                inputLine = Console.ReadLine();
            }

            foreach (var bank in banksAccounts.OrderByDescending(bank => bank.Value.Sum(account => account.Value))
            .ThenByDescending(bank => bank.Value.Max(account => account.Value)))
            {
                foreach (var account in bank.Value.OrderByDescending(account => account.Value))
                {
                    Console.WriteLine("{1} -> {2} ({0})", bank.Key, account.Key, account.Value);
                }
            }

            //banksAccounts
            //    .OrderByDescending(bank => bank.Value.Sum(account => account.Value))
            //    .ThenByDescending(bank => bank.Value.Max(account => account.Value))
            //    .ToList()
            //    .ForEach(bank => bank.Value
            //    .OrderByDescending(account => account.Value)
            //    .ToList()
            //    .ForEach(account => Console.WriteLine("{0} -> {1} ({2})", account.Key, account.Value, bank.Key)));
        }
    }
}
