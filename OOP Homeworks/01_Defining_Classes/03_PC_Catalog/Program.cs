using System;
//Define a class Computer that holds name, several components and price. 
//multiple constructors
//sort components by price
//print data;

namespace _03_PC_Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer newComputer = new Computer("Lenovo");
            newComputer.AddComponent("video card", 50);
            newComputer.AddComponent("cpu", 100);
            newComputer.AddComponent("hdd", 30);

            Computer newerComputer = new Computer("Pravets");
            newerComputer.AddComponent("screen", 50);
            newerComputer.AddComponent("power", 90);
            newerComputer.AddComponent("monitor", 150);

            newComputer.Components.Sort((component1, component2) => component1.CompareTo(component2));

            Console.WriteLine(newComputer); 
            Console.WriteLine(newerComputer);

        }
    }
}
