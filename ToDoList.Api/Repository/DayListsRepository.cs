using ToDoList.Api.Data;
using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;
using ToDoList.Shared.Validation;

namespace ToDoList.Api.Repository
{
    public class DayListsRepository : IDayLists
    {
        private readonly ApplicationDbContext dbContext;
        
        public DayListsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DayLists AddNewList(DayLists list)
        {
            dbContext.Lists.Add(list);
            dbContext.SaveChanges();
            return list;
        }

        public DayLists DeleteList(Guid id)
        {
            DayLists dayLists = GetListById(id);
            if (dayLists == null)
            {
                return null;
            }
            dbContext.Lists.Remove(dayLists);
            dbContext.SaveChanges();
            return dayLists;
        }

        public IEnumerable<DayLists> GetAllLists()
        {
            IEnumerable<DayLists> lists = dbContext.Lists.ToList();
            return lists == null ? null : lists;
        }

        public DayLists GetListById(Guid id)
        {
            DayLists? list = dbContext.Lists.FirstOrDefault(e => e.Id == id);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public DayLists UpdateList(DayLists list)
        {
            DayLists OldList = GetListById(list.Id);
            if (OldList == null)
            {
                return null;
            }
            OldList.ListDay = list.ListDay;
            OldList.ListName = list.ListName;
            dbContext.SaveChanges();
            return OldList;
        }
    }
}
