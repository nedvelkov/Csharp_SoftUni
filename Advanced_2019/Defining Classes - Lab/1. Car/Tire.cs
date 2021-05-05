using CarManufacturer;

namespace CarManufacturer
{
    public class Tire
    {
        public int Year { get; set; }
        public double Pressure { get; set; }
        public Tire()
        {

        }
        public Tire(int year,double pressure):this()
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
