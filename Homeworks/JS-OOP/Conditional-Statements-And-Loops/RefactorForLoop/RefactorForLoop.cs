namespace RefactorForLoop
{
    public class RefactorForLoop
    {
        public static void Main()
        {
            /*
                int i=0;
                for (i = 0; i < 100;)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine(array[i]);
                        if ( array[i] == expectedValue )
                        {
                            i = 666;
                        }
                        i++;
                    }
                    else
                    {
                    Console.WriteLine(array[i]);
                    i++;
                    }
                }
                // More code here
                if (i == 666)
                {
                    Console.WriteLine("Value Found");
                }
             */
        }

        public static void Loop(int[] numbers, int expectedValue)
        {
            bool isFound = false;

            for (int ind = 0; ind < numbers.Length; ind++)
            {
                int currentValue = numbers[ind];

                if (currentValue == expectedValue)
                {
                    isFound = true;
                }

                System.Console.WriteLine(currentValue);
            }

            if (isFound)
            {
                System.Console.WriteLine("Value Found");
            }
        }
    }
}
