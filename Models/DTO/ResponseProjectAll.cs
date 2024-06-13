using WebAPI_All.Models.DomainModels;

namespace WebAPI_All.Models.DTO
{
    public class ResponseProjectAll
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
