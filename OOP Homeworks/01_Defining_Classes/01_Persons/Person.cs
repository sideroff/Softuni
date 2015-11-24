﻿using System;

namespace _01_Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == "")
                {
                    throw new Exception("Invalid name.");
                }
                this.name = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value == null || value.Contains("@")) this.email = value;
                else throw new Exception("Invalid E-mail.");
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Invalid age.");
                }
                this.age = value;
            }
        }

        public Person(string name, int age) : this(name,age,null)
            {}
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public override string ToString()
        {
            return String.Format("Person name: {0}, age: {1}, email: {2}", this.Name, this.Age, this.Email);
        }


    }
}
