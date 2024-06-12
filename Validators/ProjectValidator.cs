using FluentValidation;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Validators
{
    public static class ValidationHelpers
    {
        public static bool IsValidFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
    public class ProjectValidator : AbstractValidator<AddProjectRequest>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Please Enter a Department Name")
                .Length(3, 20).WithMessage("Department Name should be between 3 and 20 characters");

            RuleFor(x => x.Deadline)
                .Must(ValidationHelpers.IsValidFutureDate).WithMessage("Deadline should be a future date");
        }
    }

    public class EditProjectValidator : AbstractValidator<EditProjectRequest>
    {
        public EditProjectValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Please Enter a Department Name")
                .Length(3, 20).WithMessage("Department Name should be between 3 and 20 characters");

            RuleFor(x => x.Deadline)
                .Must(ValidationHelpers.IsValidFutureDate).WithMessage("Deadline should be a future date");
        }
    }
}
