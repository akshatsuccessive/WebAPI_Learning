using FluentValidation;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Validators
{
    public class DepartmentValidator : AbstractValidator<AddDepartmentRequest>
    {
        public DepartmentValidator() 
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Please Enter a Department Name")
                .Length(3, 20).WithMessage("Department Name should be between 3 and 20 characters");
        }
    }

    public class EditDepartmentValidator : AbstractValidator<EditDepartmentRequest>
    {
        public EditDepartmentValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Please Enter a Department Name")
                .Length(3, 20).WithMessage("Department Name should be between 3 and 20 characters");
        }
    }
}
