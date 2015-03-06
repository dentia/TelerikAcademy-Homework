using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneComponents;
using System.Text;
using System.Linq;


namespace Tests
{
    [TestClass]
    public class MobilePhoneTests
    {
        private MobilePhone HTCOneM8 = new MobilePhone(
                   Manufacturer.HTC, "One M8",
                   new Battery(BatteryType.Li_Poly, 2600, 380, 24),
                   new Display(DisplayType.LCD, 5.0, TouchScreenType.CAPACITIVE, 16000000),
                   OS.ANDROID);

        [TestMethod]
        public string TestPhoneCreation()
        {
            StringBuilder testResult = new StringBuilder();

            testResult.AppendLine(String.Format("Manufacturer: {0}", TestManufacturer()));
            testResult.AppendLine(String.Format("Model: {0}", TestModel()));
            testResult.AppendLine(String.Format("Battery: \n{0}", TestBattery()));
            testResult.AppendLine(String.Format("Display: \n{0}", TestDisplay()));
            testResult.AppendLine(String.Format("OS: {0}", TestOS()));

            return testResult.ToString();
        }

        private string TestOS()
        {
            string result = "Passed";
            try
            {
                Assert.AreEqual(OS.ANDROID, HTCOneM8.OS);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        private string TestDisplay()
        {
            StringBuilder batteryTest = new StringBuilder();

            #region displayType
            string result = "Passed";
            try
            {
                Assert.AreEqual(DisplayType.LCD, HTCOneM8.Display.DisplayType);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tDisplay type: " + result);
            #endregion

            #region display_touchScreenType
            result = "Passed";
            try
            {
                Assert.AreEqual(TouchScreenType.CAPACITIVE, HTCOneM8.Display.TouchScreenType);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tTouchscreen type: " + result);
            #endregion

            #region display_inches
            result = "Passed";
            try
            {
                Assert.AreEqual(5.0, HTCOneM8.Display.Inches);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tDisplay inches: " + result);
            #endregion

            #region display_colors
            result = "Passed";
            try
            {
                Assert.AreEqual(16000000, HTCOneM8.Display.Colors);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tDisplay colors: " + result);
            #endregion

            return batteryTest.ToString().TrimEnd();
        }

        private string TestBattery()
        {
            StringBuilder batteryTest = new StringBuilder();

            #region batteryType
            string result = "Passed";
            try
            {
                Assert.AreEqual(BatteryType.Li_Poly, HTCOneM8.Battery.BatteryType);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tBattery type: " + result);
            #endregion

            #region battery_mAh
            result = "Passed";
            try
            {
                Assert.AreEqual(2600, HTCOneM8.Battery.MAh);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tBattery mAh: " + result);
            #endregion

            #region battery_idleHours
            result = "Passed";
            try
            {
                Assert.AreEqual(380.0, HTCOneM8.Battery.HoursIdle);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tBattery idle hours: " + result);
            #endregion

            #region battery_talkHours
            result = "Passed";
            try
            {
                Assert.AreEqual(24.0, HTCOneM8.Battery.HoursTalk);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            batteryTest.AppendLine("\tBattery talk hours: " + result);
            #endregion

            return batteryTest.ToString().TrimEnd();
        }

        private string TestManufacturer()
        {
            string result = "Passed";
            try
            {
                Assert.AreEqual(Manufacturer.HTC, HTCOneM8.Manufacturer);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        private string TestModel()
        {
            string result = "Passed";
            try
            {
                Assert.AreEqual("One M8", HTCOneM8.Model);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        [TestMethod]
        public string TestCalls()
        {
            StringBuilder testResult = new StringBuilder();

            HTCOneM8.AddCall(new Call(new DateTime(2015, 03, 06), new ContactInformation("Nikolay", "+359 882"), 366));
            HTCOneM8.AddCall(new Call(new DateTime(2015, 03, 05), new ContactInformation("Marya", "+359 883"), 101));
            HTCOneM8.AddCall(new Call(new DateTime(2015, 03, 04), new ContactInformation("Lilly", "+359 884"), 244));
            HTCOneM8.AddCall(new Call(new DateTime(2015, 03, 06), new ContactInformation("Nikolay", "+359 882"), 12));

            testResult.AppendLine(String.Format("Adding calls: {0}", TestAddingCalls()));
            testResult.AppendLine(String.Format("\t\tTotal call price: {0:C}", HTCOneM8.GetTotalCallPrice(0.37m)));
            testResult.AppendLine(String.Format("Find longest call: {0}", TestLongestCall()));
            testResult.AppendLine(String.Format("Remove longest call: {0}", TestRemovingLongestCall()));
            testResult.AppendLine(String.Format("\t\tTotal call price: {0:C}", HTCOneM8.GetTotalCallPrice(0.37m)));
            testResult.AppendLine(String.Format("Remove all calls: {0}", TestRemoveAllCall()));
            testResult.AppendLine(String.Format("\t\tTotal call price: {0:C}", HTCOneM8.GetTotalCallPrice(0.37m)));

            return testResult.ToString();
        }

        private string TestRemoveAllCall()
        {
            string result = "Passed";
            HTCOneM8.CallHistory.Clear();

            try
            {
                Assert.AreEqual(0, HTCOneM8.CallHistory.Count);
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        private string TestRemovingLongestCall()
        {
            string result = "Passed";

            Call longest = HTCOneM8.CallHistory
                .OrderByDescending(x => x.Duration)
                .FirstOrDefault();
            HTCOneM8.CallHistory.Remove(longest);

            var longestDuration = HTCOneM8.CallHistory.Max(x => x.Duration);

            try
            {
                Assert.AreEqual(244.0, longestDuration, "longest call removed");
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        private string TestLongestCall()
        {
            string result = "Passed";

            var callDuration = HTCOneM8.CallHistory.Max(x => x.Duration);

            try
            {
                Assert.AreEqual(366.0, callDuration, "longest call duration");
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }

        private string TestAddingCalls()
        {
            string result = "Passed";

            try
            {
                Assert.AreEqual(4, HTCOneM8.CallHistory.Count, "added calls count");
            }
            catch (AssertFailedException exception)
            {
                result = exception.Message;
            }

            return result;
        }
    }
}
