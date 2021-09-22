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

            Analytics Analytics = new Analytics(CarInventory);              

            bool loopOption = true;

            while(loopOption){

                Console.WriteLine("Write 1 to see the inventory");
                Console.WriteLine("Write 2 to search the inventory by price range");
                Console.WriteLine("Write 3 to search the inventory by other option");
                Console.WriteLine("Write 0 to quit");
                
                var selectNum = Int32.Parse(Console.ReadLine());
                if( selectNum == 1 ){
                    foreach (var item in CarInventory) 
                    {
                        Console.WriteLine(item);
                    }
                } else if( selectNum == 2 ){
                    Console.WriteLine("Minimum: ");
                    var pMin = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Maximum: ");
                    var pMax = Convert.ToDecimal(Console.ReadLine());
                    var searchRes = Analytics.SearchCarByPrice(pMax, pMin);
                    foreach (var item in searchRes)
                    {
                        Console.WriteLine(item);
                    }
                } else if( selectNum == 3 ){
                    try
                    {
                        Console.WriteLine("Please type the search category:");
                        Console.WriteLine("Choose between Mpg, Cylinder, Acceleration, Displacement, Horsepower, ModelYear, Name");
                        var searchOption = Console.ReadLine();
                        Console.WriteLine($"Search {searchOption} at:");
                        var searchInput = Console.ReadLine();
                        var searchRes = Analytics.SearchCar(searchOption, searchInput);
                        if(searchRes.ToList().Count == 0){
                            Console.WriteLine("No reuslts were found.");
                        }
                        foreach (var item in searchRes)
                        {
                            Console.WriteLine(item);
                        }  
                    }
                    catch (ArgumentException ex)
                    { 
                        Console.WriteLine(ex.Message);
                    }
                } else if( selectNum == 0){
                    loopOption = false;
                }
            }
        

        }
    }
}
