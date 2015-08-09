
namespace TimerEvent
{
    using System;
    using System.Threading;

    public delegate void IntervalPassedEventHandler(object sender, EventArgs e);
    class Timer
    {
        private int interval;
        private int ticks;

        public Timer(int intervalInSeconds)
        {
            this.Interval = intervalInSeconds;
            
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.interval = value * 1000;
            }
        }


        public int Ticks
        {
            get
            {
                return this.interval;
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

        protected void Tick()
        {
            if (this.IntervalPassed != null)
            {
                IntervalPassed(this, null);
            }
        }

        public event IntervalPassedEventHandler IntervalPassed;
        public void Run()
        {
            Thread th = new Thread(() =>
            {
                while (this.Ticks > 0)
                {
                    Thread.Sleep(this.Interval);
                    Tick();
                }
            });

            th.Start();
        }
    }
}
