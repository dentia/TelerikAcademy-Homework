namespace Methods
{
    using System;

    /// <summary>
    /// Random methods that need to be refactored
    /// </summary>
    internal class Methods
    {
        /// <summary>
        /// Format modifiers used when printing formatted string
        /// </summary>
        internal enum FormatOptions
        {
            Round,
            Percent,
            AlignRight
        }

        /// <summary>
        /// Positioning of a line netween two points in a 2D space
        /// </summary>
        internal enum Position
        {
            PointsOverlap,
            Horizontal,
            Vertical,
            Other
        }

        /// <summary>
        /// The method calculates the area of a triangle by given sides
        /// </summary>
        /// <returns>Double - the area of the triangle</returns>
        internal static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double semiperimeterMinusSidesFormula = semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC);
            double area = Math.Sqrt(semiperimeterMinusSidesFormula);
            return area;
        }

        /// <summary>
        /// The method takes digit(int) as a parameter and returns it as a word
        /// </summary>
        /// <param name="number">Int - Digit to be returned as s word</param>
        /// <returns>String - word</returns>
        internal static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit.");
            }
        }

        /// <summary>
        /// The method find the largest number of the parameters
        /// </summary>
        /// <param name="elements">Numbers to be compared</param>
        /// <returns>Integer - the largest number</returns>
        internal static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("There should be at least one argument.");
            }

            int maxNumber = int.MinValue;
            for (int ind = 0; ind < elements.Length; ind++)
            {
                maxNumber = Math.Max(maxNumber, elements[ind]);
            }

            return maxNumber;
        }

        /// <summary>
        /// The method prints on the console a number with the chosen format
        /// </summary>
        internal static void PrintAsNumber(object number, FormatOptions format)
        {
            switch (format)
            {
                case FormatOptions.Round:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case FormatOptions.Percent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case FormatOptions.AlignRight:
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid formattiong option.");
            }
        }

        /// <summary>
        /// The method calculates the distance between two points(X,Y) in a 2D space
        /// </summary>
        internal static double CalcDistanceBetweenPoints(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            double substractionProductX = (secondPointX - firstPointX) * (secondPointX - firstPointX);
            double substractionProductY = (secondPointY - firstPointY) * (secondPointY - firstPointY);
            double distance = Math.Sqrt(substractionProductX + substractionProductY);
            return distance;
        }

        /// <summary>
        /// The method returns the positioning in a 2D space of a line, connecting two points(X,Y)
        /// </summary>
        internal static Position GetLinePosition(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            if (firstPointX == secondPointX && firstPointY == secondPointY)
            {
                return Position.PointsOverlap;
            }
            else if (firstPointX == secondPointX)
            {
                return Position.Vertical;
            }
            else if (firstPointY == secondPointY)
            {
                return Position.Horizontal;
            }
            else
            {
                return Position.Other;
            }
        }

        /// <summary>
        /// The method tests all methods, that needed refactoring
        /// </summary>
        internal static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, FormatOptions.Round);
            PrintAsNumber(0.75, FormatOptions.Percent);
            PrintAsNumber(2.30, FormatOptions.AlignRight);

            double firstPointX = 3.0;
            double firstPointY = -1.0;
            double secondPointX = 3.0;
            double secondPointY = 2.5;
            double distance = CalcDistanceBetweenPoints(firstPointX, firstPointY, secondPointX, secondPointY);
            Console.WriteLine(distance);
            Position linePosition = GetLinePosition(firstPointX, firstPointY, secondPointX, secondPointY);
            Console.WriteLine("Connecting line position: " + linePosition);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 3, 11), "Vidin", "gamer, high results");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
