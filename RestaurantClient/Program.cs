using System.Collections.Generic;
using DataLayer;
using DataLayer.Model;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkMagenta;
Console.Clear();

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
        // Altans Pizzeria
        // Appetito
        // Chop Chop Asian Express
        // Espresso House
        // Maximus restaurant
        // McDonalds
        // Poke Bowl

        RestaurantBackend restaurantBack = new RestaurantBackend();

        Console.WriteLine("Skriv in din restaurang");

        var input = Console.ReadLine();

        Restaurant restaurant_ = restaurantBack.FindRestaurant("Espresso House");

        var soldFoodPackages = restaurantBack.GetSoldPackagesForRestaurant(restaurant_);

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

    if (keyInfo.Key == ConsoleKey.D2)
    {

    }

    if (keyInfo.Key == ConsoleKey.D3)
    {

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
