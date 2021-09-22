using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AutoStore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car>CarInventory=File.ReadAllLines("./data/auto-mpg.csv").Skip(1).Select(carInfo=>Car.DataFromCsv(carInfo)).ToList();

                Console.WriteLine(CarInventory);

        

        }
    }
}
