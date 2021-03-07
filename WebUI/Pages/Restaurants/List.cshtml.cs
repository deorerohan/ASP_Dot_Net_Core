using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Web.Data;
using Web.Core;

namespace WebUI.PagesRestaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IRestaurantData Data)
        {
            restaurantData = Data;
        }

        
        public void OnGet()
        {
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}