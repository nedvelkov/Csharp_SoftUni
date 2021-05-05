using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numCollection = Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (true)
            {
                var command = Console.ReadLine();
                if (command.Equals("end")) break;
                Action<int[]> appliedArithmetic;
                switch (command)
                {
                    case"add":
                        appliedArithmetic = new Action<int[]>(AddOne);
                        break;
                    case "multiply":
                        appliedArithmetic = new Action<int[]>(Multiply);
                        break;

                    case "subtract":
                        appliedArithmetic = new Action<int[]>(Substract);
                        break;
                    default:
                        appliedArithmetic = new Action<int[]>(l => Console.WriteLine(string.Join(" ", l)));
                        break;
                }
                appliedArithmetic(numCollection);

            }
        }

        public static void AddOne(int[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i]++;
            }
        }

        public static void Multiply(int[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                int num = collection[i];
                collection[i] = num * 2;
            }
        }

        public static void  Substract(int[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i]--;
            }
        }


    }
}
