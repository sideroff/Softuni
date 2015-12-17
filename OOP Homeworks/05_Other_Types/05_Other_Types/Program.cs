using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Other_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);

            Location pluto = new Location(72.1986, 100.870097, Planet.Pluto);
            Console.WriteLine(pluto);

            //this throws an exception because of the validity check in the setter;
            Location mars = new Location(92.1986, 100.870097, Planet.Mars);
            Console.WriteLine(pluto);

        }
    }
}
