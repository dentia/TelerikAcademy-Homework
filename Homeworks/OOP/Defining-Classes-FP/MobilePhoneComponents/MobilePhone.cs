
namespace MobilePhoneComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MobilePhone
    {
        private static readonly MobilePhone iPhone6pl = new MobilePhone(
            Manufacturer.APPLE, "iPhone 6 Plus",
            new Battery(BatteryType.Li_Poly, 2915, 384, 24),
            new Display(DisplayType.LCD, 5.5, TouchScreenType.CAPACITIVE, 16000000),
            OS.IOS);

        private string model;
        private Manufacturer manufacturer;
        private Display display;
        private bool displaySet = false;
        private Battery battery;
        private bool batterySet = false;
        private OS oS;
        private bool OSSet = false;
        private List<Call> calls = new List<Call>();

        public MobilePhone(Manufacturer manufacturer, string model)
            : base()
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public MobilePhone(Manufacturer manufacturer, string model, OS os)
            : this(manufacturer, model)
        {
            this.OS = os;
            this.OSSet = true;
        }

        public MobilePhone(Manufacturer manufacturer, string model, Battery battery)
            : this(manufacturer, model)
        {
            this.Battery = battery;
        }

        public MobilePhone(Manufacturer manufacturer, string model, Display display)
            : this(manufacturer, model)
        {
            this.Display = display;
        }

        public MobilePhone(Manufacturer manufacturer, string model, Battery battery, Display display, OS oS)
            : this(manufacturer, model)
        {
            this.Battery = battery;
            this.Display = display;
            this.OS = oS;
        }

        public Manufacturer Manufacturer
        {
            get
            {
                if (this.manufacturer.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.manufacturer;
            }
            private set
            {
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                if (String.IsNullOrEmpty(this.model))
                {
                    throw new NullReferenceException();
                }

                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("model");
                }

                this.model = value;
            }
        }

        public Display Display
        {
            get
            {
                if (this.display.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.display;
            }
            private set
            {
                this.display = value;
                this.displaySet = true;
            }
        }

        public Battery Battery
        {
            get
            {
                if (this.battery.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.battery;
            }
            private set
            {
                this.battery = value;
                this.batterySet = true;
            }
        }

        public OS OS
        {
            get
            {
                if (this.oS.Equals(null))
                {
                    throw new NullReferenceException();
                }

                return this.oS;
            }
            private set
            {
                this.oS = value;
                this.OSSet = true;
            }
        }

        public static MobilePhone IPhone6Plus
        {
            get
            {
                return iPhone6pl;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return new List<Call>(this.calls);
            }
        }

        public void AddCall(Call call)
        {
            this.calls.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.calls.Remove(call);
        }

        public void DeleteCallHistory()
        {
            this.calls.Clear();
        }

        public decimal GetTotalCallPrice(decimal pricePerMinute)
        {
            decimal allCallsInSecs = (decimal)(this.calls.Select(x => x.Duration).Sum());
            return pricePerMinute * (allCallsInSecs / 60.0m);
        }

        public override string ToString()
        {
            return String.Format(@"
{0} {1} {2} {3} {4}", this.Manufacturer, this.Model, 
    this.OSSet ? String.Format("{1}\t(OS: {0})", this.OS, Environment.NewLine) : String.Empty,
    !this.batterySet ? String.Empty : String.Format("{0}{0}{1}",Environment.NewLine,this.Battery.ToString()),
    !this.displaySet ? String.Empty : String.Format("{0}{0}{1}", Environment.NewLine, this.Display.ToString()))
    .Trim();
        }
    }

    public enum Manufacturer
    {
        HTC,
        SAMSUNG,
        LG,
        MOTOROLA,
        APPLE,
        NOKIA,
        SONY,
        LENOVO,
        BLACKBERRY,
        ALCATEL,
        CAT,
        ASUS,
        ACER,
        GOOGLE,
        MICROSOFT,
        HUAWEI,
        XIAOMI,
        Other
    }

    public enum OS
    {
        IOS,
        WINDOWS,
        ANDROID,
        SYMBIAN,
        Other
    }
}
