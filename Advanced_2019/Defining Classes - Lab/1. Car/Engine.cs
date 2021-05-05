using CarManufacturer;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(int horsePower,double cubicCapacity):this()
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
