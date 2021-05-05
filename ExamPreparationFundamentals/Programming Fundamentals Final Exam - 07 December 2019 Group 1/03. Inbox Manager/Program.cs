using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> emailList = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Statistics")) break;
                string[] tokens = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string username = tokens[1];
                if (command.Equals("Add"))
                {
                    if (emailList.ContainsKey(username) == false)
                    {
                        emailList.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    continue;
                }
                if (command.Equals("Send"))
                {
                    string email = tokens[2];
                    if (emailList.ContainsKey(username))
                    {
                        emailList[username].Add(email);
                    }
                    continue;
                }
                if (command.Equals("Delete"))
                {
                    if (emailList.ContainsKey(username)==false)
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                    else
                    {
                        emailList.Remove(username);
                    }
                    continue;
                }
            }
            Console.WriteLine($"Users count: {emailList.Count}");
            foreach (var user in emailList.OrderByDescending(e=>e.Value.Count))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(user.Key);
                foreach (var email in user.Value)
                {
                    sb.AppendLine($"- {email}");
                }
                Console.Write(sb);
            }
        }
    }
}
