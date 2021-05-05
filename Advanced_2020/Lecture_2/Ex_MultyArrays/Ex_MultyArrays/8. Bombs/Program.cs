using System;
using System.Linq;
using System.Text;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            FillMatrix(matrix);
            var bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            DetonateBombs(matrix, bombs);
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int alive= FindAlive(matrix);
            int sum = SumAlive(matrix);
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Alive cells: {alive}");
            sb.AppendLine($"Sum: {sum}");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = matrix[i, j];
                    sb.Append(current);
                    if (j < colms - 1)
                    {
                        sb.Append(" ");
                    }
                    
                }
                sb.AppendLine();
            }
            Console.Write(sb);
        }

        private static int SumAlive(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = matrix[i, j];
                    if (current > 0) sum+=current;
                }
            }
            return sum;
        }

        private static int FindAlive(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            int alive = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = matrix[i, j];
                    if (current > 0) alive++;
                }
            }
            return alive;
        }

        public static void DetonateBombs(int[,] matrix, string[] bombs)
        {
            foreach (var coordinate in bombs)
            {
                var token = coordinate.Split(",");
                int row = int.Parse(token[0]);
                int colm = int.Parse(token[1]);
                if (ValidCoordinate(row, colm, matrix))
                {
                    Detonate(row, colm, matrix);
                }
            }
        }

        private static void Detonate(int bombRow, int bombColm, int[,] matrix)
        {
            
            int bombPower = matrix[bombRow, bombColm];
            if (bombPower > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int row;
                    int colm;
                    switch (i)
                    {
                        case 0:
                            row = bombRow - 1;
                            colm = bombColm - 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt >0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 1:
                            row = bombRow - 1;
                            colm = bombColm;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt > 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 2:
                            row = bombRow - 1;
                            colm = bombColm + 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt > 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 3:
                            row = bombRow;
                            colm = bombColm + 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt >0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 4:
                            row = bombRow + 1;
                            colm = bombColm + 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt > 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 5:
                            row = bombRow + 1;
                            colm = bombColm;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt > 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 6:
                            row = bombRow + 1;
                            colm = bombColm - 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt > 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                        case 7:
                            row = bombRow;
                            colm = bombColm - 1;
                            if (ValidCoordinate(row, colm, matrix))
                            {
                                int elemnt = matrix[row, colm];
                                if (elemnt >= 0) matrix[row, colm] -= bombPower;
                            }
                            break;
                    }
                }
                matrix[bombRow, bombColm] -= bombPower;
            }

        }

        public static bool ValidCoordinate(int row,int colm, int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            if (row < 0 || row >= rows) return false;
            if (colm < 0 || colm >= colms) return false;


            return true;
        }
        public static void FillMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (int colm = 0; colm < currentRow.Length; colm++)
                {
                    matrix[row,colm] = currentRow[colm];
                }
            }
        }
    }
}
