using System;
using System.Linq;
using System.Collections;
namespace AutoStore
{
    public class Car{
        public double Mpg;
        public double Cylinders;
        public double Displacement;
        public double Horsepower;
        public double Weight;
        public double Acceleration;
        public double ModelYear;
        public double Origin;
        public string CarName;
        public decimal Price;

        public static Car DataFromCsv(string carInfo){

            string[] carFields=carInfo.Split(",");
            Car newCar= new Car();

            newCar.Mpg= Convert.ToDouble(carFields[0]);
            newCar.Cylinders= Convert.ToDouble(carFields[1]);
            newCar.Displacement= Convert.ToDouble(carFields[2]);
            newCar.Horsepower= Convert.ToDouble(carFields[3]);
            newCar.Weight= Convert.ToDouble(carFields[4]);
            newCar.Acceleration= Convert.ToDouble(carFields[5]);
            newCar.ModelYear= Convert.ToDouble(carFields[6]);
            newCar.Origin= Convert.ToDouble(carFields[7]);
            newCar.CarName= carFields[8];
            // get random price in range of 10,000-20,000
            newCar.Price=Math.Round(NextDecimal());

            return newCar;
        }

        public static decimal NextDecimal()
       {
                Random rand = new Random();
               double randNumber = (rand.NextDouble() * (20000 - 10000)) + 10000;
               return (decimal)randNumber;
       }

       public override string ToString(){
           return $"Mpg: {Mpg}, Cylinders: {Cylinders}, Displacement: {Displacement}, Horsepower: {Horsepower}, Weight: {Weight}, Acceleration: {Acceleration}, ModelYear: {ModelYear}, Origin: {Origin}, Name: {CarName}, Price: ${Price}";
       }


    }
}