namespace Utils.TextReader
{
    using System;
    using System.Collections.Generic;

    public interface IReader<T>
    {
        IEnumerable<T> ReadList(Predicate<string> shouldStopReading, Predicate<string> isValidEntry);

        T ReadOne();
    }
}
