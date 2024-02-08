using Microsoft.EntityFrameworkCore;

using ToDoList.Api.Data;
using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Repository
{
    public class ListTasksRepository : IListTasks
    {
        private readonly ApplicationDbContext dbContext;
        public ListTasksRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ListTasks AddTask(ListTasks task)
        {
            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();
            return task;
        }

        public ListTasks DeleteTask(Guid id)
        {
            ListTasks task = GetTaskById(id);
            if (task == null)
            {
                return null;
            }
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
            return task;
        }

        public IEnumerable<ListTasks> GetAllTasks()
        {
            IEnumerable<ListTasks> tasks = dbContext.Tasks.Include(e=>e.dayList).ToList();
            return tasks == null ? null : tasks;
        }

        public ListTasks GetTaskById(Guid id)
        {
            ListTasks? task = dbContext.Tasks.FirstOrDefault(e => e.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public IEnumerable<ListTasks> GetTasksByListId(Guid listId)
        {
            IEnumerable<ListTasks>? listTasks = from list in GetAllTasks()
                                               where list.ListId == listId
                                               select list;
            if(listTasks == null)
            {
                return null;
            }
            return listTasks;
        }

        public ListTasks UpdateTask(ListTasks task)
        {
            ListTasks oldtask = GetTaskById(task.Id);
            if(oldtask == null)
            {
                return null;
            }
            oldtask.TaskName = task.TaskName;
            oldtask.TaskDescription = task.TaskDescription;
            oldtask.StartingAt = task.StartingAt;
            oldtask.EndingAt = task.EndingAt;
            oldtask.IsDone = task.IsDone;
            dbContext.SaveChanges();
            return oldtask;
        }
    }
}
