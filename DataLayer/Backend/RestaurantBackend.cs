using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class RestaurantBackend
    {
        //En metod för att få en lista över alla sålda matlådor för ett restaurang objekt
        public List<FoodPackage> GetSoldPackagesForRestaurant(Restaurant restaurant)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.FoodPackages
                .Include(f => f.Restaurant)
                .Where(f => f.Sale.FoodPackage != null && f.Restaurant == restaurant);

            var soldFoodPackages = query.ToList();
            var exist = query.Any();

            if (exist)
            {
                return soldFoodPackages;
            }

            return null;
        }

        //En metod för att få en lista över alla osålda matlådor för ett restaurang objekt
        public List<FoodPackage> GetUnSoldPackagesForRestaurant(Restaurant restaurant)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.FoodPackages
                .Include(f => f.Restaurant)
                .Where(f => f.Sale.FoodPackage == null && f.Restaurant == restaurant);

            var unsoldFoodPackages = query.ToList();
            var exist = query.Any();

            if (exist)
            {
                return unsoldFoodPackages;
            }

            return null;
        }

        //En metod för att lägga till ett nytt matlådeobjekt för en restaurang
        public FoodPackage AddNewFoodPackage(Restaurant restaurant, string mealname, double price, string foodcategory, string allergen, string mealtype)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.Restaurants
                .Where(r => r.RestaurantName == restaurant.RestaurantName &&
                            r.RestaurantAddress == restaurant.RestaurantAddress)
                .FirstOrDefault();

            if (restaurant != null)
            {
                var newFoodPackage = new FoodPackage()
                {
                    MealName = mealname,
                    PackagePrice = price,
                    FoodCategory = foodcategory,
                    PackagingDate = DateTime.Now,
                    ExpirationDate = DateTime.Today.AddDays(2),
                    Restaurant = query,
                    Allergen = allergen,
                    MealType = mealtype,
                };

                var foodPackageToAdd = ctx.FoodPackages.Add(newFoodPackage);
                ctx.SaveChanges();

                return newFoodPackage;
            }

            return null;
        }

    }
}
