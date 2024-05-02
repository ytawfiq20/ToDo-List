using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Api.Repository.IRepository;
using ToDoList.Shared.Entities;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IDayLists dayRepo;
        public ListController(IDayLists dayRepo)
        {
            this.dayRepo = dayRepo;
        }
        [HttpPost("[action]")]
        public ActionResult<DayLists> AddList([FromBody] DayLists list)
        {
            try
            {
                if (list == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Can't add null list");
                }
                dayRepo.AddNewList(list);
                return list;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding this list");
            }
        }

        [HttpPut("[action]")]
        public ActionResult<DayLists> UpdateList([FromBody] DayLists list)
        {
            try
            {
                DayLists dayList = dayRepo.GetListById(list.Id);
                if(dayList == null)
                {
                    return NotFound();
                }
                dayRepo.UpdateList(list);
                return list;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Can't Update this list");
            }
        }
        [HttpDelete("[action]/{id:Guid}")]
        public ActionResult<DayLists> DeleteList(Guid id)
        {
            try
            {
                DayLists dayList = dayRepo.GetListById(id);
                if (dayList == null)
                {
                    return NotFound();
                }
                dayRepo.DeleteList(id);
                return dayList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Can't Delete this list");
            }
        }
        [HttpGet("[action]/{id:Guid}")]
        public ActionResult<DayLists> GetListById(Guid id)
        {
            try
            {
                DayLists dayList = dayRepo.GetListById(id);
                if (dayList == null)
                {
                    return NotFound();
                }
                return dayList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Can't Find this list");
            }
        }
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DayLists>> GetAllLists()
        {
            try
            {
                IEnumerable<DayLists> Lists = dayRepo.GetAllLists(); 
                if (Lists == null)
                {
                    return NoContent();
                }
                return Ok(Lists);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No Content found");
            }
        }
    }
}
