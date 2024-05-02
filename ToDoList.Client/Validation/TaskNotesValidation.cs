using FluentValidation;

using ToDoList.Shared.Entities;

namespace ToDoList.Client.Validation
{
    public class TaskNotesValidation : AbstractValidator<TaskNotes>
    {
        public TaskNotesValidation()
        {
            RuleFor(e => e.Note).NotEmpty().NotNull();
        }
    }
}
