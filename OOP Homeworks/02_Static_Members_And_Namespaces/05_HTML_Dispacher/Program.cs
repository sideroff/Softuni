using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HTML_Dispacher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder eb = new ElementBuilder("div");
            eb.addAtTribute("class", "header");
            eb.addAtTribute("id", "avatar");

            eb.addContent("<p>Hello</p>");
            eb.addContent("<p>Can you hear me?</p>");

            eb = eb * 2;

            Console.WriteLine(eb);

        }
    }
}
