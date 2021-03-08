using System.Collections.Generic;
using Web.Core;

namespace Web.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        int Commit();
    }
}
