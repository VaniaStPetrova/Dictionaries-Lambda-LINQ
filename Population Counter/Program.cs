﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> countryCityPop = new Dictionary<string, Dictionary<string, long>>();

            string[] inputLine = Console.ReadLine().Split('|');

            while (inputLine[0] != "report")
            {
                string country = inputLine[1];
                string city = inputLine[0];
                int population = int.Parse(inputLine[2]);
                if (!countryCityPop.ContainsKey(country))
                {
                    countryCityPop[country] = new Dictionary<string, long>();
                    countryCityPop[country].Add(city, population);
                }
                else
                {
                    countryCityPop[country][city] = population;
                }

                inputLine = Console.ReadLine().Split('|');

            }

            foreach (var countryFirst in countryCityPop.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})",countryFirst.Key, countryFirst.Value.Values.Sum());
                foreach (var cityAndPop in countryFirst.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", cityAndPop.Key, cityAndPop.Value);
                }
            }
        }
    }
}
