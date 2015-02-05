
namespace Converter
{
    using System;
    using System.Text;
    public class Converter
    {
        private uint HEX = 16;
        private uint BINARY = 2;

        // Float -> Binary

        public string[] FloatToBinary(float number)
        {
            StringBuilder binary = new StringBuilder();
            byte[] bytes = BitConverter.GetBytes(number);
            Array.Reverse(bytes);
            string stringBytes = BitConverter.ToString(bytes);

            foreach (var current in stringBytes)
            {
                if (Char.IsLetter(current) || Char.IsDigit(current))
                {
                    binary.Append(HexToBinary(current + "").PadLeft(4, '0'));
                }
            }

            string[] result = new string[3];
            result[0] = binary[0].ToString();
            result[1] = binary.ToString().Substring(1, 8);
            result[2] = binary.ToString().Substring(9);

            return result;
        }

        // Decimal <-> Binary
        public string DecimalToBinary(uint number)
        {
            if (number == 0)
                return number.ToString();

            StringBuilder binary = new StringBuilder();

            for (int bit = 0; bit < 32; bit++)
            {
                if (number >> bit == 0)
                    break;
                binary.Insert(0, (number >> bit) & 1);
            }

            return binary.ToString();
        }

        public uint BinaryToDecimal(string binary)
        {
            uint result = 0;

            for (int bit = 0; bit < binary.Length; bit++)
            {
                result *= BINARY;
                result += (byte)char.GetNumericValue(binary[bit]);
            }

            return result;
        }

        public string ShortToBinary(ushort number)
        {
            if (number == 0)
                return new String('0', 16);

            StringBuilder binary = new StringBuilder();

            for (int bit = 0; bit < 16; bit++)
            {
                binary.Insert(0, (number >> bit) & 1);
            }

            return binary.ToString();
        }

        // Decimal <-> Hex

        public string DecimalToHex(uint number)
        {
            if (number == 0)
                return number.ToString();

            StringBuilder hex = new StringBuilder();

            uint remainder;
            char current;
            while (number > 0)
            {
                remainder = number % HEX;

                if (remainder < 10)
                    current = (char)(remainder + '0');
                else
                    current = (char)(remainder + 55);

                hex.Insert(0, current);

                number /= HEX;
            }

            return hex.ToString();
        }

        public uint HexToDecimal(string hex)
        {
            uint result = 0;
            byte currentValue;
            hex = hex.ToUpper();

            for (int current = 0; current < hex.Length; current++)
            {
                result *= HEX;
                if (Char.IsLetter(hex[current]))
                    currentValue = (byte)(hex[current] - 55);
                else
                    currentValue = (byte)(hex[current] - '0');

                result += currentValue;
            }

            return result;
        }

        // Binary <-> Hex

        public string BinaryToHex(string binary)
        {
            uint number = BinaryToDecimal(binary);
            return DecimalToHex(number);
        }

        public string HexToBinary(string hex)
        {
            uint number = HexToDecimal(hex);
            return DecimalToBinary(number);
        }

        // S-base <-> N-base

        public string Convert(string numberToConvert, uint from, uint to)
        {
            uint number = NToDecimal(numberToConvert, from);

            if (number == 0)
                return number.ToString();

            return DecimalToN(to, number);
        }

        public string DecimalToN(uint to, uint number)
        {
            StringBuilder result = new StringBuilder();
            uint remainder;
            char currentLetter;
            while (number > 0)
            {
                remainder = number % to;

                if (remainder < 10)
                    currentLetter = (char)(remainder + '0');
                else
                    currentLetter = (char)(remainder + 55);

                result.Insert(0, currentLetter);

                number /= to;
            }
            return result.ToString();
        }

        public uint NToDecimal(string numberToConvert, uint from)
        {
            uint number = 0;
            byte currentValue;
            numberToConvert = numberToConvert.ToUpper();

            for (int current = 0; current < numberToConvert.Length; current++)
            {
                number *= from;
                if (Char.IsLetter(numberToConvert[current]))
                    currentValue = (byte)(numberToConvert[current] - 55);
                else
                    currentValue = (byte)(numberToConvert[current] - '0');

                number += currentValue;
            }
            return number;
        }
    }
}
