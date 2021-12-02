using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Xunit;

namespace Tester
{
    public class AdminBackendTests
    {
        [Fact]

        public void CheckRegisteredRestaurantTests()
        {

            AdminBackend backend = new AdminBackend();
            using var ctx = new FoodRescDbContext();
            AdminBackend.PrepareDatabase();

            var query = ctx.Restaurants;

            var registeredRestaurants = query.ToList();

            var registeredTest = backend.CheckRegisteredRestaurants();

            Assert.NotNull(registeredTest);

            Assert.Equal(registeredRestaurants.Count, registeredTest.Count);

            Assert.Equal("Altans Pizzeria", registeredTest[0].RestaurantName);

        }




    }
}
