using System;

namespace CohesionAndCoupling
{
    using CohesionAndCoupling.Interfaces;

    class UtilsExamples
    {
        static void Main()
        {
            IMathUtility mathUtility = new MathUtils();
            IFileUtility fileUtility = new FileUtils();

            Console.WriteLine(fileUtility.GetFileExtension("example"));
            Console.WriteLine(fileUtility.GetFileExtension("example.pdf"));
            Console.WriteLine(fileUtility.GetFileExtension("example.new.pdf"));

            Console.WriteLine(fileUtility.GetFileNameWithoutExtension("example"));
            Console.WriteLine(fileUtility.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(fileUtility.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                mathUtility.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                mathUtility.CalcDistance3D(5, 2, -1, 3, -6, 4));

            mathUtility.Width = 3;
            mathUtility.Height = 4;
            mathUtility.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", mathUtility.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", mathUtility.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", mathUtility.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", mathUtility.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", mathUtility.CalcDiagonalYZ());
        }
    }
}
