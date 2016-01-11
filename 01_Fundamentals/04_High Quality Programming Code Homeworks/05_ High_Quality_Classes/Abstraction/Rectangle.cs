namespace Abstraction
{
    using System;

    class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(
            double width,
            double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle height cannot be less or equal to zero.");
                }
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle height cannot be less or equal to zero.");
                }
                this.width = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
