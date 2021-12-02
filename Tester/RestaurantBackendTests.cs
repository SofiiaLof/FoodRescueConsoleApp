using System;
using System.Linq;
using DataLayer;
using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
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

            var loginManager = new LoginManager();

            var user = loginManager.Login("hugo12", "password8");

            var restaurant = loginManager.Waitress(user);

            var query = ctx.FoodPackages
                .Include(f => f.Restaurant)
                .Where(f => f.Sale.FoodPackage != null && f.Restaurant == restaurant);

            var soldFoodPackages = query.ToList();

            var soldFood = restaurantBackend.GetSoldPackagesForRestaurant(restaurant);

            Assert.NotNull(soldFood);
            Assert.Equal(soldFood.Count, soldFoodPackages.Count);
        }

        [Fact]
        public void GetUnSoldPackagesForRestaurant_Test()
        {
            using var ctx = new FoodRescDbContext();

            AdminBackend.PrepareDatabase();

            var restaurantBackend = new RestaurantBackend();

            var loginManager = new LoginManager();

            var user = loginManager.Login("elsa13", "password9");

            var restaurant = loginManager.Waitress(user);

            var query = ctx.FoodPackages
                .Include(f => f.Restaurant)
                .Where(f => f.Sale.FoodPackage == null && f.Restaurant == restaurant);

            var unsoldFoodPackages = query.ToList();

            var unsoldFood = restaurantBackend.GetUnSoldPackagesForRestaurant(restaurant);

            Assert.NotNull(unsoldFood);
            Assert.Equal(unsoldFood.Count, unsoldFoodPackages.Count);
        }

        [Fact]
        public void AddNewFoodPackage_Test()
        {
            using var ctx = new FoodRescDbContext();

            AdminBackend.PrepareDatabase();

            var restaurantBackend = new RestaurantBackend();

            var loginManager = new LoginManager();

            var user = loginManager.Login("adam3", "password13");

            var restaurant = loginManager.Waitress(user);

            var mealname = "Pasta alla Vodka";
            var price = 55.0;
            var foodcategory = "Vego";
            var allergen = "Gluten";
            var mealtype = "Middag";

            var addFoodPackage =
                restaurantBackend.AddNewFoodPackage(restaurant, mealname, price, foodcategory, allergen, mealtype);

            Assert.Equal("Pasta alla Vodka", addFoodPackage.MealName);
        }
    }
}