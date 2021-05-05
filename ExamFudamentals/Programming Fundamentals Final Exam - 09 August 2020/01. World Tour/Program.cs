using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string travelPlans = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Travel")) break;
                string[] tokens = input.Split(":",StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                if(command.Equals("Add Stop"))
                {
                    int index = int.Parse(tokens[1]);
                    string stop = tokens[2];
                    if(ValidIndex(index,travelPlans))
                    {
                        travelPlans = travelPlans.Insert(index, stop);
                    }
                    Console.WriteLine(travelPlans);
                    continue;
                }
                if(command.Equals("Remove Stop"))
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if(ValidIndex(startIndex,travelPlans) && ValidIndex(endIndex, travelPlans))
                    {
                        
                        travelPlans = travelPlans.Remove(startIndex, endIndex - startIndex+1);
                    }
                    Console.WriteLine(travelPlans);
                    continue;
                }
                if (command.Equals("Switch"))
                {
                    string oldStop = tokens[1];
                    string newStop = tokens[2];
                    while (true)
                    {
                        int index = travelPlans.IndexOf(oldStop);
                        if (index == -1) break;
                        travelPlans = travelPlans.Replace(oldStop, newStop);
                    }
                    Console.WriteLine(travelPlans);
                    continue;
                }
                Console.WriteLine(travelPlans);
                
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {travelPlans}");

        }

        public static bool ValidIndex(int index,string word)
        {
            if (index >= 0 && index < word.Length) return true;

            return false;
        }
    }
}
