using System;
using System.Collections.Generic;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Complete")) break;

                string[] tokens = input.Split();
                string command = tokens[0];
                if (command.Equals("Make"))
                {
                    string changeCaps = tokens[1];
                    if (changeCaps.Equals("Upper"))
                    {
                        email = email.ToUpper();
                    }
                    else
                    {
                        email = email.ToLower();
                    }
                    Console.WriteLine(email);
                    continue;
                }
                if (command.Equals("GetDomain"))
                {
                    int count = int.Parse(tokens[1]);
                    string temp = email.Substring(email.Length - count);
                    Console.WriteLine(temp);
                    continue;
                }
                if (command.Equals("GetUsername"))
                {
                    int index = email.IndexOf('@');
                    if (index == -1)
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        string username = email.Substring(0, index);
                        Console.WriteLine(username);
                    }
                    continue;
                }
                if (command.Equals("Replace"))
                {
                    char symbol = Convert.ToChar(tokens[1]);
                    while (true)
                    {
                        int index = email.IndexOf(symbol);
                        if (index == -1) break;
                        email = email.Replace(symbol, '-');
                    }
                    Console.WriteLine(email);
                    continue;
                }
                if (command.Equals("Encrypt"))
                {
                    Queue<int> encryptEmail = new Queue<int>();
                    foreach (var symbol in email)
                    {
                        encryptEmail.Enqueue((int)symbol);
                    }
                    Console.WriteLine(string.Join(" ",encryptEmail));
                }
            }
        }
    }
}
