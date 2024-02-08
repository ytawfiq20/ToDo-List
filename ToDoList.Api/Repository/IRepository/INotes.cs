using ToDoList.Shared.Entities;

namespace ToDoList.Api.Repository.IRepository
{
    public interface INotes
    {
        TaskNotes AddNote(TaskNotes note);
        TaskNotes UpdateNote(TaskNotes note);
        TaskNotes DeleteNote(Guid noteId);
        TaskNotes GetNoteById(Guid noteId);
        IEnumerable<TaskNotes> GetAllNotes();
        IEnumerable<TaskNotes> GetAllNotesByTaskId(Guid taskId);
    }
}
