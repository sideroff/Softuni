using System.Collections.Generic;
using System.Linq;
using _02_Animals.Cats;


namespace _02_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog("pesho", 19, "Male"));
            animals.Add(new Kitten("goshko",12));
            animals.Add(new Tomcat("ivan", 19));
            animals.Add(new Frog("evgeni", 19, "Female"));  
            animals.ForEach(x => System.Console.WriteLine(x.ProduceSound()));

        }
    }
}
