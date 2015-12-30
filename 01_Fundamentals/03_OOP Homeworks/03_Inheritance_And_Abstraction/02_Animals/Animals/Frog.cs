using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Animals
{
    public class Frog:Animal
    {
        private const string SOUND = "Kvako";

        public Frog(string name, int age, string gender)
            :base(name,age,gender)
        { }

        public override string ProduceSound()
        {
            return "Kvako";
        }
    }
}
