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
                .Where(f => f.Sale.FoodPackage!= null && f.Restaurant==restaurant);

            var soldFoodPackages = query.ToList();
            var exist = query.Any();

            if (exist)
            {
                return soldFoodPackages;
            }

            return null;
        }

        //En metod för att lägga till ett nytt matlådeobjekt för en restaurang
        public FoodPackage AddNewFoodPackage(Restaurant restaurant, string mealname, double price, string foodcategory)
        {
            using var ctx = new FoodRescDbContext();

            if (restaurant != null)
            {
                var newFoodPackage = new FoodPackage()
                {
                    MealName = mealname,
                    PackagePrice = price,
                    FoodCategory = foodcategory,
                    PackagingDate = DateTime.Now,
                    ExpirationDate = DateTime.Today.AddDays(2),
                    Restaurant=restaurant

                };

                var foodPackageToAdd = ctx.FoodPackages.Add(newFoodPackage);
                ctx.Update(restaurant);
                ctx.SaveChanges();

                return newFoodPackage;
            }

            return null;
        }

    }
}
