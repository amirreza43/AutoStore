using System;
namespace AutoStore
{
    public class Car{
        public int Mpg;
        public int Cylinders;
        public int Displacement;
        public int Horsepower;
        public int Weight;
        public int Acceleration;
        public int ModelYear;
        public int Origin;
        public string CarName;
        public decimal Price;

        public static Car DataFromCsv(string carInfo){

            string[] carFields=carInfo.Split(", ");

            Car newCar= new Car();

            newCar.Mpg=Int32.Parse(carFields[0]);
            newCar.Cylinders=Int32.Parse(carFields[1]);
            newCar.Displacement=Int32.Parse(carFields[2]);
            newCar.Horsepower=Int32.Parse(carFields[3]);
            newCar.Weight=Int32.Parse(carFields[4]);
            newCar.Acceleration=Int32.Parse(carFields[5]);
            newCar.ModelYear=Int32.Parse(carFields[6]);
            newCar.Origin=Int32.Parse(carFields[7]);
            newCar.CarName=carFields[8];
            //get random price in range of 10,000-20,000
            newCar.Price=NextDecimal();

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