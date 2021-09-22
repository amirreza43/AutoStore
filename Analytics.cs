using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoStore
{
    public class Analytics{
        private List<Car> _carList;

        public Analytics(List<Car> carListInput){
            _carList = carListInput;
        }

        public IEnumerable<Car> SearchCar(string searchOption, string searchInput){

            switch (searchOption)
            {
                case "Mpg":
                return from c in _carList where c.Mpg == Convert.ToDouble(searchInput) select c;
                case "Cylinder":
                return from c in _carList where c.Cylinders == Convert.ToDouble(searchInput) select c;
                case "Acceleration":
                return from c in _carList where c.Acceleration == Convert.ToDouble(searchInput) select c;
                case "Displacement":
                return from c in _carList where c.Displacement == Convert.ToDouble(searchInput) select c;
                case "Horsepower":
                return from c in _carList where c.Horsepower == Convert.ToDouble(searchInput) select c;
                case "ModelYear":
                return from c in _carList where c.ModelYear == Convert.ToDouble(searchInput) select c;
                case "Name":
                return from c in _carList where c.CarName == searchInput select c;
                default:
                throw new ArgumentException("There was a problem with your search option, or no results were found.");
            }

        }

        public IEnumerable<Car> SearchCarByPrice(decimal max, decimal min){
            return from c in _carList where c.Price >=min &&  c.Price <= max select c;
        }

    }
}