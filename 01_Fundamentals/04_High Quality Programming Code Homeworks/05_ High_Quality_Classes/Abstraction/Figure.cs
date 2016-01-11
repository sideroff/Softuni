namespace Abstraction
{
    using Abstraction.Interfaces;
    abstract class Figure : IFigure
    {
        public abstract double CalcSurface();

        public abstract double CalcPerimeter();

        public override string ToString()
        {
            return string.Format(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                this.GetType().Name,
                this.CalcPerimeter(),
                this.CalcSurface());
        }
    }
}
