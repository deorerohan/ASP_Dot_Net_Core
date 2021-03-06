using System.Collections.Generic;
using Web.Core;

namespace Web.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
