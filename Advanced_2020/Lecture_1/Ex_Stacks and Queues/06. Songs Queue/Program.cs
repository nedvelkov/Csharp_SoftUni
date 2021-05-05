using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            Queue<string> playList = new Queue<string>();
            AddToQueue(tokens, playList);
            while (playList.Count>0)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                switch (command)
                {
                    case"Play":
                        playList.Dequeue();
                        break;
                    case "Add":
                        string song = ConcatSong(input);
                        if(playList.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            break;
                        }
                        playList.Enqueue(song);
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",playList));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }

        public static void AddToQueue(string[] tokens,Queue<string> list)
        {
            foreach (var item in tokens)
            {
                list.Enqueue(item);
            }
        }

        public static string ConcatSong(string[] tokens)
        {
            string[] temp = new string[tokens.Length - 1];
            for (int i = 1; i < tokens.Length; i++)
            {
                temp[i - 1] = tokens[i];
            }
            return string.Join(" ", temp);
        }
    }
}
