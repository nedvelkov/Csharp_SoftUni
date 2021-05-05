using System;

namespace Vehicles
{
    using Models;
    using Core;
    public class Program
    {

        static void Main()
        {
            Engine engine = new Engine();
            engine.AddVehicle();
            engine.AddVehicle();
            engine.AddVehicle();
            engine.MoveVehicle();
        }
    }
}
