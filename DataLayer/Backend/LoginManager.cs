using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
using DataLayer.Data;

namespace DataLayer.Backend
{
    public class LoginManager
    {
        public User? Login(string Username, string Password)
        {

            using var ctx = new FoodRescDbContext();

            var query = ctx.Users
                .Where(c => c.UserPrivateInfo.Username == Username && c.UserPrivateInfo.Password == Password)
                .Include(x => x.UserPrivateInfo)
                .FirstOrDefault();

            if (query != null) return query;

            return null;
        }

        public bool ChangePassword(string Username, string Password, string NewPassword)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.Users
                .Where(c => c.UserPrivateInfo.Username == Username && c.UserPrivateInfo.Password == Password)
                .FirstOrDefault();

            if (query != null)
            {
                query.UserPrivateInfo.Password = NewPassword;
                ctx.SaveChanges();
                return true;
            } else { 
                return false; 
            }
        }

        public bool Waitress(string Username, string Password)
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.Users
                .Where(c => c.UserPrivateInfo.Username == Username && c.UserPrivateInfo.Password == Password)
                .FirstOrDefault();

            var RestaurantQuery = ctx.Restaurants
                .Where(v => v.User.UserId == query.UserId)
                .FirstOrDefault();

            return (RestaurantQuery != null);
        }
    }
}
