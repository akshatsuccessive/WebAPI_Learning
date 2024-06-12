namespace WebAPI_All.Models.DTO
{
    public class EditEmployeeRequest
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public double Salary { get; set; }
        public string Designation { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int ProjectId { get; set; }
    }
}
