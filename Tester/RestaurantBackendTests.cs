using System.Linq;
using DataLayer;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tester
{
    public class RestaurantBackendTests
    {
        [Fact]
        public void GetSoldPackagesForRestaurant_Test()
        {
            using var ctx = new FoodRescDbContext();

            AdminBackend.PrepareDatabase();

            var restaurantBackend = new RestaurantBackend();

            var restaurant = restaurantBackend.FindRestaurant("Espresso House");
            
            var query = ctx.FoodPackages
                .Include(f => f.Restaurant)
                .Where(f => f.Sale.FoodPackage != null && f.Restaurant == restaurant);

            var soldFoodPackages = query.ToList();

            var soldFood = restaurantBackend.GetSoldPackagesForRestaurant(restaurant);

            Assert.Equal(2, soldFoodPackages.Count());
        }

    }
}