using System;
using System.Linq;
using DataLayer;
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

            var restaurant = restaurantBackend.FindRestaurant("Espresso House");
            
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

            var restaurant = restaurantBackend.FindRestaurant("Altans Pizzeria");

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

            var restaurant = restaurantBackend.FindRestaurant("Appetito");
            var mealname = "Pasta alla Vodka";
            var price = 55;
            var foodcategory = "Vego";
            var allergen = "Gluten";
            var mealtype = "Middag";

            if (restaurant != null)
            {
                var newFoodPackage = new FoodPackage()
                {
                    MealName = mealname,
                    PackagePrice = price,
                    FoodCategory = foodcategory,
                    PackagingDate = DateTime.Now,
                    ExpirationDate = DateTime.Today.AddDays(2),
                    Restaurant = restaurant,
                    Allergen = allergen,
                    MealType = mealtype,
                };

                var foodPackageToAdd = ctx.FoodPackages.Add(newFoodPackage);
            }

            var addFoodPackage =
                restaurantBackend.AddNewFoodPackage(restaurant, mealname, price, foodcategory, allergen, mealtype);

        }
    }
}