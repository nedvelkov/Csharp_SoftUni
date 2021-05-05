using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=U\$)(?<username>[A-Z][a-z]{2,})(U\$)(P\@\$)(?<password>[A-Za-z]{5,}[0-9]+)";
            Regex regex = new Regex(pattern);
            int numOfAcc = int.Parse(Console.ReadLine());
            int successfulRegistrationsCount = 0;
            for (int i = 0; i < numOfAcc; i++)
            {
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string username = match.Groups["username"].ToString();
                    string password = match.Groups["password"].ToString();
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: { username}, Password: { password}");
                    successfulRegistrationsCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
