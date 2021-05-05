using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatriz = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int rows = sizeMatriz[0];
            int colms = sizeMatriz[1];
            string text = Console.ReadLine();
            Queue<char> textAsQueue = new Queue<char>(text);
            char[,] matrix = new char[rows, colms];
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int colm = 0; colm < colms; colm++)
                    {
                        char current = textAsQueue.Dequeue();
                        matrix[row, colm] = current;
                        textAsQueue.Enqueue(current);
                    }
                }
                else
                {
                    for (int colm = colms-1; colm >= 0; colm--)
                    {
                        char current = textAsQueue.Dequeue();
                        matrix[row, colm] = current;
                        textAsQueue.Enqueue(current);
                    }
                }
            }
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                
                for (int colm = 0; colm < colms; colm++)
                {
                    sb.Append(matrix[row, colm]);
                }
                sb.AppendLine();
            }
            Console.Write(sb);
        }
    }
}
