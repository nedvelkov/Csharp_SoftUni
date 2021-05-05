using System;
using System.Linq;
using System.Text;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            FillMatrix(matrix);
            AnalizeMatrix(matrix);
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End")) break;
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int row=int.Parse(tokens[1]);
                int colm = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (ValidCoordinate(row, colm, matrix) == false) continue; 
                switch (command)
                {
                    case"Add":
                        matrix[row][colm] += value;
                        break;

                    case "Subtract":
                        matrix[row][colm] -= value;
                        break;
                }

            }
            PrintMatrix(matrix);
        
        }

        public static void PrintMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                sb.AppendLine(string.Join(" ", matrix[i]));
            }
            Console.Write(sb);
        }

        public static bool ValidCoordinate(int row, int colm, double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            if (row < 0 || row >= rows) return false;
            int colms = matrix[row].Length;
            if (colm < 0 || colm >= colms) return false;

            return true;
        }

        public static void AnalizeMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int row = 0; row < rows-1; row++)
            {
                int currentRowLenght = matrix[row].Length;
                int nextRowLenght = matrix[row + 1].Length;
                if (currentRowLenght == nextRowLenght)
                {
                    for (int colm = 0; colm < currentRowLenght; colm++)
                    {
                        matrix[row][colm]*=2;
                        matrix[row + 1][colm]*=2;
                    }
                }
                else
                {
                    for (int colm = 0; colm < currentRowLenght; colm++)
                    {
                        var current = matrix[row][colm];
                        if (current != 0)
                        {
                            matrix[row][colm] = current / 2;
                        }
                    }
                    for (int colm = 0; colm < nextRowLenght; colm++)
                    {
                        var next = matrix[row + 1][colm];
                        if (next != 0)
                        {
                            matrix[row + 1][colm] = next / 2;
                        }
                    }
                    
                    
                }
            }
        }

        public static void FillMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split()
                    .Select(long.Parse).ToArray();
                matrix[row] = new double[currentRow.Length];
                for (int colm = 0; colm < currentRow.Length; colm++)
                {
                    matrix[row][colm] = currentRow[colm];
                }
            }
        }
    }
}
