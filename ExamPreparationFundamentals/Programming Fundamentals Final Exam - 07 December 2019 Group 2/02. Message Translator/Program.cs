using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<command>[A-Z][a-z]{3,})!:\[(?<secretMassage>([a-zA-Z]){8,})\]";
            string patternMassage = @"(?<=\[)[A-Za-z]{8,}";
            string patterCommand = @"(?<=!)[A-Z][a-z]{2,}";
            Regex regex = new Regex(pattern);
            int commandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNumber; i++)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                {
                    string command = Regex.Match(input, patterCommand).Value;
                    string massage = Regex.Match(input, patternMassage).Value;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(command + ": ");
                    int[] massageValue = massage.Select(c => (int)c).ToArray();
                    sb.Append(string.Join(" ", massageValue));
                    Console.WriteLine(sb);
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }

    }
}
