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
    }
}
