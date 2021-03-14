using System.Collections.Generic;
using System.Linq;
using Web.Core;

namespace Web.Data
{
    public class SqliteRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext dbContext;
        public SqliteRestaurantData(RestaurantDbContext context)
        {
            dbContext = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                dbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var query = from r in dbContext.Restaurants
            where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
            orderby r.Name
            select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
