using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI_All.Models.DomainModels
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public double Salary { get; set; }
        public string Designation { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Departments { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; } = null!;
    }
}
