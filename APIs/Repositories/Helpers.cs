using System;
using System.Collections.Generic;

namespace APIs.Repositories
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items) {
            return items[_rand.Next(items.Count)]
    ; }
        internal static string MakeUniqueCustomersName(List<string>names) {

            var maxName = bizPrefix.Count * bizSuffix.Count;
            if (names.Count >= maxName)
            {
               throw new Exception ("Unique names exceedde");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var biznme = prefix + suffix;
          
            if (names.Contains(biznme))
            {
                MakeUniqueCustomersName(names);
            }
            return biznme;
        }
      internal static string GetRandomEmail(string customerName) {
            return $"contact@{customerName}.com";
        }

        internal static string GetRandomStates() {
            return GetRandom(GenerateRandomStates);
        }

        internal static decimal GetRandomTotal() {
            return _rand.Next(10, 1000);
        }

        internal static DateTime GetRandomOrderPlaced() {
            var end = DateTime.Now;
            var start = end.AddDays(-50);
            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(1, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced) {
         
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;
            if (timePassed < minLeadTime)
            {
                return null;
            }
            return orderPlaced.AddDays(_rand.Next(7, 14));
        }

       private static readonly List<string> GenerateRandomStates = new List<string>() {
        "AB",
        "CV",
        "CA",
        "CC",
        "AA",
        "DD",
        "EG",
        "G3T",
        "3G",
        "JY",
        "QE",
        "WJ"
                };
        private static readonly List<String> bizPrefix = new List<string>() {
       "ABC",
       "READY",
       "QUICK",
       "MORNING",
       "AFTERNOON",
       "STREET",
       "APPLE",
       "SAMSUNG",
       "ML",
       "MALL"

        };


        private static readonly List<String> bizSuffix = new List<string>() {
       "CALDERA",
       "TREE",
       "SLOW",
       "SOFTEN",
       "DOFFER",
       "DOFGTE",
       "TALLEN",
       "FALLTE",
       "LOTTLE",
       "FREZEN"

        };
    }
}