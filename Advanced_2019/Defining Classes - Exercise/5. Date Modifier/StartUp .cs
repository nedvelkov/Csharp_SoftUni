using System;

namespace _5._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateAsString1 = Console.ReadLine();
            string dateAsString2 = Console.ReadLine();
            DateModifier.DaysBetweenDates(dateAsString1, dateAsString2);
        }
    }
}
