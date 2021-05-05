using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] chesboard = new char[rows][];
            FillMatrix(chesboard);
            char[][] matrix = new char[rows][];
            FillMatrix(chesboard, matrix);
            List<Knight> listKnights = new List<Knight>();
            while (true)
            {
                FindKnights(matrix, listKnights);
                listKnights = listKnights.OrderByDescending(a => a.Attacs).ToList();
                var knight = listKnights[0];
                if (knight.Attacs > 0)
                {
                    listKnights.Clear();
                    int row = knight.Row;
                    int colm = knight.Colm;
                    matrix[row][colm] = '0';
                }
                else
                {
                    break;
                }
            }
            List<Knight> knights = new List<Knight>();
            FindKnights(chesboard, knights);
            Console.WriteLine($"{knights.Count-listKnights.Count}");
        }

        public static void FindKnights(char[][] matrix, List<Knight> listKnights)
        {
            int rows = matrix.Length;
            for (int i = 0; i < rows; i++)
            {
                int colms = matrix[i].Length;
                for (int j = 0; j < colms; j++)
                {
                    char current = matrix[i][j];
                    if (current.Equals('K'))
                    {
                        Knight knight = new Knight(i,j);
                        knight.FillAttacs(matrix);
                        listKnights.Add(knight);
                    }
                }
            }
        }

        public static void FillMatrix(char[][] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                var tokens = Console.ReadLine().ToCharArray();
                matrix[i] = new char[tokens.Length];
                for (int j = 0; j < tokens.Length; j++)
                {
                    matrix[i][j] = tokens[j];
                }
            }
        }

        public static void FillMatrix(char[][] orgMatrix,char[][] copyMatrix)
        {
            int rows = orgMatrix.Length;
            for (int i = 0; i < rows; i++)
            {
                int colms = orgMatrix[i].Length;
                copyMatrix[i] = new char[colms];
                for (int j = 0; j < colms; j++)
                {
                    copyMatrix[i][j] = orgMatrix[i][j];
                }
            }
        }

    }

    class Knight
    {
        public int Row { get; set; }
        public int Colm { get; set; }
        public int Attacs { get; private set; }
        public Knight()
        {

        }
        public Knight(int row,int colm):this()
        {
            this.Row = row;
            this.Colm = colm;
        }
        public void FillAttacs(char[][] chesboard)
        {
            for (int i = 0; i < 8; i++)
            {
                int row;
                int colm;
                switch (i)
                {
                    case 0:
                        row = this.Row + 2;
                        colm = this.Colm + 1;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 1:
                        row = this.Row + 1;
                        colm = this.Colm + 2;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 2:
                        row = this.Row - 1;
                        colm = this.Colm + 2;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 3:
                        row = this.Row - 2;
                        colm = this.Colm + 1;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 4:
                        row = this.Row - 2;
                        colm = this.Colm - 1;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 5:
                        row = this.Row -1 ;
                        colm = this.Colm -2 ;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 6:
                        row = this.Row + 1;
                        colm = this.Colm - 2;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                    case 7:
                        row = this.Row + 2;
                        colm = this.Colm - 1;
                        if (ValidMove(row, colm, chesboard))
                        {
                            char element = chesboard[row][colm];
                            if (element.Equals('K')) this.Attacs++;
                        }
                        break;
                }
            }
        }

        private bool ValidMove(int row,int colm,char[][] array)
        {
            int rows = array.GetLength(0);
            if (row < 0 || row >= rows) return false;
            int colms = array[row].Length;
            if (colm < 0 || colm >= colms) return false;

            return true;
        }
    }
}
