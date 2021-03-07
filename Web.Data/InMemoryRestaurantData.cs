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
                new Restaurant{Id = 1, Name="Swapnali's", Location="London", Cuisine=CuisineType.American },
                new Restaurant{Id = 1, Name="Viraj's", Location="New York", Cuisine=CuisineType.Italian },
                new Restaurant{Id = 1, Name="Bittu's", Location="Nashik", Cuisine=CuisineType.Indian },
                new Restaurant{Id = 1, Name="Shivansh's", Location="Raipur", Cuisine=CuisineType.Indian }
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
    }
}