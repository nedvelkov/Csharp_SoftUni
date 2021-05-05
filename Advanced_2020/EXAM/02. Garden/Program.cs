using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var garden = CreateGarden(size);
            List<Flower> flowers = new List<Flower>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Bloom Bloom Plow")) break;
                var coordinates = input.Split(" ").Select(int.Parse).ToArray();
                int row = coordinates[0];
                int colm = coordinates[1];
                Flower flower = new Flower();
                if (flower.InGarden(row, colm, garden))
                {
                    flower.Row = row;
                    flower.Colm = colm;
                    flowers.Add(flower);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }
            foreach (var flower in flowers)
            {
                flower.Bloom(garden);
            }
            PrintMatrix(garden);
        }

        public static void PrintMatrix(int[,] garden)
        {
            int rows = garden.GetLength(0);
            int colms = garden.GetLength(1);
            var sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    sb.Append(garden[i, j]);
                    if (j < colms - 1) sb.Append(" ");
                }
                sb.AppendLine();
            }
            Console.Write(sb);

        }

        public static int[,] CreateGarden(int[] size)
        {
            int rows = size[0];
            int colms = size[1];
            int[,] garden = new int[rows, colms];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    garden[i, j] = 0;
                }
            }
            return garden;
        }

    }

    class Flower
    {
        public int Row { get; set; }
        public int Colm { get; set; }
        //public int Bloom { get; set; }

        public bool InGarden(int row, int colm, int[,] garden)
        {
            int rows = garden.GetLength(0);
            int colms = garden.GetLength(1);
            if (row < 0 || row >= rows) return false;
            if (colm < 0 || colm >= colms) return false;

            return true;
        }

        public void Bloom(int[,] garden)
        {
            int rows = garden.GetLength(0);
            int colms = garden.GetLength(1);
            int row = this.Row;
            int colm = this.Colm;
            //up
            while (row >= 0)
            {
                garden[row, colm]++;
                row--;
            }
            row = this.Row + 1;
            //down
            while (row < rows)
            {
                garden[row, colm]++;
                row++;
            }
            row = this.Row;
            colm = this.Colm - 1;
            //left
            while (colm >= 0)
            {
                garden[row, colm]++;
                colm--;
            }

            //right
            colm = this.Colm + 1;
            while (colm < colms)
            {
                garden[row, colm]++;
                colm++;
            }
        }
    }
}
