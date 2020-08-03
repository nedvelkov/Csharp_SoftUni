using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsList = new Dictionary<string, List<double>>();
            int numGrades = int.Parse(Console.ReadLine());
            for (int i = 0; i < numGrades; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string nameStudent = tokens[0];
                double grade = double.Parse(tokens[1]);
                if (studentsList.ContainsKey(nameStudent) == false)
                {
                    studentsList.Add(nameStudent, new List<double>());
                }
                studentsList[nameStudent].Add(grade);
            }
            foreach (var kvp in studentsList)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var grade in kvp.Value)
                {
                    sb.Append($"{grade:f2} ");
                }
                Console.WriteLine($"{kvp.Key} -> {sb}(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
