using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared.Entities
{
    public class DayLists
    {
        public Guid Id { get; set; }
        public string ListName { get; set; } = string.Empty;
        public DateTime ListDay { get; set; } = DateTime.Today;
        public ICollection<ListTasks>? Tasks { get; set; }
    }
}
