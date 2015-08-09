
namespace MobilePhoneComponents
{
    using System;
    public class Display
    {
        private DisplayType displayType;
        private TouchScreenType screenType;
        private double inches;
        private int colors;
        private bool colorsSet = false;
        private bool screenTypeSet = false;


        public Display(DisplayType displayType, double inches)
            : base()
        {
            this.DisplayType = displayType;
            this.Inches = inches;
        }

        public Display(DisplayType displayType, double inches, int colors)
            : this(displayType, inches)
        {
            this.Colors = colors;
            this.colorsSet = true;
        }

        public Display(DisplayType displayType, double inches, TouchScreenType screenType, int colors)
            : this(displayType, inches, colors)
        {
            this.TouchScreenType = screenType;
            this.screenTypeSet = true;
        }

        public DisplayType DisplayType
        {
            get
            {
                return this.displayType;
            }
            private set
            {
                this.displayType = value;
            }
        }

        public TouchScreenType TouchScreenType
        {
            get
            {
                if (!this.screenTypeSet)
                {
                    throw new NullReferenceException();
                }

                return this.screenType;
            }
            private set
            {
                this.screenType = value;
            }
        }

        public double Inches
        {
            get
            {
                return this.inches;
            }
            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException();
                }

                this.inches = value;
            }
        }

        public int Colors
        {
            get
            {
                if (!this.colorsSet)
                {
                    throw new NullReferenceException();
                }

                return this.colors;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.colors = value;
            }
        }

        public override string ToString()
        {
            return String.Format(@"Display: {0}, {1} inches
{2}
{3}", this.DisplayType, this.Inches,
    this.screenTypeSet ? String.Format("Touch screen type: {0}", this.TouchScreenType) : String.Empty,
    this.colorsSet ? String.Format("Colors: {0}", this.Colors) : String.Empty).Trim();
        }
    }

    public enum DisplayType
    {
        CSTN,
        TFT,
        TFD,
        OLED,
        AMOLED,
        LCD
    }

    public enum TouchScreenType
    {
        CAPACITIVE,
        RESISTIVE
    }
}
