using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoStore
{
    public class Analytics{
        public List<Car> CarList;

        public Analytics(List<Car> carListInput){
            CarList = carListInput;
        }

        public IEnumerable<Car> SearchCar(string searchOption, string searchInput){

            switch (searchOption)
            {
                case "Mpg":
                return from c in CarList where c.Mpg == Convert.ToDouble(searchInput) select c;
                case "Cylinder":
                return from c in CarList where c.Cylinders == Convert.ToDouble(searchInput) select c;
                case "Acceleration":
                return from c in CarList where c.Acceleration == Convert.ToDouble(searchInput) select c;
                case "Displacement":
                return from c in CarList where c.Displacement == Convert.ToDouble(searchInput) select c;
                case "Horsepower":
                return from c in CarList where c.Horsepower == Convert.ToDouble(searchInput) select c;
                case "ModelYear":
                return from c in CarList where c.ModelYear == Convert.ToDouble(searchInput) select c;
                case "Name":
                return from c in CarList where c.CarName == searchInput select c;
                default:
                throw new ArgumentException("There was a problem with your search option, or no results were found.");
            }

        }

        public IEnumerable<Car> SearchCarByPrice(decimal max, decimal min){
            return from c in CarList where c.Price >=min &&  c.Price <= max select c;
        }

        public void PurchaseCar(int id, CBank.Checking userCheking){
            Car carPurchased = null;
            foreach (var item in CarList)
            {
                if(item.Id == id){
                    if( item.Price < (decimal)userCheking.Balance ){
                    
                        userCheking.Withdraw((double)item.Price);
                    
                        carPurchased = item;   
                        
                    }else{
                        throw new ArgumentException("Price of the car is higher than your balance.");
                    }
                }
            }

            CarList.Remove(carPurchased);

        }

    }
}