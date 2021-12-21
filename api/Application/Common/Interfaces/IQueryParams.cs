namespace Sociussion.Application.Common.Interfaces;

public interface IQueryParams
{
    int Page { get; set; }
    int PageSize { get; set; }
    string OrderBy { get; set; }
    string Filter { get; set; }
}