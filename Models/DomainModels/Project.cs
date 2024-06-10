using System.ComponentModel.DataAnnotations;

namespace WebAPI_All.Models.DomainModels
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;    
        public DateOnly Deadline { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
