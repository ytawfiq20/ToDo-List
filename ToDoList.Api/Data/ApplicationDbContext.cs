using Microsoft.EntityFrameworkCore;

using ToDoList.Api.EntitiesConfigurations;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DayListsConfiguration())
                        .ApplyConfiguration(new ListTasksConfigurations())
                        .ApplyConfiguration(new TaskNotesConfiguration());
        }

        public DbSet<DayLists> Lists { get; set; }
        public DbSet<ListTasks> Tasks { get; set; }
        public DbSet<TaskNotes> Notes { get; set; }
    }
}
