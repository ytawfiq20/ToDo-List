using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service.IService
{
    public interface ITaskNotes
    {
        Task AddNote(TaskNotes note);
        Task UpdateNote(TaskNotes note);
        Task DeleteNote(Guid noteId);
        Task<TaskNotes> GetNoteById(Guid noteId);
        Task<IEnumerable<TaskNotes>> GetAllNotes();
        Task<IEnumerable<TaskNotes>> GetAllNotesByTaskId(Guid taskId);
    }
}
