using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared.Entities
{
    public class TaskNotes
    {
        public Guid Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public Guid TaskId { get; set; }
        public ListTasks? Task { get; set; }
        
    }
}
