using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _02_Animals
{
    public abstract class Cat : Animal
    {
        private const string SOUND = "Malo";
        protected Cat(string name, int age, string gender)
            :base (name,age,gender)
        { }

        public override string ProduceSound()
        {
            return "Malo";
        }
    }
}
