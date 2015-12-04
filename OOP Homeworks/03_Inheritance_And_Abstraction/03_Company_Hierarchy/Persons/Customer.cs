using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy
{
    class Customer : Person
    {
        private uint netValue;

        public Customer(uint id, string fname, string lname,uint netValue)
            : base(id, fname, lname)
        {
            this.NetValue = netValue;
        }

        public uint NetValue
        {
            get { return netValue; }
            set { netValue = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" Net value: {this.netValue}";
        }
    }
}
