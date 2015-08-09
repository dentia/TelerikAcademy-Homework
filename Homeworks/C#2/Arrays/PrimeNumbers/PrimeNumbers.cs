//Write a program that finds all prime numbers in the range [1...10 000 000]. 
//Use the sieve of Eratosthenes algorithm.

namespace PrimeNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    class PrimeNumbers
    {
        static int RANGE = 10000000;
        static void Main(string[] args)
        {
            Console.WriteLine(@"
The output of this program will take too long printing on the console.
In order to shorten that time, we won't use the console. After you
start the program, a .txt file called ""primesToM"" will appear on your
Desktop with all the prime numbers in range [1...{0}].", RANGE);

            bool[] notPrime = new bool[RANGE + 1];
            SiftPrimes(notPrime);

            var primes = notPrime.Select((val, ind) => new { Index = ind, Value = val })
               .Where(num => num.Value == false)
               .Select(num => num.Index.ToString());

            var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fullFileName = Path.Combine(desktopFolder, "primesToM.txt");

            System.IO.File.WriteAllLines(fullFileName, primes.ToArray());
        }

        private static void SiftPrimes(bool[] notPrime)
        {
            notPrime[0] = true;
            notPrime[1] = true;

            for (int number = 2; number <= RANGE; number++)
                if (!notPrime[number])
                    for (int notPrimeIndex = number * 2; notPrimeIndex <= RANGE; notPrimeIndex += number)
                        notPrime[notPrimeIndex] = true;
        }
    }
}
