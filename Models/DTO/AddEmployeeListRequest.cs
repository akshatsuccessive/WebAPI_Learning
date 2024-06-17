namespace WebAPI_All.Models.DTO
{
    public class AddEmployeeListRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; } = "asc";
    }
}
