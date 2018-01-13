using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
                        SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            string[] inputDetails = Console.ReadLine().Split();

            while (inputDetails[0] != "END")
            {
                if (inputDetails.Length == 3) //add to the dict
                {
                    phonebook[inputDetails[1]] = inputDetails[2];
                }
                else if (inputDetails.Length == 2) //find
                {
                    if (phonebook.ContainsKey(inputDetails[1]))
                    {
                        Console.WriteLine("{0} -> {1}",inputDetails[1], phonebook[inputDetails[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.",inputDetails[1]);
                    }
                }
                else //list all
                {
                    foreach (var kvp in phonebook)
                    {
                        Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
                    }
                }
                inputDetails = Console.ReadLine().Split();
            }
        }
    }
}
