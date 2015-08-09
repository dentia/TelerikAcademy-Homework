namespace SizeOperations
{
    using System;

    public class SizeOperations
    {
        public static void Main()
        {
            var initialSize = new Size(10.0, 15.0);
            var sizeAfterRotation = initialSize.GetRotatedSize(35.5);

            Console.WriteLine(initialSize);
            Console.WriteLine(sizeAfterRotation);
        }
    }
}
