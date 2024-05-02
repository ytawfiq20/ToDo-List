using ToDoList.Shared.Entities;

namespace ToDoList.Api.Repository.IRepository
{
    public interface IDayLists
    {
        DayLists AddNewList(DayLists list);
        DayLists DeleteList(Guid id);
        DayLists UpdateList(DayLists list);
        DayLists GetListById(Guid id);
        IEnumerable<DayLists> GetAllLists();
    }
}
