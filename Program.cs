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
            //Bank and user's money management
            CBank.Bank NewBank = new CBank.Bank(){ BankName = "LNT" };
            CBank.User NewUser = new CBank.User(){ name = "John" };
            CBank.Checking NewUserChecking = new CBank.Checking(NewUser, NewBank);
            decimal balance = (decimal) NewUserChecking.Deposit(15000.00);

            // The carInventory and search Logic
            List<Car>CarInventory=File.ReadAllLines("./data/auto-mpg.csv").Skip(1).Select(carInfo=>Car.DataFromCsv(carInfo)).ToList();

            Analytics Analytics = new Analytics(CarInventory);              

            bool loopOption = true;

            while(loopOption){
                balance = (decimal) NewUserChecking.Balance;
                Console.WriteLine($"Your balance is: ${balance}");
                Console.WriteLine("Do you want to deposit/withdraw money? Answer with Yes or No");
                var userAccountAction = Console.ReadLine().ToLower();
                if(userAccountAction == "yes"){
                Console.WriteLine("What type of transaction are you making? Answer with Deposit or Withdraw");
                var userAccountDecistion = Console.ReadLine().ToLower();
                if(userAccountDecistion == "deposit"){
                    Console.WriteLine("Deposit amount: ");
                    var depoAmount = Convert.ToDouble(Console.ReadLine());

                    balance = (decimal) NewUserChecking.Deposit(depoAmount);
                    continue;
                }else if(userAccountDecistion == "withdraw"){

                    Console.WriteLine("Withdrawal amount: ");
                    var withdAmount = Convert.ToDouble(Console.ReadLine());

                    balance = (decimal) NewUserChecking.Withdraw(withdAmount);
                    continue;

                }else{
                    continue;
                }

                    
                }

                // The carInventory and search Logic
                Console.WriteLine("Write 1 to see the inventory");
                Console.WriteLine("Write 2 to search the inventory by price range");
                Console.WriteLine("Write 3 to search the inventory by other option");
                Console.WriteLine("Write 4 to purchase a car by id");
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
                } else if( selectNum == 4){
                    try
                    {
                        Console.WriteLine("Enter the id of the car: ");
                        var carId = Int32.Parse(Console.ReadLine());
                        Analytics.PurchaseCar(carId, NewUserChecking);
                        CarInventory = Analytics.CarList;
                    }
                    catch (ArgumentException ex)
                    {
                        
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        

        }
    }
}
