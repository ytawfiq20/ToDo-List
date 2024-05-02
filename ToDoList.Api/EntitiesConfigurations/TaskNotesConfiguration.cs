using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ToDoList.Shared.Entities;

namespace ToDoList.Api.EntitiesConfigurations
{
    public class TaskNotesConfiguration : IEntityTypeConfiguration<TaskNotes>
    {
        public void Configure(EntityTypeBuilder<TaskNotes> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.Note).IsRequired();
        }
    }
}
