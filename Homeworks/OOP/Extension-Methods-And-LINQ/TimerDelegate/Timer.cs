
namespace TimerDelegate
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();
    public class Timer
    {
        private int mSeconds;
        private byte ticks;
        private TimerEvent tEvenet;
        public Timer(byte ticks, int secs, TimerEvent tE)
        {
            this.Ticks = ticks;
            this.Interval = secs;
            this.Event = tE;
        }

        public byte Ticks
        {
            get
            {
                return this.ticks;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.ticks = value;
            }
        }

        public TimerEvent Event 
        {
            get
            {
                return this.tEvenet;
            }
            set
            {
                this.tEvenet = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.mSeconds;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.mSeconds = value * 1000;
            }
        }

        public void Run()
        {
            while (ticks > 0)
            {
                Thread.Sleep((int)mSeconds);
                --ticks;
                tEvenet();
            }
        }
    }
}
