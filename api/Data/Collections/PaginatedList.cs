using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sociussion.Data.Repositories;

namespace Sociussion.Data.Collections
{
    public class PaginatedList<T> : List<T>
    {
        public PaginationMetadata Metadata { get; init; }

        public PaginatedList(IEnumerable<T> items, int totalItemsCount, int currentPage, int pageSize)
        {
            Metadata = new PaginationMetadata
            {
                TotalCount = totalItemsCount,
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalPages = (int)Math.Ceiling((totalItemsCount / (double)pageSize))
            };

            AddRange(items);
        }
        
        public static async Task<PaginatedList<T>> FromQueryableAsync(IQueryable<T> queryable,
            PaginationParams paginationParams)
        {
            var totalItemsCount = queryable.Count();

            var items = queryable
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);

            return new PaginatedList<T>(await items.ToListAsync(), totalItemsCount, paginationParams.Page,
                paginationParams.PageSize);
        }
    }
}
