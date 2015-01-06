//The gravitational field of the Moon is approximately 17% of that on the Earth.
//Write a program that calculates the weight of a man on the moon by a given weight on the Earth.

namespace GravitationOnMoon
{
    using System;
    class GravitationOnMoon
    {
        //The moon is 1/4 the size of Earth, so the moon's gravity is much less 
        //than the earth's gravity, 83.3% (or 5/6) less to be exact.
        const double MOON_GRAVITY = 0.17;
        static void Main(string[] args)
        {
            Console.Write("Enter your weight: ");
            double weight = double.Parse(Console.ReadLine());
            double moonWeight = weight * MOON_GRAVITY;

            Console.WriteLine("You'll weight {0:F2}kg on the Moon.", moonWeight);
        }
    }
}
