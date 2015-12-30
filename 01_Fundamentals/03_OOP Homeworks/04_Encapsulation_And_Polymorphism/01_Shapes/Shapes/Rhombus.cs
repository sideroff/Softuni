namespace Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(uint width, uint height)
            :base(width,height)
        {
        }
        public override double CalculateArea()
        {
            return this.Width*this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }
    }
}