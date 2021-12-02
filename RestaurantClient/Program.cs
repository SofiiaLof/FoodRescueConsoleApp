using System.Collections.Generic;
using DataLayer;
using DataLayer.Backend;
using DataLayer.Model;


public class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Clear();
        
        while (true)
        {
            Console.Clear();
            // hugo12   password8
            // elsa13   password9
            // alma7    password10
            // liam13   password11
            // selma34  password12
            // adam3    password13
            // signe12  password7

            Console.WriteLine("-------------------------------\n" +
                              "\n*** Welcome to Food Rescue ***\n" +
                              "\n-------------------------------");

            var loginManager = new LoginManager();
            User user = null;

            Console.WriteLine("Enter your username: ");
            var username = Console.ReadLine();

            Console.WriteLine("\nEnter your password: ");
            var password = Console.ReadLine();

            user = loginManager.Login(username, password);

            var RestaurantBackend = new RestaurantBackend();

            Restaurant restaurant = null;

            if (user != null)
            {
                restaurant = loginManager.Waitress(user);
                MainProgram(restaurant);
            }
            else
            {
                Console.WriteLine("Something wrong, please try again");
                Console.ReadLine();
            }
            
        }

        static void MainProgram(Restaurant restaurant)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome " + restaurant.RestaurantName + "!");
                Console.WriteLine("\n\nPick an option: " +
                                  "\n\n1: See Your Sold FoodPackages " +
                                  "\n\n2: See Your Unsold FoodPackages" +
                                  "\n\n3: Add a FoodPackage" +
                                  "\n\n4: Press Escape to Exit");

                var option = Console.ReadKey();

                Console.Clear();

                if (option.Key == ConsoleKey.D1)
                {
                    SeeSoldFoodPackages(restaurant);
                    Console.WriteLine("\nPress enter to return to menu");
                }

                if (option.Key == ConsoleKey.D2)
                {
                    SeeUnsoldFoodPackages(restaurant);
                    Console.WriteLine("\nPress enter to return to menu");
                }

                if (option.Key == ConsoleKey.D3)
                {
                    AddNewFoodPackage(restaurant);
                    Console.WriteLine("\nPress enter to return to menu");
                }

                if (option.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.ReadLine();
            }
        }
        
    }

    static void SeeSoldFoodPackages(Restaurant restaurant)
    {
        RestaurantBackend RestaurantBack = new RestaurantBackend();

        var soldFoodPackages = RestaurantBack.GetSoldPackagesForRestaurant(restaurant);

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

    static void SeeUnsoldFoodPackages(Restaurant restaurant)
    {
        RestaurantBackend RestaurantBackend = new RestaurantBackend();

        var unsoldFoodPackages = RestaurantBackend.GetUnSoldPackagesForRestaurant(restaurant);

        if (unsoldFoodPackages != null)
        {
            foreach (var item in unsoldFoodPackages)
            {
                Console.WriteLine("Restaurant name: " +
                                  item.Restaurant.RestaurantName +
                                  " Meal Name: " + item.MealName +
                                  " Price: " + item.PackagePrice + " kr");
            }

            Console.WriteLine();
        }
    }

    static void AddNewFoodPackage(Restaurant restaurant)
    {
        RestaurantBackend RestaurantBackend = new RestaurantBackend();

        Console.WriteLine("Please enter a mealname");
        string mealname = Console.ReadLine();

        Console.WriteLine("Please enter a mealtype");
        string mealtype = Console.ReadLine();

        Console.WriteLine("Please enter a price");
        int price = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter a foodcategory");
        string foodcategory = Console.ReadLine();

        Console.WriteLine("Please enter an allergen");
        string allergen = Console.ReadLine();

        var newFoodPackage = RestaurantBackend.AddNewFoodPackage(restaurant, mealname, price, foodcategory, allergen, mealtype);

        if (newFoodPackage != null)
        {
            Console.WriteLine("New package is added to restaurant: " + newFoodPackage.Restaurant.RestaurantName);
            Console.WriteLine("\nMeal Name: " + newFoodPackage.MealName +
                              "\nMeal Type: " + newFoodPackage.MealType +
                              "\nAllergen: " + newFoodPackage.Allergen +
                              "\nFoodcategory: " + newFoodPackage.FoodCategory +
                              "\nPrice: " + newFoodPackage.PackagePrice + " kr" +
                              "\nExpiration date: " + newFoodPackage.ExpirationDate);

            Console.WriteLine();
        }
    }


}