using System;
using System.Collections.Generic;
using System.Text;

namespace Box

{
    public class Box
    {
        private double width;
        private double height;
        private double length;
        public Box(double legth,double width,double height)
        {
            this.Length = legth;
            this.Width = width;
            this.Height = height;

        }
        public double Width
        {
            get => this.width;
          private  set
            {
                if(value<0 || value == 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
          private  set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double Length
        {
            get => this.length;
           private set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public void SurfaceArea()
        {
            double surfaceArea = this.width * this.height * 2 + this.width * this.length * 2 + this.height * this.length * 2;
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }
        public void LateralSurface()
        {
            double lSurface = this.length * this.height*2 + this.width * this.height * 2;
            Console.WriteLine($"Lateral Surface Area - {lSurface:f2}");
        }
        public void Volume()
        {
            double volume = this.height * this.length * this.width;
            Console.WriteLine($"Volume - {volume:f2}");
        }
    }
}
