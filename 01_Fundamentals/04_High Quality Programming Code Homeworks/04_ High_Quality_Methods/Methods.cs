using System;

namespace Methods
{
    using System.CodeDom;

    class Methods
    {
        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigitString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Methods.OnSameXAxis(3,3,out horizontal);
            Console.WriteLine("Horizontal? " + horizontal);
            Methods.OnSameXAxis(-1, 2.5, out vertical);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter, 
                stella, 
                peter.IsOlderThan(stella));
        }

        /// <summary>
        /// Calculates triangle area
        /// </summary>
        /// <param name="a">
        /// Side A.
        /// </param>
        /// <param name="b">
        /// Side B.
        /// </param>
        /// <param name="c">
        /// Side C.
        /// </param>
        /// <returns>
        /// Returns the the area of the triangle.
        /// </returns>
        /// <exception cref="ArgumentException">Throws ArgumentException if sides supplied do not form a valid triangle.
        /// </exception>
        private static double CalculateTriangleArea(
            double a,
            double b,
            double c)
        {
            if (a <= 0 ||
                b <= 0 ||
                c <= 0)
            {
                throw new ArgumentException("Sides of a triangle cannot be less or equal to zero.");
            }
            if ((a + b) < c ||
                (a + c) < b ||
                (b + c) < a)
            {
                throw new ArgumentException("Supplied sides do not form a valid triangle.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        /// <summary>
        /// Converts the digit supplied to a string representing that digit.
        /// </summary>
        /// <param name="number">
        /// Digit for conversion.
        /// </param>
        /// <returns>
        /// The word for the digit supplied.
        /// </returns>
        /// <exception cref="ArgumentException">Throws ArgumentException if number supplied is not a single digit (range 0-9)
        /// </exception>
        private static string NumberToDigitString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("Invalid number supplied.");
            }
        }

        /// <summary>
        /// Finds the maximal element in the supplied array.
        /// </summary>
        /// <param name="elements">
        /// Array to search in.
        /// </param>
        /// <returns>
        /// The maximal element of the supplied array.
        /// </returns>
        /// <exception cref="ArgumentNullException"> Throws ArgumentNullException if the array supplied is equal to null.
        /// </exception>
        /// <exception cref="ArgumentException"> Throws ArgumentException if the array supplied has zero elements.
        /// </exception>
        private static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Supplied array cannot be null");
            }
            if (elements.Length == 0)
            {
                throw new ArgumentException("Supplied array cannot be empty");
            }

            int max = elements[0];
            int arrayLenght = elements.Length;
            for (int i = 1; i < arrayLenght; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints the number supplied in the chosen format.
        /// </summary>
        /// <param name="number">
        /// Number for printing.
        /// </param>
        /// <param name="format">
        /// The format in which to print the number.
        /// </param>
        /// <exception cref="NotSupportedException">Throws NotSupportedException if the supplied format is not supported.
        /// </exception>
        private static void PrintAsNumber(
            object number,
            string format)
        {
            switch (format)
            {
                case "f":
                    {
                        Console.WriteLine("{0:f2}", number);
                        break;
                    }
                case "%":
                    {
                        Console.WriteLine("{0:p0}", number);
                        break;
                    }
                case "r":
                    {
                        Console.WriteLine("{0,8}", number);
                        break;
                    }
                default:
                    throw new NotSupportedException("Supplied format not supported.");
            }
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="x1">
        /// X coordinate of first point.
        /// </param>
        /// <param name="y1">
        /// Y coordinate of first point.
        /// </param>
        /// <param name="x2">
        /// X coordinate of second point.
        /// </param>
        /// <param name="y2">
        /// Y coordinate of second point.
        /// </param>
        /// <returns>
        /// The distance between the two supplied points.
        /// </returns>
        private static double CalculateDistance(
            double x1,
            double y1,
            double x2,
            double y2)
        {
            double distance = Math.Sqrt(
                (x2 - x1) * (x2 - x1) + 
                (y2 - y1) * (y2 - y1));

            return distance;
        }

        /// <summary>
        /// Checks if two points are on the same axis.
        /// </summary>
        /// <param name="coordinate1">
        /// The x 1.
        /// </param>
        /// <param name="coordinate2">
        /// The x 2.
        /// </param>
        /// <param name="onSameAxis">
        /// Will be true if the two coordinates are on the same axis.
        /// </param>
        private static void OnSameXAxis(
            double coordinate1,
            double coordinate2,
             out bool onSameAxis)
        {
            onSameAxis = coordinate1 == coordinate2;
        }
    }
}
