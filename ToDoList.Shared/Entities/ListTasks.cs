using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared.Entities
{
    public class ListTasks
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TaskName { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
        public DateTime StartingAt { get; set; } = DateTime.Now;
        public DateTime EndingAt { get; set; } = DateTime.Now;
        public DayLists? dayList { get; set; }
        public Guid ListId { get; set; }
        public bool IsDone { get; set; } = false;
        public ICollection<TaskNotes>? Notes { get; set; }
    }
}
