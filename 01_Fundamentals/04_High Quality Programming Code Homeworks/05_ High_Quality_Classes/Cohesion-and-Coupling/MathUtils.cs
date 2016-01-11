namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Interfaces;

    public class MathUtils : IMathUtility
    {
        private double width;
        private double height;
        private double depth;

        public MathUtils()
        {
            
        }

        public MathUtils(double width, double height, double depth)
        {
            this.Width= width;
            this.Height = height;
            this.Depth = depth;
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
                    throw new ArgumentException("Width cannot be less than or equal to zero");
                }
                this.width = value;
            }
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
                    throw new ArgumentException("height cannot be less than or equal to zero");
                }
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("depth cannot be less than or equal to zero");
                }
                this.depth = value;
            }
        }

        public double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
