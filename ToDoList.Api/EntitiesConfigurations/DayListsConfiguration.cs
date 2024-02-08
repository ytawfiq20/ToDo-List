using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ToDoList.Shared.Entities;

namespace ToDoList.Api.EntitiesConfigurations
{
    public class DayListsConfiguration : IEntityTypeConfiguration<DayLists>
    {
        public void Configure(EntityTypeBuilder<DayLists> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.ListName).HasDefaultValue("New List").IsRequired();
            builder.Property(e => e.ListDay).HasDefaultValue(DateTime.Today);
            builder.HasMany(e => e.Tasks).WithOne(e => e.dayList).HasForeignKey(e => e.ListId);
        }
    }
}
