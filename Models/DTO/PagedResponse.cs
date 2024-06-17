namespace WebAPI_All.Models.DTO
{
    public class PagedResponse<T>
    {
        public int TotalCount { get; set; }
        public IList<T> Items { get; set; } = null!;
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }
    }
}
