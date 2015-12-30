using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Rectangle(3,4));
            shapes.Add(new Rhombus(5,6));
            shapes.Add(new Circle(7));

            shapes.ForEach(shape => Console.WriteLine(shape + Environment.NewLine 
                + shape.CalculateArea() + Environment.NewLine 
                + shape.CalculatePerimeter()+ Environment.NewLine));
        }
    }
}
