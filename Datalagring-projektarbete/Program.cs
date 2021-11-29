// See https://aka.ms/new-console-template for more information

using DataLayer;
using DataLayer.Model;
using DataLayer.Backend;
using System.Diagnostics;
using System.Threading;


AdminBackend.PrepareDatabase();

Console.WriteLine("Skapade databasen!");
/*
Thread.Sleep(1000);

Console.Clear();
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("Input your username");
var username = Console.ReadLine();
Console.WriteLine("Input your password");
var password = Console.ReadLine();


var loginManager = new LoginManager();

var user = loginManager.Login(username, password);

Console.WriteLine("Hello {0}! What would you like to access today?", user.UserPrivateInfo.FirstName);
Console.WriteLine("1. CustomerClient. \n  2. AdminClient \n 3. RestaurantClient");

int? choice = Int32.Parse(Console.ReadLine());
switch (choice)
{
    case 1:
        string path1 = @"C:\Users\Hargaaya\Source\Repos\Nettan86\Datalagring-Projektarbete\CustomerClient\Program.cs";
        Process.Start(path1);
        break;

    case 2:
        string path2 = @"C:\Users\Hargaaya\Source\Repos\Nettan86\Datalagring-Projektarbete\AdminClient\Program.cs";
        Process.Start(path2);
        break;

    case 3:
        string path3 = @"C:\Users\Hargaaya\Source\Repos\Nettan86\Datalagring-Projektarbete\RestaurantClient\Program.cs";
        Process.Start(path3);
        break;

    case null:
        Console.WriteLine("Input incorrect, end program!");
        break;
}
*/