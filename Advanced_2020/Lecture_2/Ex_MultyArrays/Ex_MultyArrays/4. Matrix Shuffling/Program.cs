using System;
using System.Linq;
using System.Text;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split()
                 .Select(int.Parse).ToArray();
            int rows = sizeMatrix[0];
            int colms = sizeMatrix[1];
            int[,] matrix = new int[rows, colms];
            FillMatrix(matrix);
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END")) break;
                var tokens = input.Split();
                string command = tokens[0];
                if (command.Equals("swap"))
                {
                    if (ValidCoordinates(tokens, matrix) == false)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    SwapElement(matrix, tokens);
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int colm = 0; colm < colms; colm++)
                {
                    sb.Append(matrix[row, colm]);
                    if (colm < colms - 1)
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }
            Console.Write(sb);
        }

        public static void FillMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int colm = 0; colm < colms; colm++)
                {
                    matrix[row, colm] = currentRow[colm];
                }
            }
        }
        public static void SwapElement(int[,] matrix, string[] tokens)
        {
            int row1 = int.Parse(tokens[1]);
            int colm1 = int.Parse(tokens[2]);
            int row2 = int.Parse(tokens[3]);
            int colm2 = int.Parse(tokens[4]);
            var temp = matrix[row1, colm1];
            matrix[row1, colm1] = matrix[row2, colm2];
            matrix[row2, colm2] = temp;
        }

        public static bool ValidCoordinates(string[] tokens, int[,] matrix)
        {
            if (tokens.Length != 5) return false;
            int row1 = int.Parse(tokens[1]);
            int colm1 = int.Parse(tokens[2]);
            int row2 = int.Parse(tokens[3]);
            int colm2 = int.Parse(tokens[4]);
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            if (row1 < 0 || row2 < 0 || colm1 < 0 || colm2 < 0) return false;
            if (row1 >= rows || row2 >= rows || colm1 >= colms || colm2 >= colms) return false;
            return true;
        }
    }
}
