using System;

namespace Box
{
   public class Program
    {
       public static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                box.SurfaceArea();
                box.LateralSurface();
                box.Volume();

            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
