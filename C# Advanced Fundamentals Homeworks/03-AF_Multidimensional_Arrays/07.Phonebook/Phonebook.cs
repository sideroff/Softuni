using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Use this format: <name> <phone number>");
            Console.WriteLine("Otherwise you will receive the wrath of the Gods of Exceptions");
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            InputNamesIntoPhoneBook(ref phonebook);
            SearchFromPhoneBook(ref phonebook);
            

        }
        private static void InputNamesIntoPhoneBook(ref Dictionary<string,string> phonebook)
        {
            string[] input;
            while (true)
            {
                input = Console.ReadLine().Split().ToArray();
                if (input[0] == "search") break;
                phonebook.Add(input[0], input[1]);
            }
            Console.WriteLine();
            Console.WriteLine("To end the search, type \"end\" and hit Enter");
        }
        private static void SearchFromPhoneBook(ref Dictionary<string,string> phonebook)
        {
            string[] input;
            while (true)
            {
                input = Console.ReadLine().Split().ToArray();
                if (input[0] == "end") break;
                if (phonebook.ContainsKey(input[0])) Console.WriteLine("{0} -> {1}", input[0], phonebook[input[0]]);
                else Console.WriteLine("Contact {0} does not exist.", input[0]);

            }
        }

    }
}
