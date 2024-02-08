using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service.IService
{
    public interface IDayLists
    {
        Task AddNewList(DayLists list);
        Task UpdateList(DayLists list);
        Task DeleteList(Guid id);
        Task<DayLists> GetListById(Guid id);
        Task<IEnumerable<DayLists>> GetAllLists();
    }
}
