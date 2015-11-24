using System;
//define a class person with name,age and optional email 
//define properties that check for data validity.
//use 2 constructors -> 1 takes all 3 properties, 2 takes name, age and null email;

namespace _01_Persons
{
    class Main_Person
    {
        static void Main()
        {
            Person johny = new Person("Johny", 21, "Johny@gmail.com");
            //Person bob = new Person("Bob", 0, "Bob@gmail.com");
            //Person bill = new Person("Bill", 21, "Bill@gmail.com");
            //Person joe = new Person("", 21, "Joe@gmail.com");
            //Person jim = new Person("Jim", 21, "");
            Person jake = new Person("Jake", 21);
            Console.WriteLine(johny);
            Console.WriteLine(jake);
        }
    }
}
