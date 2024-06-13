using WebAPI_All.Models.DomainModels;

namespace WebAPI_All.Models.DTO
{
    public class ResponseDepartmentAll : ResponseDepartment
    {
        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
