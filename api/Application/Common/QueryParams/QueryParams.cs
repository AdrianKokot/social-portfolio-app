using Sociussion.Application.Common.Interfaces;

namespace Sociussion.Application.Common.QueryParams;

public class QueryParams : IQueryParams
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int Page { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public string OrderBy { get; set; } = string.Empty;
    public string Filter { get; set; } = string.Empty;
}