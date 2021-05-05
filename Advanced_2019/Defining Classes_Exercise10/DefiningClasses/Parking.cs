using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;
        private int capacity;
        public int Count { get => this.cars.Count;  }
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        public string AddCar(Car car)
        {
            string result;
            bool flag = false;
            foreach (var currentCar in this.cars)
            {
                if (currentCar.RegistrationNumber == car.RegistrationNumber) flag = true;
            }
            if (flag)
            {
                result=("Car with that registration number, already exists!");
            }
            else if(this.cars.Count>=this.capacity)
            {
                result=("Parking is full!");
            }
            else
            {
                this.cars.Add(car);
                result=($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }
            return result;
        }

        public string RemoveCar(string plateNumber)
        {
            string result = null; ;
            bool flag = true;
            for (int i = 0; i < this.cars.Count; i++)
            {
                var currentCar = this.cars[i];
                
                if (currentCar.RegistrationNumber.Equals(plateNumber))
                {
                    this.cars.RemoveAt(i);
                    result=($"Successfully removed {plateNumber}");
                    flag = false;
                }
            }
            if (flag) result=("Car with that registration number, doesn't exist!");
            return result;
        }

        public string GetCar(string plateNumber)
        {
            foreach (var car in this.cars)
            {
                if (car.RegistrationNumber.Equals(plateNumber)) return (car.ToString());
            }
            return "Car with that registration number, doesn't exist!";
        }

        public void RemoveSetOfRegistrationNumber(List<string> platesNumbers)
        {
            foreach (var plate in platesNumbers)
            {
                RemoveCar(plate);
            }
        }
    }
}
