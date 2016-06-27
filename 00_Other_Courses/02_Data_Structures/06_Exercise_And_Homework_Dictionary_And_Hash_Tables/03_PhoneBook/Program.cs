using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PhoneBook
{
    using System.Collections;

    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> simplePhoneBook = new HashTable<string, string>();
            ReadCommands(simplePhoneBook);

        }

        private static void ReadCommands(HashTable<string,string> simplePhoneBook)
        {
            Console.WriteLine("Use <name>-<number> format to add a person," + Environment.NewLine +
                              "\"search\"*enter* allows search by name, " + Environment.NewLine+
                              "\"back\" goes to previous menu." + Environment.NewLine +
                              "\"quit\" stops the program.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    return;
                }
                if (input == "search")
                {
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input == "back")
                        {
                            ReadCommands(simplePhoneBook);
                            return;
                        }
                        if (simplePhoneBook.ContainsKey(input))
                        {
                            Console.WriteLine($"{input} -> {simplePhoneBook[input]}");
                        }
                        else
                        {
                            Console.WriteLine("No record with such name exists.");
                        }
                    }
                }
                string[] splitted = input.Split('-');
                simplePhoneBook[splitted[0]] = splitted[1];
            }
        }
    }
}
