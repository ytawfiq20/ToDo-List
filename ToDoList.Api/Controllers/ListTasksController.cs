using System.ComponentModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.Data;
using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListTasksController : ControllerBase
    {

        private readonly IListTasks tasksRepo;
        public ListTasksController(IListTasks tasksRepo)
        {
            this.tasksRepo = tasksRepo;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ListTasks>> GetAllTasks()
        {
            try
            {
                if (tasksRepo.GetAllTasks == null)
                {
                    return NoContent();
                }
                return Ok(tasksRepo.GetAllTasks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{id:Guid}")]
        public ActionResult<ListTasks> GetTaskById(Guid id)
        {
            try
            {
                ListTasks task = tasksRepo.GetTaskById(id);
                if(task == null)
                {
                    return NotFound();
                }
                return task;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("[action]/{listId:Guid}")]
        public ActionResult<IEnumerable<ListTasks>> GetTasksByListId(Guid listId)
        {
            try
            {
                IEnumerable<ListTasks> tasks = tasksRepo.GetTasksByListId(listId);
                if (tasks == null)
                {
                    return NoContent();
                }
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("[action]")]
        public ActionResult<ListTasks> UpdateTask(ListTasks task)
        {
            try
            {
                ListTasks oldtask = tasksRepo.GetTaskById(task.Id);
                if (task == null)
                {
                    return NotFound();
                }
                tasksRepo.UpdateTask(task);
                return task;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("[action]/{id:Guid}")]
        public ActionResult<ListTasks> DeleteTask(Guid id)
        {
            try
            {
                ListTasks task = tasksRepo.GetTaskById(id);
                if (task == null)
                {
                    return NotFound();
                }
                tasksRepo.DeleteTask(id);
                return task;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ListTasks> AddTask([FromBody] ListTasks task)
        {
            try
            {
                if (task == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                tasksRepo.AddTask(task);
                return task;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
