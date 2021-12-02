using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Backend;
using DataLayer.Data;
using NuGet.Frameworks;
using Xunit;
using DataLayer.Backend;

namespace Tester
{
    public class CustomerBackendTests
    {

        [Fact]
        public void CheckUnsoldPackages_Test()
        {
            using var ctx = new FoodRescDbContext();
            AdminBackend.PrepareDatabase();

            var customerBackend = new CustomerBackend();

            var foodCategory = "Kött";
            var query = ctx.FoodPackages
                .Where(f => f.Sale.FoodPackage == null && f.FoodCategory == foodCategory)
                .OrderBy(f => f.PackagePrice);

            var foodPackages = query.ToList();


            var unsoldPackages = customerBackend.CheckUnsoldPackages(foodCategory);

            Assert.NotNull(unsoldPackages);

            foreach (var item in unsoldPackages)
            {
                Assert.Equal(foodCategory, item.FoodCategory);

            }

            Assert.Equal(foodPackages.Count, unsoldPackages.Count);
        }


        [Fact]
        public void TryToBuyFoodPackage_Test()
        {
            using var ctx = new FoodRescDbContext();
            AdminBackend.PrepareDatabase();

            var customerBackend = new CustomerBackend();
            var loginManager = new LoginManager();

            int mealId = 9;
            var user = loginManager.Login("anna23", "password1");

            var foodPackageToBuy = customerBackend.TryToBuyFoodPackage(mealId, user);

            Assert.NotNull(foodPackageToBuy);

            Assert.Equal(mealId, foodPackageToBuy.FoodPackageId);
        }

        [Fact]
        public void PurchaseHistoryTest()
        {
            AdminBackend.PrepareDatabase();
            using var ctx = new FoodRescDbContext();

            CustomerBackend customerBackend = new CustomerBackend();
            LoginManager login = new LoginManager();

            var user = login.Login("bertil12", "password2");

            // Kollar om användaren har köp från början, vilken den inte skall ha.

            bool checkMeals = ctx.Sales
                .Where(x => x.User.UserId == user.UserId).Any();

            Assert.False(checkMeals);

            customerBackend.TryToBuyFoodPackage(9, user);

            // Kollar om användaren har nu köpt något målpaket.

            bool check4Meals = ctx.Sales
                .Where(x => x.User == user).Any();

            Assert.True(check4Meals);
        }

    }

}
