using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.String_Disperser;

namespace _03_StringDisperser
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDisperser disprerser = new StringDisperser(new string[] {"gosho", "pesho","ivan" });
            foreach (var character in disprerser)
            {
                Console.Write(character + " ");
            }
            Console.WriteLine();
        }
    }
}
