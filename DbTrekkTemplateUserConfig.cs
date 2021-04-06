using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomeloPrimaryKeyBug
{
    internal sealed class DbTrekkTemplateUserConfig : IEntityTypeConfiguration<DbTrekkTemplateUser>
    {
        public void Configure([NotNull] EntityTypeBuilder<DbTrekkTemplateUser> b)
        {
            b.ToTable("tasks_workers");
            //b.HasKey(p => p.Id); // 1. InititalMigration
            b.HasKey(p => new { p.TrekkTemplateId, p.WorkerId }); // 2. ChangeDbTrekkTemplateUserKey

            b.Property(p => p.TrekkTemplateId).IsRequired().HasColumnName("TrekkTemplateId");
            b.HasOne(p => p.TrekkTemplate).WithMany().HasForeignKey(p => p.TrekkTemplateId)
                .OnDelete(DeleteBehavior.Cascade).HasConstraintName("TemplateContainsTemplateWorkers");

            b.Property(p => p.WorkerId).IsRequired().HasColumnName("WorkerId");
            b.HasOne(p => p.Worker).WithMany().HasForeignKey(p => p.WorkerId)
                .OnDelete(DeleteBehavior.Cascade).HasConstraintName("WorkerContainsTemplateWorkers");
        }
    }
}