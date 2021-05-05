using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunBarels = int.Parse(Console.ReadLine());
            var tokenBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var tokenLocks = Console.ReadLine().Split().Select(int.Parse).ToArray() ;
            int earning = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(tokenBullets);
            Queue<int> locks = new Queue<int>(tokenLocks);
            int currentBarel = gunBarels;
            int countBullets = 0;
            int @lock = locks.Peek();
            while (bullets.Count>0)
            {
                if (currentBarel == 0)
                {
                    currentBarel = gunBarels;
                    Console.WriteLine("Reloading!");
                }
                currentBarel--;
                int bullet = bullets.Pop();
                countBullets++;
                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    if (locks.Count == 0) break;
                    @lock = locks.Peek();
                    continue;
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int price = earning - countBullets * priceBullet;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${price}");
            }
        }
    }
}
