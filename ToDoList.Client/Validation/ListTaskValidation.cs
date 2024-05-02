using FluentValidation;

using ToDoList.Shared.Entities;

namespace ToDoList.Client.Validation
{
    public class ListTaskValidation :AbstractValidator<ListTasks>
    {
        public ListTaskValidation()
        {
            RuleFor(e => e.ListId).NotEmpty();
            RuleFor(e => e.TaskName).NotEmpty().NotNull();
            RuleFor(e => e.TaskDescription).NotNull().NotEmpty();
        }
    }
}
