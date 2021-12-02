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
    public class AdminBackend
    {
        //En metod för att skapa om och seeda databasen
        public static void PrepareDatabase()
        {
            using var ctx = new FoodRescDbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.Seed();
        }

        //En metod för att se alla användare
        public List<User> UserList()
        {

            using var ctx = new FoodRescDbContext();

            var query = ctx.Users
                .Include(c => c.UserPrivateInfo);

            var allCustomers = query.ToList();
            var exist = query.Any();

            if (exist)
            {
                return allCustomers;
            }

            return null;
        }



        //En metod för att se alla restauranger
        public List<Restaurant> CheckRegisteredRestaurants()
        {
            using var ctx = new FoodRescDbContext();

            var query = ctx.Restaurants;

            var registeredRestaurants = query.ToList();

            return registeredRestaurants;
        }


        //En metod för att kunna lägga till ett nytt restaurang objekt
        public Restaurant AddNewRestaurant(string name, string adress, string email, string phone)
        { 
            using var ctx = new FoodRescDbContext();
            User user = new User() { RegisteredAt = new DateTime(2021, 11, 7) };
            var newRestaurant = new Restaurant()
            {
                RestaurantName = name,
                RestaurantAddress = adress,
                EmailAddress = email,
                PhoneNumber = phone,
                User = user

            };
            

            var addNew = ctx.Restaurants.Add(newRestaurant);
            ctx.SaveChanges();

            return newRestaurant;
        }
        
    }
}   
