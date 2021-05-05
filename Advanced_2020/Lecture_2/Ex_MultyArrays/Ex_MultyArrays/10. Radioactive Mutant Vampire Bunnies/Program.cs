using System;
using System.Linq;
using System.Text;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = Console.ReadLine().Split()
                 .Select(int.Parse).ToArray();
            var rows = sizeMatrix[0];
            var colms = sizeMatrix[1];
            var fild = new char[rows, colms];
            var copyFild = new char[rows, colms];
            FillMatrix(fild);
            var moves = Console.ReadLine().ToCharArray();
            Player player = FindPlayer(fild);
            foreach (var direction in moves)
            {
                player.MovePlayer(direction, fild);
                MoveBunnies(fild, copyFild);
                int row = player.Row;
                int colm = player.Colm;
                if (fild[row, colm] == 'B')
                {
                    player.Eaten = true;
                    break;
                }
                if (player.ExitFild) break;
            }
            PrintMatrix(fild);
            if (player.Eaten && player.ExitFild==false)
            {
                Console.WriteLine($"dead: {player.Row} {player.Colm}");
            }
            else
            {
                Console.WriteLine($"won: {player.Row} {player.Colm}");
            }
        }
        public static void PrintMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = matrix[i, j];
                    sb.Append(current);
                }
                sb.AppendLine();
            }
            Console.Write(sb);
        }
        public static void MoveBunnies(char[,] fild, char[,] copyFild)
        {
            int rows = fild.GetLength(0);
            int colms = fild.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = fild[i, j];
                    if (current.Equals('B'))
                    {
                        CopyBunny(i, j, copyFild);
                    }
                }
            }
            MergeFilds(fild, copyFild);
        }

        private static void MergeFilds(char[,] fild, char[,] copyFild)
        {
            int rows = fild.GetLength(0);
            int colms = fild.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = copyFild[i, j];
                    var fildCurrent = fild[i, j];
                    if (current.Equals('B'))
                    {
                        fild[i, j] = 'B';
                    }
                }
            }
        }

        private static void CopyBunny(int row, int col, char[,] copyFild)
        {
            for (int i = 0; i < 4; i++)
            {
                int nextRow;
                int nextColm;
                switch (i)
                {
                    case 0: //up
                        nextRow = row - 1;
                        nextColm = col;
                        if (ValidCoordinate(nextRow, nextColm, copyFild))
                        {
                            copyFild[nextRow, nextColm] = 'B';
                        }
                        break;
                    case 1: //down
                        nextRow = row + 1;
                        nextColm = col;
                        if (ValidCoordinate(nextRow, nextColm, copyFild))
                        {
                            copyFild[nextRow, nextColm] = 'B';
                        }
                        break;
                    case 2: //right
                        nextRow = row;
                        nextColm = col+1;
                        if (ValidCoordinate(nextRow, nextColm, copyFild))
                        {
                            copyFild[nextRow, nextColm] = 'B';
                        }
                        break;
                    case 3: //left
                        nextRow = row ;
                        nextColm = col-1;
                        if (ValidCoordinate(nextRow, nextColm, copyFild))
                        {
                            copyFild[nextRow, nextColm] = 'B';
                        }
                        break;
                }
            }
        }

        private static bool ValidCoordinate(int row,int colm,char[,] fild)
        {
            int rows = fild.GetLength(0);
            int colms = fild.GetLength(1);
            if (row < 0 || row >= rows) return false;
            if (colm < 0 || colm >= colms) return false;
            return true;
        }

        public static void FillMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < colms; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }
        public static Player FindPlayer(char[,] fild)
        {
            Player player = new Player();
            int rows = fild.GetLength(0);
            int colms = fild.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    var current = fild[i, j];
                    if (current.Equals('P'))
                    {
                        player.Row = i;
                        player.Colm = j;
                        return player;
                    }
                }
            }
            return player;
        }

    }

    class Player
    {
        public int Row { get; set; }
        public int Colm { get; set; }
        public bool ExitFild { get; private set; }
        public bool Eaten { get;  set; }

        public void MovePlayer(char direction, char[,] fild)
        {
            int row;
            int colm;
            if (this.Eaten == false)
            {
                switch (direction)
                {
                    case 'U':
                        row = this.Row - 1;
                        colm = this.Colm;
                        fild[this.Row, this.Colm] = '.';
                        if (ValidCoordinate(row, colm, fild) == false)
                        {
                            this.ExitFild = true;
                        }
                        else
                        {
                            var element = fild[row, colm];
                            if (element.Equals('B'))
                            {
                                this.Eaten = true;
                            }
                            else
                            {
                                fild[row, colm] = 'P';
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;
                    case 'D':
                        row = this.Row + 1;
                        colm = this.Colm;
                        fild[this.Row, this.Colm] = '.';
                        if (ValidCoordinate(row, colm, fild) == false)
                        {
                            this.ExitFild = true;
                        }
                        else
                        {
                            var element = fild[row, colm];
                            if (element.Equals('B'))
                            {
                                this.Eaten = true;
                            }
                            else
                            {
                                fild[row, colm] = 'P';
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;
                    case 'L':
                        row = this.Row ;
                        colm = this.Colm-1;
                        fild[this.Row, this.Colm] = '.';
                        if (ValidCoordinate(row, colm, fild) == false)
                        {
                            this.ExitFild = true;
                        }
                        else
                        {
                            var element = fild[row, colm];
                            if (element.Equals('B'))
                            {
                                this.Eaten = true;
                            }
                            else
                            {
                                fild[row, colm] = 'P';
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;
                    case 'R':
                        row = this.Row ;
                        colm = this.Colm+1;
                        fild[this.Row, this.Colm] = '.';
                        if (ValidCoordinate(row, colm, fild) == false)
                        {
                            this.ExitFild = true;
                        }
                        else
                        {
                            var element = fild[row, colm];
                            if (element.Equals('B'))
                            {
                                this.Eaten = true;
                            }
                            else
                            {
                                fild[row, colm] = 'P';
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;

                }
            }
        }

        private bool ValidCoordinate(int row, int colm, char[,] fild)
        {
            int rows = fild.GetLength(0);
            int colms = fild.GetLength(1);
            if (row < 0 || row >= rows) return false;
            if (colm < 0 || colm >= colms) return false;
            return true;
        }
    }
}
