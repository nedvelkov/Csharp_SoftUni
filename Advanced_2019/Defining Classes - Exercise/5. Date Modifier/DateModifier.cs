using System;
using System.Globalization;

namespace _5._Date_Modifier
{
    public class DateModifier
    {
        public static void DaysBetweenDates(string dateAsString1, string dateAsString2)
        {
            string pattern = "yyyy MM dd";
            DateTime date1 = DateTime.ParseExact(dateAsString1, pattern, CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(dateAsString2, pattern, CultureInfo.InvariantCulture);
            var days = date2.Subtract(date1);
            int result = Math.Abs(days.Days);
            Console.WriteLine(result);
        }
    }
}
