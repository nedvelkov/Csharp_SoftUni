using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] squreMatrix = new int[size][];
            int sumPrimary = 0;
            int sumSecondary = 0;
            for (int i = 0; i < size; i++)
            {
                squreMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            for (int row = 0; row < size; row++)
            {
                for (int colm = 0; colm < size; colm++)
                {
                    int number = squreMatrix[row][colm];
                    if(row==colm)
                    {
                        sumPrimary += number;
                    }
                    if (row == size - colm - 1)
                    {
                        sumSecondary += number;
                    }
                }
            }
            Console.WriteLine($"{Math.Abs(sumPrimary-sumSecondary)}");
        }
    }
}
