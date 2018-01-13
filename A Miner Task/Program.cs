using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string type = Console.ReadLine();

            while (type != "stop")
            {
                int quantity = 0;

                quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(type))//ако се намерят
                {
                    resources[type] = resources[type] + quantity;//,то тогава нарастват

                }
                else
                {
                    resources.Add(type, quantity);//в противен случай - поставяме ги
                }

                type = Console.ReadLine();
            }
            PrintSortedResults(resources);//метод
        }

        private static void PrintSortedResults(Dictionary<string, int> resources)
        {
            foreach (KeyValuePair<string, int> type in resources)
            {
                Console.WriteLine("{0} -> {1}", type.Key, type.Value);
            }
        }
    }
}
