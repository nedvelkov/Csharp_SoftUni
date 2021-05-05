using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int countCars = 0;
            bool flag = true;
            string crashCar=default;
            char hit=default;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END")) break;
                if (input.Equals("green"))
                {
                    int currentGreen = greenLight;
                    if (cars.Count == 0) continue;
                    string car = cars.Dequeue();
                    while (currentGreen>car.Length)
                    {
                       
                        if (cars.Count>0)
                        {
                            currentGreen -= car.Length;
                            car = cars.Dequeue();
                            countCars++;
                        }else 
                        {
                            currentGreen -= car.Length;
                            break;
                        }

                    }
                    if(currentGreen+freeWindow <car.Length)
                    {
                        crashCar = car;
                        hit = car[currentGreen + freeWindow];
                        flag = false;
                        break;
                    }
                    else
                    {
                        countCars++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

            }
            if (flag)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{ countCars} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
               Console.WriteLine($"{crashCar} was hit at {hit}.");
            }
        }
    }
}
