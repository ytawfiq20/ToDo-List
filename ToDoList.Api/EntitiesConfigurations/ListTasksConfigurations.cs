using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ToDoList.Shared.Entities;

namespace ToDoList.Api.EntitiesConfigurations
{
    public class ListTasksConfigurations : IEntityTypeConfiguration<ListTasks>
    {
        public void Configure(EntityTypeBuilder<ListTasks> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.TaskName).HasDefaultValue("Task Name");
            builder.Property(e => e.TaskDescription).HasDefaultValue("Task Description");
            builder.Property(e => e.StartingAt).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.EndingAt).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ListId).IsRequired();
            builder.HasMany(e => e.Notes).WithOne(e => e.Task).HasForeignKey(e => e.TaskId);
        }
    }
}
