using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = parameters[0];
            int colms = parameters[1];
            int[,] jaggedArray = new int[rows, colms];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int colm = 0; colm < colms; colm++)
                {
                    jaggedArray[row, colm] = currentRow[colm];
                }
            }
            List<Matrix> listMatrix = new List<Matrix>();
            for (int row = 0; row <= rows - 3; row++)
            {
                for (int colm = 0; colm <= colms - 3; colm++)
                {
                    Matrix matrix = new Matrix();
                    matrix.Array = SquareArray(jaggedArray, row, colm);
                    matrix.Sum();
                    listMatrix.Add(matrix);
                }
            }

            if (listMatrix.Count != 0)
            {
                var result = listMatrix.OrderByDescending(m => m.SumMatrix).ToList()[0];
                Console.WriteLine(result);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Sum = {SumArray(jaggedArray)}");
                for (int row = 0; row < jaggedArray.GetLength(0); row++)
                {
                    for (int colm = 0; colm < jaggedArray.GetLength(1); colm++)
                    {
                        int num = jaggedArray[row,colm];
                        sb.Append(num.ToString());
                        if (colm < jaggedArray.GetLength(1)-1)
                        {
                            sb.Append(" ");
                        }
                    }
                    if (row < jaggedArray.GetLength(0)-1)
                    {
                        sb.AppendLine();
                    }
                }
                Console.WriteLine(sb);

            }
        }

        public static int[][] SquareArray(int[,] jaggedArray, int startRow, int startColm)
        {
            int[][] array = new int[3][];
            
            for (int row = 0; row < 3; row++)
            {
                array[row] = new int[3];
                int currentColm = startColm;
                for (int colm = 0; colm < 3; colm++)
                {
                    array[row][colm] = jaggedArray[startRow, currentColm];
                    currentColm++;
                }
                startRow++;
            }
            return array;
        }
        public static int SumArray(int[,] array)
        {
            int sum = 0;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int colm = 0; colm < array.GetLength(1); colm++)
                {
                    sum += array[row, colm];
                }
            }
            return sum;
        }
    }


    class Matrix
    {
        public int SumMatrix { get; private set; }
        public int[][] Array { get; set; }
        public Matrix()
        {
            this.Array = new int[3][];
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < this.Array.Length; i++)
            {
                for (int j = 0; j < this.Array.Length; j++)
                {
                    sum += this.Array[i][j];
                }
            }
            this.SumMatrix = sum;
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sum = {this.SumMatrix}");
            for (int row = 0; row < 3; row++)
            {
                for (int colm = 0; colm < 3; colm++)
                {
                    int num = this.Array[row][colm];
                    sb.Append(num.ToString());
                    if (colm < 2)
                    {
                        sb.Append(" ");
                    }
                }
                if (row < 2)
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}
