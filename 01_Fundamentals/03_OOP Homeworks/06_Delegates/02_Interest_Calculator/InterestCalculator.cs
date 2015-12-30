﻿using System;

namespace _02_Interest_Calculator
{
    public class InterestCalculator
    {
        public InterestCalculator(decimal sum, decimal interest, int years, Func<decimal, decimal, int, decimal> func)
        {
            this.Sum = sum;
            this.Interest = interest/100m;
            this.Years = years;
            this.Result = func.Invoke(this.Sum, this.Interest, this.Years);
        }

        public decimal Sum { get; set; }

        public decimal Interest { get; set; }

        public int Years { get; set; }

        public decimal Result { get; set; }
    }
}