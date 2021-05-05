using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = tokens[0];
            int colms = tokens[1];
            int numOfSquareMatrix = 0;
            char[,] jaggedArray = new char[rows,colms];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var data= string.Concat(input).ToCharArray();
                for (int colm = 0; colm < colms; colm++)
                {
                    jaggedArray[row, colm] = data[colm];
                }
            }
            for (int row = 0; row < jaggedArray.GetLength(0)-1; row++)
            {
                for (int col = 0; col < jaggedArray.GetLength(1)-1; col++)
                {
                    var current = jaggedArray[row, col];
                    var next = jaggedArray[row, col + 1];
                    var bottom = jaggedArray[row + 1, col];
                    var bottomNext = jaggedArray[row + 1, col + 1];
                    if(current==next && next==bottom && bottom==bottomNext)
                    {
                        numOfSquareMatrix++;
                    }
                }
            }
            Console.WriteLine(numOfSquareMatrix);
        }
    }
}
