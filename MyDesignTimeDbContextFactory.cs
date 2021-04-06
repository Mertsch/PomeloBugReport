using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace PomeloPrimaryKeyBug
{
    public sealed class MyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        [NotNull, UsedImplicitly]
        public MyDbContext CreateDbContext([CanBeNull, ItemCanBeNull] string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<MyDbContext>((_, b) =>
            {
                b.UseMySql("Server=localhost;Port=3306;Database=RepoBugDb;User=RepoBugDb;Password=RepoBugDb;",
                    new MariaDbServerVersion(new Version(10, 2, 34)),
                    options =>
                    {
                        options.CharSet(CharSet.Utf8Mb4); // We can not (yet) use a collation here
                        //options.CharSetBehavior(CharSetBehavior.NeverAppend); // Use the DB default instead
                    });
            });

            MyDbContext db = services.BuildServiceProvider().GetRequiredService<MyDbContext>();
            db.Database.ExecuteSqlRaw("ALTER DATABASE CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_520_ci"); // Use a different collation than the default one
            return db;
        }
    }
}