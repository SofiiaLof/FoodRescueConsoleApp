using DataLayer;
using DataLayer.Model;

namespace CustomerClient
{
    public class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                var customerBackend = new CustomerBackend();
                User user = null;

                Console.WriteLine("Welcome! ");
                Console.WriteLine("Enter your username: ");
                var username = Console.ReadLine();

                Console.WriteLine("Enter your password: ");
                var password = Console.ReadLine();

                user = customerBackend.TryLogin(username, password);

                if (user != null)
                {
                    MainProgram(user);

                }
                else
                {
                    Console.WriteLine("Something wrong, try again");
                    Console.ReadLine();
                }

            }

        }


        static void MainProgram(User user)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome " + user.UserPrivateInfo.FirstName + " !");
                Console.WriteLine("What do you want to do today?" + "\n");
                Console.WriteLine("1. See list of all avaliable packages: ");
                Console.WriteLine("2. See purchase history ");
                Console.WriteLine("3. Exit ");

                var optionKey = Console.ReadKey();

                if (optionKey.Key == ConsoleKey.D1)
                {
                    SeePackagesList();
                    Console.WriteLine("Would you like to buy one? (Yes/No)");
                    var option = Console.ReadLine();
                    if (option == "yes")
                    {
                        BuyFoodPackage(user);
                    }
                    else
                    {
                        Console.WriteLine("OK, next time then");
                        Console.WriteLine("Press enter to go to main menu");
                    }

                }

                if (optionKey.Key == ConsoleKey.D2)
                {
                    PurchaseHistory(user);

                }

                if (optionKey.Key == ConsoleKey.D3)
                {
                    Environment.Exit(0);
                }

                Console.ReadLine();
            }


        }

        static void BuyFoodPackage(User user)
        {
            CustomerBackend customerBackend = new CustomerBackend();

            Console.WriteLine("Choose which one would you like to buy, enter food package number");

            var choice = int.Parse(Console.ReadLine());

            var chosenFoodPackage = customerBackend.TryToBuyFoodPackage(choice, user);

            if (chosenFoodPackage != null)
            {
                Console.WriteLine("You bought: ");
                Console.WriteLine("Meal name: " + chosenFoodPackage.MealName + ";" +
                                  " Price: " + chosenFoodPackage.PackagePrice + ";");
                Console.WriteLine();
                Console.WriteLine("Press enter to go to main menu");
            }

        }

        static void SeePackagesList()
        {

            Console.Clear();

            CustomerBackend customerBackend = new CustomerBackend();

            Console.WriteLine("Write down kategory: " + "\n" +
                              "Kött;  Vego; Fisk;");

            var category = Console.ReadLine();

            var foodPackages = customerBackend.CheckUnsoldPackages(category);

            if (foodPackages != null)
            {
                Console.WriteLine("Here is avaliable food packages av category" + " " + category + "\n");

                foreach (var item in foodPackages)
                {
                    Console.WriteLine("Package number:" + item.FoodPackageId + ". " + "Meal name: " + item.MealName + "; " +
                                      " Price: " + item.PackagePrice + "; " +
                                      " Category: " + item.FoodCategory + ";");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No avaliable packages av category " + category);
                Console.WriteLine("Press enter and choose different category");
                Console.ReadLine();
                SeePackagesList();

            }
        }

        static void PurchaseHistory(User user)
        {
            Console.Clear();
            CustomerBackend customerBackend = new CustomerBackend();

            Console.WriteLine("Your purchase history " + user.UserPrivateInfo.FirstName);

            var salesPerCustomer = customerBackend.PurchaseHistory(user);

            if (salesPerCustomer != null)
            {
                Console.WriteLine("You bought " + salesPerCustomer.Count + " food packages" + "\n");

                foreach (var item in salesPerCustomer)
                {
                    Console.WriteLine("Meal name: " + item.FoodPackage.MealName + ";" +
                                      "Price: " + item.FoodPackage.PackagePrice + ";" +
                                      "Purchase date: " + item.PurchaseDate + ";");

                }
                Console.WriteLine("\n"+ "Press enter to go to main menu");
            }
            else
            {
                Console.WriteLine("Sorry, your purchase history is empty");
                Console.WriteLine("Press enter to go to main menu");
            }

        }
    }
}