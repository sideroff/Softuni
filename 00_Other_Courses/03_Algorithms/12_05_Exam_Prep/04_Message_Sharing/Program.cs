using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Message_Sharing
{
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main()
        {
            //People: Pesho, Maria, Ivan, Gosho
            //Connections: Pesho - Gosho, Maria - Ivan, Ivan - Gosho, Pesho - Maria, Maria - Gosho
            //Start: Maria

            Dictionary<string, List<string>> people =
                Console.ReadLine()
                    .Substring(8)
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToDictionary(k => k, v => new List<string>());

            foreach (var pair in Console.ReadLine().Substring(12).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] peopleInPair = pair.Split(
                    new char[] { '-', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                var person1 = peopleInPair[0].Trim();
                var person2 = peopleInPair[1].Trim();
                people[person1].Add(person2);
                people[person2].Add(person1);
            }

            Queue<string> senders = new Queue<string>();
            Dictionary<string, int> stepReachedOn = new Dictionary<string, int>();

            foreach (var starter in Console.ReadLine()
                .Substring(7)
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                senders.Enqueue(starter);
                stepReachedOn[starter] = 0;
            }
            int maxSteps = 0;
            while (senders.Any())
            {
                var sender = senders.Dequeue();
                foreach (var friend in people[sender])
                {
                    if (stepReachedOn.ContainsKey(friend))
                    {
                        continue;
                    }
                    stepReachedOn[friend] = stepReachedOn[sender] + 1;
                    maxSteps = stepReachedOn[friend];
                }
            }
            var resultArray =
                stepReachedOn.Where(s => s.Value == maxSteps).Select(kvp => kvp.Key).ToArray();
            if (people.Count == stepReachedOn.Count)
            {
                Array.Sort(resultArray);
                Console.WriteLine($"All people reached in {maxSteps} steps");
                Console.WriteLine($"People at last step: " + string.Join(", ", resultArray));
            }
            else
            {
                var notReached = people.Where(kvp => !stepReachedOn.ContainsKey(kvp.Key)).ToArray();
                Array.Sort(notReached);
                Console.WriteLine($"Could not reach: {string.Join(", ",notReached)}");
            }

        }
    }
}

