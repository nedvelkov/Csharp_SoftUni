using System;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var moves = Console.ReadLine().Split();
            var fild = new char[size, size];
            FillMatrix(fild);
            Miner miner = FindMiner(fild);
            foreach (var direction in moves)
            {
                miner.MoveMiner(direction, fild);
            }
            int leftCoal = CoalOnFild(fild);
            int row = miner.Row;
            int colm = miner.Colm;
            if (miner.ExitMine)
            {
                Console.WriteLine($"Game over! ({row}, {colm})");
            }else if (leftCoal == 0)
            {
                Console.WriteLine($"You collected all coals! ({row}, {colm})");
            }
            else
            {
                Console.WriteLine($"{leftCoal} coals left. ({row}, {colm})");
            }
        }

        public static void FillMatrix(char[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine().Split();
                var array = (string.Concat(currentRow)).ToCharArray();
                for (int colm = 0; colm < size; colm++)
                {
                    matrix[row, colm] = array[colm];
                }

            }
        }

        public static int CoalOnFild(char[,] matrix)
        {
            int size = matrix.GetLength(0);
            int coalCount = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var current = matrix[i, j];
                    if (current.Equals('c'))
                    {
                        coalCount++;
                    }
                }
            }
            return coalCount;
        }
        public static Miner FindMiner(char[,] matrix)
        {
            int size = matrix.GetLength(0);
            Miner miner = new Miner();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var current = matrix[i, j];
                    if (current.Equals('s'))
                    {
                        miner.Row = i;
                        miner.Colm = j;
                        return miner;
                    }
                }
            }
            return miner;
        }

    }

    class Miner
    {
        public int Row { get; set; }
        public int Colm { get; set; }
        public bool ExitMine { get;private set; }
        public int CoalCollected { get; private set; }

        public void MoveMiner(string direction, char[,] matrix)
        {
            int row;
            int colm;
            if (this.ExitMine == false)
            {
                switch (direction)
                {
                    case "up":
                        row = this.Row - 1;
                        colm = this.Colm;
                        if (ValidCoordinate(row, colm, matrix))
                        {
                            matrix[this.Row, this.Colm] = '*';
                            char element = matrix[row, colm];
                            matrix[row, colm] = 's';
                            if (element.Equals('c'))
                            {
                                this.CoalCollected++;
                            }
                            else if (element.Equals('e'))
                            {
                                this.ExitMine = true;
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;
                    case "down":
                        row = this.Row + 1;
                        colm = this.Colm;
                        if (ValidCoordinate(row, colm, matrix))
                        {
                            matrix[this.Row, this.Colm] = '*';
                            char element = matrix[row, colm];
                            matrix[row, colm] = 's';
                            if (element.Equals('c'))
                            {
                                this.CoalCollected++;
                            }
                            else if (element.Equals('e'))
                            {
                                this.ExitMine = true;
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }

                        break;
                    case "right":
                        row = this.Row;
                        colm = this.Colm + 1;
                        if (ValidCoordinate(row, colm, matrix))
                        {
                            matrix[this.Row, this.Colm] = '*';
                            char element = matrix[row, colm];
                            matrix[row, colm] = 's';
                            if (element.Equals('c'))
                            {
                                this.CoalCollected++;
                            }
                            else if (element.Equals('e'))
                            {
                                this.ExitMine = true;
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;
                    case "left":
                        row = this.Row;
                        colm = this.Colm - 1;
                        if (ValidCoordinate(row, colm, matrix))
                        {
                            matrix[this.Row, this.Colm] = '*';
                            char element = matrix[row, colm];
                            matrix[row, colm] = 's';
                            if (element.Equals('c'))
                            {
                                this.CoalCollected++;
                            }
                            else if (element.Equals('e'))
                            {
                                this.ExitMine = true;
                            }
                            this.Row = row;
                            this.Colm = colm;
                        }
                        break;


                }
            }
        }

        private bool ValidCoordinate(int row, int colm, char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colms = matrix.GetLength(1);
            if (row < 0 || row >= rows) return false;
            if (colm < 0 || colm >= colms) return false;

            return true;
        }
    }
}
