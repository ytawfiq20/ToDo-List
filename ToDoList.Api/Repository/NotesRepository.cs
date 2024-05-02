using Microsoft.EntityFrameworkCore;

using ToDoList.Api.Data;
using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Repository
{
    public class NotesRepository : INotes
    {
        private readonly ApplicationDbContext dbContext;
        public NotesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TaskNotes AddNote(TaskNotes note)
        {
            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
            return note;
        }

        public TaskNotes DeleteNote(Guid noteId)
        {
            TaskNotes note = GetNoteById(noteId);
            if (note == null)
            {
                return null;
            }
            dbContext.Notes.Remove(note);
            dbContext.SaveChanges();
            return note;
        }

        public IEnumerable<TaskNotes> GetAllNotes()
        {
            IEnumerable<TaskNotes> notes = dbContext.Notes.Include(e=>e.Task).ToList();
            if(notes == null)
            {
                return null;
            }
            return notes;
        }

        public IEnumerable<TaskNotes> GetAllNotesByTaskId(Guid taskId)
        {
            IEnumerable<TaskNotes> notes = from note in GetAllNotes()
                                           where note.TaskId == taskId
                                           select note;
            if(notes == null)
            {
                return null;
            }
            return notes;
        }

        public TaskNotes GetNoteById(Guid noteId)
        {
            TaskNotes? note = dbContext.Notes.FirstOrDefault(e => e.Id == noteId);
            if(note == null)
            {
                return null;
            }
            return note;
        }

        public TaskNotes UpdateNote(TaskNotes note)
        {
            TaskNotes oldNote = GetNoteById(note.Id);
            oldNote.Note = note.Note;
            dbContext.SaveChanges();
            return oldNote;
        }
    }
}
