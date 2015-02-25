//Write a class GSMTest to test the GSM class:
//Create an array of few instances of the GSM class.
//Display the information about the GSMs in the array.
//Display the information about the static property IPhone4S.

namespace GSMClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class GSMTest
    {
        List<MobilePhone> phones = new List<MobilePhone>();

        public void AddPhone(MobilePhone phone)
        {
            this.phones.Add(phone);
        }

        public void LoadSomePhones()
        {
            MobilePhone[] phones = {
                new MobilePhone(
                Manufacturer.HTC, "One M8", 
                new Battery(BatteryType.Li_Poly, 2600), 
                new Display(DisplayType.LCD, 5.0),
                OS.ANDROID)
                ,
                new MobilePhone(
                Manufacturer.SAMSUNG, "Galaxy S4"),
                
                new MobilePhone(
                Manufacturer.LENOVO, "P70", 
                new Display(DisplayType.LCD, 5.0)),
                
                new MobilePhone(
                Manufacturer.MICROSOFT, "Lumia 535", 
                OS.WINDOWS)};

            foreach (var phone in phones)
            {
                this.AddPhone(phone);
            }

            this.AddPhone(MobilePhone.IPhone6Plus);
        }

        public void PrintPhones()
        {
            StringBuilder result = new StringBuilder();
            foreach (var phone in this.phones)
            {
                result.AppendLine(phone.ToString());
                result.AppendLine(new String('_', 20));
            }

            Console.WriteLine(result);
        }
    }
}
