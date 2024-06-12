namespace WebAPI_All.Models.DTO
{
    public class EditProjectRequest
    {
        public string ProjectName { get; set; } = null!;
        public DateTime Deadline { get; set; }
    }
}
