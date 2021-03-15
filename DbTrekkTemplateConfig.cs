using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomeloPrimaryKeyBug
{
    internal sealed class DbTrekkTemplateConfig : IEntityTypeConfiguration<DbTrekkTemplate>
    {
        public void Configure([NotNull] EntityTypeBuilder<DbTrekkTemplate> b)
        {
            b.ToTable("tasks");
            b.HasKey(p => p.Id);
            b.Property(p => p.Id).IsRequired().HasColumnName("tasks_id");

            b.HasMany(p => p.Users).WithMany(p => p.Templates).UsingEntity<DbTrekkTemplateUser>(
                r => r.HasOne(p => p.Worker).WithMany().HasForeignKey(p => p.WorkerId),
                r => r.HasOne(p => p.TrekkTemplate).WithMany().HasForeignKey(p => p.TrekkTemplateId));
        }
    }
}