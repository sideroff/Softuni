using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Animals
{
    public abstract class Animal: ISoundProducible
    {
        private string name;
        private int age;
        private Gender gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            Gender genderValue = (Gender)Enum.Parse(typeof(Gender), gender);
            this.Gender = genderValue;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public abstract string ProduceSound();
    }
}
