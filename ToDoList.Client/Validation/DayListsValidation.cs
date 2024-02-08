using FluentValidation;

using ToDoList.Shared.Entities;

namespace ToDoList.Client.Validation
{
    public class DayListsValidation : AbstractValidator<DayLists>
    {
        public DayListsValidation()
        {
            RuleFor(e => e.ListName).NotNull().NotEmpty();
        }
    }
}
