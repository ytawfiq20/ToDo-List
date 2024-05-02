using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskNotesController : ControllerBase
    {
        private readonly INotes notesRepo;
        public TaskNotesController(INotes notesRepo)
        {
            this.notesRepo = notesRepo;
        }
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<TaskNotes>> GetAllNotes()
        {
            try
            {
                if (notesRepo.GetAllNotes() == null)
                {
                    return NoContent();
                }
                return Ok(notesRepo.GetAllNotes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{taskId:Guid}")]
        public ActionResult<IEnumerable<TaskNotes>> GetAllNotesByTaskId(Guid taskId)
        {
            try
            {
                if (notesRepo.GetAllNotesByTaskId(taskId) == null)
                {
                    return NoContent();
                }
                return Ok(notesRepo.GetAllNotesByTaskId(taskId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{noteId:Guid}")]
        public ActionResult<TaskNotes> GetNoteById(Guid noteId)
        {
            try
            {
                if (notesRepo.GetNoteById(noteId) == null)
                {
                    return NotFound();
                }
                return notesRepo.GetNoteById(noteId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("[action]")]
        public ActionResult<TaskNotes> AddNote(TaskNotes note)
        {
            try
            {
                if (note == null)
                {
                    return BadRequest();
                }
                notesRepo.AddNote(note);
                return note;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("[action]")]
        public ActionResult<TaskNotes> UpdateNote(TaskNotes note)
        {
            try
            {
                if (notesRepo.GetNoteById(note.Id) == null)
                {
                    return NotFound();
                }
                notesRepo.UpdateNote(note);
                return note;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("[action]/{noteId:Guid}")]
        public ActionResult<TaskNotes> DeleteNote(Guid noteId)
        {
            try
            {
                TaskNotes note = notesRepo.GetNoteById(noteId);
                if (note == null)
                {
                    return NotFound();
                }
                notesRepo.DeleteNote(noteId);
                return note;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
