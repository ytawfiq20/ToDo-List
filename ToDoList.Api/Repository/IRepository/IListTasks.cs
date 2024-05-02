using ToDoList.Shared.Entities;

namespace ToDoList.Api.Repository.IRepository
{
    public interface IListTasks
    {
        ListTasks AddTask(ListTasks task);
        ListTasks UpdateTask(ListTasks task);
        ListTasks DeleteTask(Guid id);
        ListTasks GetTaskById(Guid id);
        IEnumerable<ListTasks> GetAllTasks();
        IEnumerable<ListTasks> GetTasksByListId(Guid listId);
    }
}
