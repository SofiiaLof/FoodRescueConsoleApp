using System.Reflection.Metadata.Ecma335;
using DataLayer;
using DataLayer.Model;


while (true)
{

    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.Clear();


    Console.WriteLine("\n               Welcome! What would you do today?");
    Console.WriteLine("\n                     1. Reset database");
    Console.WriteLine("                     2. See user list");
    Console.WriteLine("                     3. See restaurant list");
    Console.WriteLine("                     4. Add new restaurant");
    
    var options = Console.ReadLine();

    if (options == "1")
    {
        AdminBackend.PrepareDatabase();

        Console.WriteLine("The database has been restored" +
                          "\n\n Press enter to return to menu");

    }




    if (options == "2")
    {
        AdminBackend adminbackend = new AdminBackend();

        var customerlist = adminbackend.UserList();

        Console.WriteLine("Customer list: ");

        foreach (var customer in customerlist)
        {


            Console.WriteLine("Id" + " " + customer.UserId +
                              " " + "Name" + " " + customer.UserPrivateInfo.FirstName + " " +
                              customer.UserPrivateInfo.LastName);

        }

        Console.WriteLine("\n\nPress enter to return to menu");
    }




    if (options == "3")
    {

        AdminBackend adminBackend = new AdminBackend();

        var restaurantlist = adminBackend.CheckRegisteredRestaurants();

        Console.WriteLine("Restaurants: \n");


        foreach (var restaurant in restaurantlist)
        {
            Console.WriteLine(" " + restaurant.RestaurantName
                                  + " " + restaurant.RestaurantAddress + "" + restaurant.PhoneNumber);
        }

        Console.WriteLine("\n\nPress enter to return to menu");
    }

    if (options == "4")
    {
        AdminBackend adminBackend = new AdminBackend();

        Console.WriteLine("Add a Restaurant: ");
        string restaurantName = Console.ReadLine();

        Console.WriteLine("Add a adress: ");
        string restaurantAdress = Console.ReadLine();

        Console.WriteLine("Add a email: ");
        string restaurantEmail = Console.ReadLine();

        Console.WriteLine("Add a phone number: ");
        string restaurantNumber = Console.ReadLine();



        var newRestaurant =
            adminBackend.AddNewRestaurant(restaurantName, restaurantAdress, restaurantEmail, restaurantNumber);

        if (newRestaurant != null)
        {
            Console.WriteLine("Restaurant name: " + newRestaurant.RestaurantName +
                              "\nRestaurant adress: " + newRestaurant.RestaurantAddress +
                              "\nRestaurant email: " + newRestaurant.EmailAddress +
                              "\nRestaurant phonenumber: " + newRestaurant.PhoneNumber);


            Console.WriteLine("\n\nPress enter to return to menu");


            Console.WriteLine();

        }

        Console.ReadLine();


    }
}
    Console.ReadLine();

