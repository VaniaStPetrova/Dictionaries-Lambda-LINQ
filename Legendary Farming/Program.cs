﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;

            SortedDictionary<string, int> junks = new SortedDictionary<string, int>();

            string legendaryItem = string.Empty;
            bool legendaryItemObtained = false;

            while (!legendaryItemObtained)
            {
                string[] input = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .ToArray();

                int currentItemQuantity = 0;
                string currentItem = string.Empty;

                for (int i = 0; i < input.Length; i += 2)
                {
                    TakeInputParameters(input, i, ref currentItemQuantity, ref currentItem);

                    FillTheDictionaries(materials, junks, currentItemQuantity, currentItem, i);

                    if (materials.ContainsKey(currentItem))
                    {
                        if (materials[currentItem] >= 250)
                        {
                            if (currentItem == "shards")
                            {
                                legendaryItem = "Shadowmourne";
                            }
                            else if (currentItem == "fragments")
                            {
                                legendaryItem = "Valanyr";
                            }
                            else if (currentItem == "motes")
                            {
                                legendaryItem = "Dragonwrath";
                            }
                            materials[currentItem] -= 250;
                            legendaryItemObtained = true;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("{0} obtained!", legendaryItem);

            foreach (var material in materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0}: {1}",material.Key, material.Value);
            }

            foreach (var junk in junks)
            {
                Console.WriteLine("{0}: {1}", junk.Key, junk.Value);
            }

        }

        public static void FillTheDictionaries(Dictionary<string, int> materials, SortedDictionary<string, int> junks, int currentItemQuantity, string currentItem, int i)
        {
            if (currentItem == "shards" || currentItem == "fragments" || currentItem == "motes")
            {
                materials[currentItem] += currentItemQuantity;
            }
            else
            {
                if (!junks.ContainsKey(currentItem))
                {
                    junks[currentItem] = 0;
                }
                junks[currentItem] += currentItemQuantity;
            }


        }

        public static void TakeInputParameters(string[] input, int i, ref int currentItemQuantity, ref string currentItem)
        {
            currentItemQuantity = int.Parse(input[i]);
            currentItem = input[i + 1];
        }
    }
}
