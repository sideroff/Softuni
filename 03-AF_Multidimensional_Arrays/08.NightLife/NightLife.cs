using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;       //too tired to do all this with methods so no hate

namespace _08.NightLife
{
    class NightLife
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> musaka = new Dictionary<string, Dictionary<string, string>>();
            HashSet<string> performers = new HashSet<string>();                                                                  
            while(true)
            {
                string[] input = Console.ReadLine().Split(';').ToArray();
                if (input[0] == "END") break;                       //exit while if command is end
                if (performers.Contains(input[2])) continue;        //cannot have the same singer in two different places > singer is unique 1*
                if (musaka.ContainsKey(input[0]))
                {
                    if(musaka[input[0]].ContainsKey(input[1]))
                    {
                        musaka[input[0]][input[1]] += ' ' +input[2];      //you have the city and the club, but not the singer | or 1, 1, 0
                        performers.Add(input[2]);
                    }
                    else
                    {
                        musaka[input[0]].Add(input[1], input[2]);    // you dont have the club in the city, and dont have the singer because of 1*, so add them
                        performers.Add(input[2]);
                    }
                }
                else
                {
                    Dictionary<string, string> inner = new Dictionary<string, string>();
                    inner.Add(input[1], input[2]);
                    musaka.Add(input[0],inner );
                                                                // you dont have the city, add it , you might have the club but club names are not unique
                performers.Add(input[2]);                       // and you've already checked for the singer in 1*
                }
            }

            foreach (var pair in musaka)
            {
                Console.WriteLine(pair.Key);
                foreach (var innerPair in pair.Value)
                {
                    string value = innerPair.Value;
                    string[] gosho = value.Split();
                    Array.Sort(gosho);
                    Console.WriteLine("->{0}: {1}", innerPair.Key,string.Join(",",gosho));      //its too late for me to figure out how to do this functionally
                }
            }


        }
    }
}

