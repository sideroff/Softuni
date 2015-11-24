using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_BitArray
{
    class Program
    {
        static void Main(string[] args)
        {

            BitArray ba = new BitArray(32);
            Console.WriteLine("default: "+ ba);
            ba[3] = 1;
            ba[1] = 1;
            ba[5] = 1;
            Console.WriteLine("new: " + ba);
        }
    }
}
