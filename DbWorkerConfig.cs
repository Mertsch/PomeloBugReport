using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomeloPrimaryKeyBug
{
    internal sealed class DbWorkerConfig : IEntityTypeConfiguration<DbWorker>
    {
        public void Configure([NotNull] EntityTypeBuilder<DbWorker> b)
        {
            b.ToTable("workers");
            b.HasKey(p => p.Id);
            b.Property(p => p.Id).IsRequired().HasColumnName("workers_id");

            b.HasMany(p => p.Templates).WithMany(p => p.Users).UsingEntity<DbTrekkTemplateUser>(
                r => r.HasOne(p => p.TrekkTemplate).WithMany().HasForeignKey(p => p.TrekkTemplateId),
                r => r.HasOne(p => p.Worker).WithMany().HasForeignKey(p => p.WorkerId));
        }
    }
}