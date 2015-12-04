namespace Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(uint width, uint height)
            :base(width,height)
        {
        }
        public override double CalculateArea()
        {
            return this.Height*this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width)*2;
        }
    }
}