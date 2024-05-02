using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service.IService
{
    public interface IListTasks
    {
        Task AddTask(ListTasks task);
        Task DeleteTask(Guid id);
        Task UpdateTask(ListTasks task);
        Task<ListTasks> GetTaskById(Guid id);
        Task<IEnumerable<ListTasks>> GetAllTasks();
        Task<IEnumerable<ListTasks>> GetAllTasksByListId(Guid listId);
    }
}
