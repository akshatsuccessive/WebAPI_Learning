using System.ComponentModel.DataAnnotations;

namespace WebAPI_All.Models.DomainModels
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
