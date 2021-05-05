using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ICall, IBrowsing
    {
        private string number;
        private string url;
        public int Number {
            get
            {
               return int.Parse(this.number);
            }
        }
        public string URL
        {
            get => this.url; 
            set
            {
                var regex = new Regex(@"^[a-z\/:.]+$");
                if (regex.IsMatch(value))
                {
                    this.url = value;
                }
                else
                {
                    throw new AggregateException("Invalid URL!");
                }
            }
        }

        public string Browse()
        {
            return $"Browsing: {this.url}!";
        }

        public string Call()
        {
            return $"Calling... {this.number}";
        }

        public void IsPhoneNumber(string num)
        {
            this.number = IsNumber(num);
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
