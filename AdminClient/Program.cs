using DataLayer;

while (true)
{

    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.Clear();


    Console.WriteLine("Welcome! What would you do today?");

    Console.WriteLine("\n\n1. Reset database");
    Console.WriteLine("2. See user list");
    Console.WriteLine("3. See restaurant list");
    Console.WriteLine("4. Add new restaurant");

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

        Console.WriteLine("Restaurants: ");


        foreach (var restaurant in restaurantlist)
        {
            Console.WriteLine(" " + " " + restaurant.RestaurantName
                + " " + restaurant.RestaurantAddress + "" + restaurant.PhoneNumber);
        }
        Console.WriteLine("\n\nPress enter to return to menu");
    }




    if (options == "4")
    {
        AdminBackend adminBackend = new AdminBackend();




    }

    Console.ReadLine();
}