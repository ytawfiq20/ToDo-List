using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared.Validation
{
    public static class DateValidation
    {
        public static bool ValidateDate(DateTime date)
        {
            string currDay = DateTime.Today.ToString().Split("T")[0];
            string inputDay = date.ToString().Split("T")[0];
            if (string.Compare(inputDay, currDay) < 0)
            {
                return false;
            }
            string inputYear = date.Year.ToString();
            string currYear = DateTime.Now.Year.ToString();
            if (string.Compare(inputYear, currYear) < 0 || string.Compare(inputYear, currYear) > 0)
            {
                return false;
            }
            return true;
        }

        public static bool IsOldDate(DateTime date)
        {
            string currDay = DateTime.Today.ToString().Split(" ")[0];
            string inputDay = date.ToString().Split(" ")[0];
            if (string.Compare(inputDay, currDay) < 0)
            {
                return true;
            }
            return false;
        }
    }
}
