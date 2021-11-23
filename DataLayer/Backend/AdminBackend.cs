using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;

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
    }
}
