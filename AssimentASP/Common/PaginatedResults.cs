namespace AssimentASP.Common
{
    public class PaginatedResults<T>
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public string? SearchKeyword { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
