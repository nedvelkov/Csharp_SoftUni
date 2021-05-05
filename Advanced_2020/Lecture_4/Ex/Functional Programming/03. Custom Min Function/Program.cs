using System;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokkens = Console.ReadLine().Split();
            Func<string[], int> funcMinNum = new Func<string[], int>(SmallestNum);
            Console.WriteLine(funcMinNum(tokkens));
        }

        public static int SmallestNum(string[] input)
        {
            int smallestNum = int.MaxValue;
            foreach (var item in input)
            {
                int num = int.Parse(item);
                if (num < smallestNum)
                {
                    smallestNum = num;
                }
            }





            return smallestNum;
        }
    }
}
