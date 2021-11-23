using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataLayer.Data
{
    public class FoodRescDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<UserPrivateInfo> UsersPrivateInfo { get; set; }
            public virtual DbSet<FoodPackage> FoodPackages { get; set; }
            public virtual DbSet<Restaurant> Restaurants { get; set; }
            public virtual DbSet<Sale> Sales { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .LogTo(m => Debug.WriteLine(m), LogLevel.Information)
                    .UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=FoodRescDb");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UserPrivateInfo>()
                    .HasIndex(c => c.EmailAddress)
                    .IsUnique();

                modelBuilder.Entity<Restaurant>()
                    .HasKey(r => new { r.RestaurantName, r.RestaurantAddress });

                modelBuilder.Entity<Restaurant>()
                    .HasIndex(r => r.EmailAddress)
                    .IsUnique();


            }

            public void Seed()
            {

                var users = new List<User>
            {
                new() {RegisteredAt = new DateTime(2021,11,1)},
                new() {RegisteredAt = new DateTime(2021,11,2)},
                new() {RegisteredAt = new DateTime(2021,11,3)},
                new() {RegisteredAt = new DateTime(2021,11,4)},
                new() {RegisteredAt = new DateTime(2021,11,5)},
                new() {RegisteredAt = new DateTime(2021,11,6)},
                new() {RegisteredAt = new DateTime(2021,11,7)},
            };
                AddRange(users);

                var usersPrivateInfo = new List<UserPrivateInfo>
            {
                new() {FirstName= "Anna", LastName= "Bergman",EmailAddress="annaberg@email.com",Username="anna23",Password="password1", CustomerAddress="Aktergatan 23", User= users[0]},
                new() {FirstName= "Bertil", LastName= "Larsson",EmailAddress ="bertillars@email.com",Username="bertil12",Password="password2", CustomerAddress="Bergsarksvägen 12",User= users[1]},
                new() {FirstName= "Lisa", LastName= "Svensson",EmailAddress ="lisasven@email.com",Username="lisa67",Password="password3", CustomerAddress="Bjrholmsgatan 45",User= users[2]},
                new() {FirstName= "Diana'", LastName= "Smith",EmailAddress ="dianasmt@email.com",Username="diana76",Password="password4", CustomerAddress="Dalagatan 7",User= users[3]},
                new() {FirstName= "Anders", LastName= "Johansson",EmailAddress="andersjoh@email.com",Username="anders34",Password="password5", CustomerAddress="Celsiusgatan 5",User= users[4]},
                new() {FirstName= "Kamila", LastName= "Champ",EmailAddress="kamilach@email.com",Username="kamila3",Password="password6", CustomerAddress="Drottningatan 56",User= users[5]},
                new() {FirstName= "Oliver", LastName= "Johnsson",EmailAddress="oliverjohn@email.com",Username="oliver12",Password="password7", CustomerAddress="Fredmansgatan 1",User= users[6]}
            };
                AddRange(usersPrivateInfo);

                var restaurants = new List<Restaurant>
            {
                new() {RestaurantName="Espresso House", RestaurantAddress="Drottningatan 2", PhoneNumber="0702178456", EmailAddress="espressoh@email.com"},
                new() {RestaurantName="McDonalds", RestaurantAddress="Glasbruksgatan 34", PhoneNumber="0724177571", EmailAddress="mcdonalds@email.com"},
                new() {RestaurantName="Poke Bowl", RestaurantAddress="Havregatan 31", PhoneNumber="0712678025", EmailAddress="poke@email.com"},
                new() {RestaurantName="Altans Pizzeria", RestaurantAddress="Munkforsgatan 45", PhoneNumber="0703479444", EmailAddress="'pizzeria@email.com"},
                new() {RestaurantName="Chop Chop Asian Express", RestaurantAddress="Farstagatan 89", PhoneNumber="0706713459", EmailAddress="chopchop@email.com"},
                new() {RestaurantName="Maximus restaurant", RestaurantAddress="Hjärnegatan 67", PhoneNumber=" 0705671258", EmailAddress="max@email.com"},
                new() {RestaurantName="Appetito", RestaurantAddress="Kolargatan 45", PhoneNumber="0701179459", EmailAddress="appetito@email.com"},
            };
                AddRange(restaurants);

                var foodPackages = new List<FoodPackage>
            {
                new() {MealName="Ceasarsallad", PackagePrice = 45.0, FoodCategory = "Kött",MealType = "Lunch",Allergen = "Ägg",Unsold = null,PackagingDate = DateTime.Now, ExpirationDate = DateTime.Today.AddDays(3), Restaurant = restaurants[0]},
                new() {MealName="Sallad", PackagePrice = 25.0, FoodCategory = "Vego", MealType = "Lunch", Allergen = "Ägg",Unsold = null,PackagingDate = DateTime.Now ,ExpirationDate = DateTime.Today.AddDays(2),  Restaurant = restaurants[0]},
                new() {MealName="Hamburgaremeny", PackagePrice = 10.0, FoodCategory = "Kött",MealType = "Lunch",Allergen = "Gluten",Unsold = null,PackagingDate = DateTime.Now ,ExpirationDate = DateTime.Today.AddDays(1),  Restaurant = restaurants[1] },
                new() {MealName="Pokebowl", PackagePrice = 39.0, FoodCategory = "Fisk",MealType = "Middag",Allergen = "Laktos",Unsold = null,PackagingDate = DateTime.Now,ExpirationDate = DateTime.Today.AddDays(1),  Restaurant = restaurants[2]},
                new() {MealName="Stekt ägg med bacon", PackagePrice = 50.0, FoodCategory = "Kött",MealType = "Frukost",Allergen = "Ägg",Unsold = null,PackagingDate = DateTime.Now ,ExpirationDate = DateTime.Today.AddDays(2),  Restaurant = restaurants[3] },
                new() {MealName="Wokade grönsaker", PackagePrice =  53.0, FoodCategory = "Vego",MealType = "Lunch",Allergen = "Soja",Unsold = null,PackagingDate = DateTime.Now,ExpirationDate = DateTime.Today.AddDays(3),  Restaurant = restaurants[4] },
                new() {MealName="Grönsallad", PackagePrice = 40.0, FoodCategory = "Vego",MealType = "Lunch",Allergen = "Nötter",Unsold = null,PackagingDate = DateTime.Now ,ExpirationDate = DateTime.Today.AddDays(1),  Restaurant = restaurants[5] },
                new() {MealName="Nötbit med potatis", PackagePrice = 65.0, FoodCategory = "Kött",MealType = "Middag",Allergen = "Laktos",Unsold = null,PackagingDate = DateTime.Now ,ExpirationDate = DateTime.Today.AddDays(3),  Restaurant = restaurants[6] }
            };
                AddRange(foodPackages);


                var sales = new List<Sale>
            {
                new() {PurchaseDate = DateTime.Today,FoodPackage = foodPackages[2],User = users[0]},
                new() {PurchaseDate = DateTime.Today, FoodPackage = foodPackages[3],User = users[0]},
                new() {PurchaseDate = new DateTime(2021,10,1), FoodPackage = foodPackages[0],User = users[3]},
                new() {PurchaseDate = new DateTime(2021,10,12),FoodPackage = foodPackages[1],User = users[4]}

            };
                AddRange(sales);
                SaveChanges();
            }
        
    }
}
