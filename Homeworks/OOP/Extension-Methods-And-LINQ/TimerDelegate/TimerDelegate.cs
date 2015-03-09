//Using delegates write a class Timer that can execute certain method at each t seconds.

namespace TimerDelegate
{
    using System;
    using System.Threading;
    class TimerDelegate
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(5, 2, delegate() { Console.WriteLine("tick"); });
            Thread tThread = new Thread(new ThreadStart(t.Run));
            tThread.Start();
        }
    }
}
