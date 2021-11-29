using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Data;
using Xunit;

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


            foreach (var item in unsoldPackages)
            {
                Assert.Equal(foodCategory, item.FoodCategory);

            }

            Assert.Equal(foodPackages.Count, unsoldPackages.Count);
        }



    }
}
