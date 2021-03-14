using System.Collections.Generic;
using System.Linq;
using Web.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Web.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> context) : base(context)
        {
            
        }
    }
}