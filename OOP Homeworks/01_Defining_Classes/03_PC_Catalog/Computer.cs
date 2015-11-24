using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    class Computer
    {
        private string name;
        private List<Component> components;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == "") throw new Exception("Invalid name");
                this.name = value;
            }
        }
        public List<Component> Components
        {
            get
            {
                return this.components;
            }
        }

        public Computer(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
        }

        public void AddComponent(string componentName, int componentPrice)
        {
            this.components.Add(new Component(componentName, componentPrice));
        }

        public override string ToString()
        {
            int totalPrice = 0;
            StringBuilder componentsToString = new StringBuilder();
            foreach(var component in this.components)
            {
                componentsToString.Append(Environment.NewLine +" "+ component);
                totalPrice += component.Price;
                
            }

            return String.Format("Computer: {0}, total price: ${1}, with components: {2}", this.Name,totalPrice,componentsToString);
        }




    }
    class Component : IComparable<Component>
    {
        private string name;
        private int price;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == "") throw new Exception("Invalid name");
                this.name = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0) throw new Exception("Invalid price");
                this.price = value;
            }
        }

        public Component(String name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        public override string ToString()
        {
            return String.Format("{0} cost: {1}", this.Name, this.Price);
        }
        public int CompareTo(Component other)
        {
            return other.Price.CompareTo(this.Price);
        }
    }
}
