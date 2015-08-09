
namespace MobilePhoneComponents
{
    using System;
    public class Battery
    {
        private BatteryType batteryType;
        private int mAh;
        private double idleHours;
        private double talkHours;
        private bool idleSet = false;
        private bool talkSet = false;

        public Battery(BatteryType batteryType, int mAh)
            : base()
        {
            this.BatteryType = batteryType;
            this.MAh = mAh;
        }

        public Battery(BatteryType batteryType, int mAh, double idleHours, double talkHours)
            : this(batteryType, mAh)
        {
            this.HoursIdle = idleHours;
            this.HoursTalk = talkHours;
            this.idleSet = true;
            this.talkSet = true;
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }

        public double HoursIdle
        {
            get
            {
                if (!this.idleSet)
                {
                    throw new NullReferenceException();
                }

                return this.idleHours;
            }
            private set
            {
                this.idleHours = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                if (!this.talkSet)
                {
                    throw new NullReferenceException();
                }

                return this.talkHours;
            }
            private set
            {
                this.talkHours = value;
            }
        }
        public int MAh
        {
            get
            {
                return this.mAh;
            }
            private set
            {
                this.mAh = value;
            }
        }

        public override string ToString()
        {
            return String.Format(@"
Battery: {0} {1} mAh
{2}
{3}
", this.BatteryType, this.MAh,
                this.talkSet ? String.Format("Talk time:  {0}h", this.HoursTalk) : String.Empty,
                this.idleSet ? String.Format("Stand-by:   {0}h", this.HoursIdle) : String.Empty).Trim();
        }
    }

    public enum BatteryType
    {
        Li_Poly,
        Li_Ion,
        NiCd,
        NiMH
    }
}
