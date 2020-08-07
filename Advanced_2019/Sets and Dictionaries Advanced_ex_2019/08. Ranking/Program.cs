using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> examList = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> rankingList = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("end of contests")) break;
                string[] token = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string exam = token[0];
                string password = token[1];
                if (examList.ContainsKey(exam) == false)
                {
                    examList.Add(exam, password);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("end of submissions")) break;
                string[] token = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string exam = token[0];
                string password = token[1];
                string student = token[2];
                int points = int.Parse(token[3]);
                if (examList.ContainsKey(exam) && examList[exam]==password)
                {
                    if (rankingList.ContainsKey(student) == false)
                    {
                        rankingList.Add(student, new Dictionary<string, int>());
                        rankingList[student].Add(exam, points);
                    }else if (rankingList[student].ContainsKey(exam) == false)
                    {
                        rankingList[student].Add(exam, points);
                    }else if (rankingList[student][exam] < points)
                    {
                        rankingList[student][exam] = points;
                    }
                }
            }
            var best = BestCanditate(rankingList);
            Console.WriteLine($"Best candidate is {best.Key} with total {best.Value} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in rankingList.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{student.Key}");
                StringBuilder sb = new StringBuilder();
                foreach (var exam in student.Value.OrderByDescending(p=>p.Value))
                {
                    sb.AppendLine($"#  {exam.Key} -> {exam.Value}");
                }
                Console.Write(sb);
            }
        }

        public  static KeyValuePair<string,int> BestCanditate(Dictionary<string,Dictionary<string,int>> ranking)
        {
            string name = "";
            int maxPoints = 0;
            foreach (var student in ranking)
            {
                int points = 0;
                foreach (var exam in student.Value)
                {
                    points += exam.Value;
                }
                if (points > maxPoints)
                {
                    maxPoints = points;
                    name = student.Key;
                }
            }
            var candidate = new KeyValuePair<string, int>(name, maxPoints);
            return candidate;
        }
    }
}
