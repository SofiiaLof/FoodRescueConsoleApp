using System.Collections.Generic;
using DataLayer;
using DataLayer.Model;


public class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Clear();
        while (true)
        {
            // Altans Pizzeria
            // Appetito
            // Chop Chop Asian Express
            // Espresso House
            // Maximus restaurant
            // McDonalds
            // Poke Bowl

            var RestaurantBackend = new RestaurantBackend();

            Restaurant restaurant = null;

            Console.WriteLine("\n*** Welcome to Food Rescue***\n" +
                              "\n-----------------------------\n" +
                              "\nPlease enter your restaurant");

            var restaurantname = Console.ReadLine();

            restaurant = RestaurantBackend.FindRestaurant(restaurantname);
            
            if (restaurantname != null)
            {
                MainProgram(restaurant);
            }
            else
            {
                Console.WriteLine("Something went wrong. Pleas try to login again!");
                Console.ReadLine();
            }
        }

        static void MainProgram(Restaurant restaurant)
        {
            while (true)
            {
                Console.WriteLine("Pick an option: " +
                                  "\n1: Sold FoodPackages " +
                                  "\n2: Unsold FoodPackages" +
                                  "\n3: Add FoodPackage" +
                                  "\n4: Press Escape to Exit" +
                                  "\n5: Reset Database");

                var keyInfo = Console.ReadKey();

                Console.Clear();

                if (keyInfo.Key == ConsoleKey.D1)
                {
                    SeeSoldFoodPackages();
                }

                if (keyInfo.Key == ConsoleKey.D2)
                {
                    SeeUnsoldFoodPackages();
                }

                if (keyInfo.Key == ConsoleKey.D3)
                {
                    AddNewFoodPackage(restaurant);
                }

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (keyInfo.Key == ConsoleKey.D5)
                {
                    AdminBackend.PrepareDatabase();
                    Console.WriteLine("Database initialized!");
                    Console.WriteLine("Press enter to return to menu");
                }

                Console.ReadLine();
            }
        }
        
    }

    static void SeeSoldFoodPackages()
    {
        RestaurantBackend RestaurantBack = new RestaurantBackend();

        Restaurant restaurant_ = RestaurantBack.FindRestaurant("Espresso House");

        var soldFoodPackages = RestaurantBack.GetSoldPackagesForRestaurant(restaurant_);

        if (soldFoodPackages != null)
        {
            foreach (var item in soldFoodPackages)
            {
                Console.WriteLine("Restaurant name: " +
                                  item.Restaurant.RestaurantName +
                                  " Meal Name: " + item.MealName +
                                  " Price: " + item.PackagePrice + " kr");
            }

            Console.WriteLine();
        }
    }

    static void SeeUnsoldFoodPackages()
    {
        RestaurantBackend RestaurantBackend = new RestaurantBackend();

        Restaurant restaurant_ = RestaurantBackend.FindRestaurant("Espresso House");

        var soldFoodPackages = RestaurantBackend.GetSoldPackagesForRestaurant(restaurant_);

        if (soldFoodPackages == null)
        {
            foreach (var item in soldFoodPackages)
            {
                Console.WriteLine("Restaurant name: " +
                                  item.Restaurant.RestaurantName +
                                  " Meal Name: " + item.MealName +
                                  " Price: " + item.PackagePrice + " kr");
            }

            Console.WriteLine();
        }
    }

    static void AddNewFoodPackage(Restaurant name)
    {
        RestaurantBackend RestaurantBackend = new RestaurantBackend();

        Restaurant restaurant = RestaurantBackend.FindRestaurant("Poke Bowl");

        var newFoodPackage = RestaurantBackend.AddNewFoodPackage(restaurant, "Vårrullar", 25.0, "Vego");

        if (newFoodPackage != null)
        {
            Console.WriteLine("New package is added to restaurant: " + newFoodPackage.Restaurant.RestaurantName);
            Console.WriteLine("Meal name: " + newFoodPackage.MealName + "; " +
                              "Price: " + newFoodPackage.PackagePrice + "kr" + ";" +
                              "Expiration date: " + newFoodPackage.ExpirationDate + ";");

            Console.WriteLine();
        }
    }


}