using System;
using System.CodeDom;

namespace _02_Fraction_Calculator
{
    public struct Fraction
    {
        private long numerator;
        private long denomerator;

        public Fraction(long numerator, long denomerator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denomerator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denomerator; }
            set
            {
                if (value == 0) throw new ArgumentException("Denomerator cannot be 0");
                this.denomerator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator*b.Denominator + b.Numerator*a.Denominator,a.Denominator*b.Denominator);
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator/this.Denominator).ToString();
        }
    }
}