using DataLayer;

Console.WriteLine("what would you like to do today?");
Console.WriteLine("1. Reset database");
Console.WriteLine("2. See user list");
Console.WriteLine("3. See restaurant list");
Console.WriteLine("4. Add new restaurant");

var options = Console.ReadLine();

if (options == "1")
{
    AdminBackend.PrepareDatabase();

}




if (options == "2")
{


}




if (options == "3")
{

}




if (options == "4")
{

}