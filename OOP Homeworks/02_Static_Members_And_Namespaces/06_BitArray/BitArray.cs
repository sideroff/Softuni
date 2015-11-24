using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_BitArray
{
    class BitArray
    {
        private int size;
        private string number;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
        public int this[int index]
        {
            get
            {
                return this.Number[index];
            }
            set
            {
                char[] n = this.Number.ToCharArray();
                n[index] = (char)(48 + value);
                string sb = "";
                foreach (char ch in n)
                {
                    sb += ch;
                }
                this.Number = sb;
            }
        }

        public BitArray (int size)
        {
            this.Size = size;
            this.Number = new string('0', this.Size);
        }

        public override string ToString()
        {
            string sb = "";
            foreach (char ch in this.Number)
            {
                sb += ch;
            }
            return sb;
        }

    }
}
