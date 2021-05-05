using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StacionaryPhone : ICall
    {
        private string number;
        public int Number => int.Parse(this.number);

        public string Call()
        {
            return $"Dialing... {this.number}";
        }
        public void IsPhoneNumber(string num)
        {
            this.number=IsNumber(num);
        }

        private string IsNumber(string num)
        {
            for (int j = 0; j < num.Length; j++)
            {
                var currentChar = num[j];
                if (Char.IsDigit(currentChar) == false)
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            return num;
        }
    }
}
