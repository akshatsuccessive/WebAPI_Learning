using FluentValidation;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Validators
{
    public class EmployeeValidator : AbstractValidator<AddEmployeeRequest>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Please Enter a Name")
               .Length(3, 20).WithMessage("The Name should be between 3 and 20 characters")
               .Must(name => !name.Any(char.IsDigit)).WithMessage("The Name should not contain numeric values");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Please Enter a Age")
                .GreaterThan(18).WithMessage("The Age should be greater then 18");

            RuleFor(x => x.Address)
               .NotEmpty().WithMessage("Please Enter a Address")
               .Length(3, 20).WithMessage("The Address should be between 3 and 20 characters");

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Please Enter a Salary")
                .GreaterThan(10000).WithMessage("The Salary should be greater then 10000");

            RuleFor(x => x.Designation)
               .NotEmpty().WithMessage("Please Enter a Designation")
               .Length(3, 20).WithMessage("The Designation should be between 3 and 20 characters");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Please enter a department Id");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Plese enter a Project id");
        }
    }
    public class EditEmployeeValidator : AbstractValidator<EditEmployeeRequest>
    {
        public EditEmployeeValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Please Enter a Name")
               .Length(3, 20).WithMessage("The Name should be between 3 and 20 characters")
               .Must(name => !name.Any(char.IsDigit)).WithMessage("The Name should not contain numeric values");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Please Enter a Age")
                .GreaterThan(18).WithMessage("The Age should be greater then 18");

            RuleFor(x => x.Address)
               .NotEmpty().WithMessage("Please Enter a Address")
               .Length(3, 20).WithMessage("The Address should be between 3 and 20 characters");

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Please Enter a Salary")
                .GreaterThan(10000).WithMessage("The Salary should be greater then 10000");

            RuleFor(x => x.Designation)
               .NotEmpty().WithMessage("Please Enter a Designation")
               .Length(3, 20).WithMessage("The Designation should be between 3 and 20 characters");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Please enter a department Id");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Plese enter a Project id");
        }
    }
}
