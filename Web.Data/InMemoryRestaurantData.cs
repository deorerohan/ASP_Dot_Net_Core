using System.Collections.Generic;
using System.Linq;
using Web.Core;

namespace Web.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name="Rohan's", Location="Paris", Cuisine=CuisineType.Indian },
                new Restaurant{Id = 2, Name="Swapnali's", Location="London", Cuisine=CuisineType.American },
                new Restaurant{Id = 3, Name="Viraj's", Location="New York", Cuisine=CuisineType.Italian },
                new Restaurant{Id = 4, Name="Bittu's", Location="Nashik", Cuisine=CuisineType.Indian },
                new Restaurant{Id = 5, Name="Shivansh's", Location="Raipur", Cuisine=CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                return restaurants;
            }
            else
            {
                return from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r;
            }
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);

        }
    }
}