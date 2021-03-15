using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace PomeloPrimaryKeyBug
{
    public sealed class MyDbContext : DbContext
    {
        [NotNull, ItemNotNull]
        public DbSet<DbWorker> Workers { get; [UsedImplicitly] private set; }
        [NotNull, ItemNotNull]
        public DbSet<DbTrekkTemplate> TrekkTemplates { get; [UsedImplicitly] private set; }
        [NotNull, ItemNotNull]
        public DbSet<DbTrekkTemplateUser> TrekkTemplateUsers { get; [UsedImplicitly] private set; }

        [UsedImplicitly]
        // ReSharper disable once NotNullMemberIsNotInitialized
        public MyDbContext([NotNull] DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating([NotNull] ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.ApplyConfiguration(new DbWorkerConfig());
            mb.ApplyConfiguration(new DbTrekkTemplateConfig());
            mb.ApplyConfiguration(new DbTrekkTemplateUserConfig());
        }
    }
}