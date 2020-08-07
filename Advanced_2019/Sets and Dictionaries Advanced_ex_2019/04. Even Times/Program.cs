using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numInputs = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>();
            for (int i = 0; i < numInputs; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (nums.ContainsKey(number) == false)
                {
                    nums.Add(number, 0);
                }
                nums[number]++;
            }
            foreach (var number in nums)
            {
                if (number.Value == 2) Console.WriteLine(number.Key);
            }
        }
    }
}
