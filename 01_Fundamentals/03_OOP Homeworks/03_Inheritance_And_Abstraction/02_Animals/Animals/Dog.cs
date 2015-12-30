using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Animals
{
    public class Dog:Animal
    {
        private const string SOUND = "Balo";

        public Dog(string name, int age, string gender)
            :base(name,age,gender)
        { }

        public override string ProduceSound()
        {
            return "Balo";
        }
    }
}