using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sociussion.Application.Common.Interfaces;

namespace Sociussion.Application.Common.Models;

public class PaginatedList<T>
{
    public List<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public int Count { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        TotalCount = count;
        Items = items;
        Count = items.Count;
    }
}

public static class PaginatedList
{
    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }

    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, IQueryParams paginationParams)
    {
        return await CreateAsync(source, paginationParams.Page, paginationParams.PageSize);
    }

    public static async Task<PaginatedList<T>> CreateAndOrderAsync<T>(IQueryable<T> source,
        IQueryParams paginationParams)
    {
        if (paginationParams.OrderBy != string.Empty)
        {
            var split = paginationParams.OrderBy.Split(" ");
            var propertyName = TypeDescriptor.GetProperties(typeof(T)).Find(split[0], true)?.Name;

            Console.WriteLine(split);
            if (propertyName is not null)
            {
                var isAscending = (split.Length == 1 ? "desc" : split[1]) == "asc";
                Console.WriteLine($"Order by {propertyName} {isAscending}");

                var parameter = Expression.Parameter(typeof(T));
                var property = Expression.Property(parameter, propertyName);
                var propAsObj = Expression.Convert(property, typeof(object));
                var orderExpression = Expression.Lambda<Func<T, object>>(propAsObj, parameter);

                source = isAscending ? source.OrderBy(orderExpression) : source.OrderByDescending(orderExpression);
            }
        }


        return await CreateAsync(source, paginationParams);
    }
}