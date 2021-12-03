using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Data;
using NuGet.Frameworks;
using Xunit;
using DataLayer.Backend;

namespace Tester
{
    public class LoginManagerTests
    {

        [Fact]
        public void LoginManagerTest()
        {
            AdminBackend.PrepareDatabase();
            using var ctx = new FoodRescDbContext();

            LoginManager loginManager = new LoginManager();

            var getUser = ctx.UsersPrivateInfo
                .Where(c => c.Username == "anna23").FirstOrDefault();

            var loginUser = loginManager.Login("anna23", "password1").UserPrivateInfo;

            Assert.True(getUser.EmailAddress == loginUser.EmailAddress);
        }

        [Fact]
        public void ChangePasswordTest()
        {
            AdminBackend.PrepareDatabase();
            var ctx = new FoodRescDbContext();

            LoginManager loginManager = new LoginManager();
            
            string prePassChange = loginManager.Login("anna23", "password1").UserPrivateInfo.Password;

            loginManager.ChangePassword("anna23", "password1", "newPassword");

            string postPassChange = loginManager.Login("anna23", "newPassword").UserPrivateInfo.Password;

            Assert.True(postPassChange == "newPassword");
        }

        [Fact]
        public void WaitressTest()
        {
            AdminBackend.PrepareDatabase();
            var ctx = new FoodRescDbContext();

            var loginManager = new LoginManager();

            var RestaurantUser = loginManager.Login("hugo12", "password8");
            var restaurantInfo = loginManager.Waitress(RestaurantUser);

            var targetRestaurant = ctx.Restaurants
                .Where(h => h.User.UserPrivateInfo.Username == "hugo12")
                .FirstOrDefault();

            Assert.True(restaurantInfo.RestaurantName == targetRestaurant.RestaurantName);
        }
    }
}
