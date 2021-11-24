namespace Sociussion.Data.Collections
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
    }
}
