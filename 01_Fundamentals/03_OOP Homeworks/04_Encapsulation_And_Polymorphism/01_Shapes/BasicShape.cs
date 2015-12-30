namespace Shapes
{
    public abstract class BasicShape : IShape
    {
        public BasicShape(uint width, uint height)
        {
            this.Width = width;
            this.Height = height;
        }
        public uint Width { get; set; }

        public uint Height { get; set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}