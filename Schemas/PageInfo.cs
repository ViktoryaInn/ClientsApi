using ClientsApi.Enums;

namespace ClientsApi.Schemas
{
    public class PageInfo
    {
        public string SortBy { get; set; } = "createdAt";
        public string Query { get; set; } = "";
        public SortingDirection SortDir { get; set; } = SortingDirection.Desc;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}