using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CustomerBackend
    {

        //En metod för att få ut en lista på alla oköpta matlådor i alla restauranger,
        //Sorterade på pris lägst först.

        public List<FoodPackage> CheckUnsoldPackages(string foodCategory)
        {

            using var ctx = new FoodRescDbContext();

            var query = ctx.FoodPackages
                .Where(f => f.Sale.FoodPackage == null && f.FoodCategory == foodCategory)
                .OrderBy(f => f.PackagePrice);

            var foodPackages = query.ToList();
            var sold = query.Any();

            if (sold)
            {
                return foodPackages;

            }

            return null;
        }

        //En metod för att köpa ett givet lunchlåde objekt

        public FoodPackage TryToBuyFoodPackage(int mealId, User user)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.FoodPackages
                .Where(f => f.FoodPackageId== mealId && f.Sale.FoodPackage == null);

            var userquery = ctx.Users
                .Where(u => u.UserId == user.UserId);

            var foodPackage = query.FirstOrDefault();
            var unsold = query.Any();

             var chosenUser = userquery.First();

            if (unsold)
            {
                var soldFoodPackage = new Sale()
                {

                    FoodPackage = foodPackage,
                    User = chosenUser,
                    PurchaseDate = DateTime.Now

                };

                ctx.Add(soldFoodPackage);

                foodPackage.Unsold = user.UserId.ToString();

                ctx.SaveChanges();
                return foodPackage;
            }

            return null;
        }

        //Se köphistorik för en specifik användare
        public List<Sale> PurchaseHistory(User user)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.Sales
                .Where(c => c.User == user)
                .Include(f => f.FoodPackage);

            var sales = query.ToList();
            var exist = query.Any();

            if (exist)
            {
                return sales;
            }

            return null;
        }

    }
}