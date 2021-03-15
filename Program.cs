using System;
using Microsoft.EntityFrameworkCore;

namespace PomeloPrimaryKeyBug
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("BUG!");
            MyDbContext db = new MyDesignTimeDbContextFactory().CreateDbContext(null);
            try
            {
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}