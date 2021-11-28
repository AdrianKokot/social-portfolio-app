using Microsoft.AspNetCore.Http;
using Sociussion.Data.Collections;
using Sociussion.Helpers;

namespace Sociussion.Extensions
{
    public static class AddNavigationHeadersToHttpResponse
    {
        public static void AddNavigationHeaders(this HttpResponse response, PaginationMetadata metadata)
        {
            response.Headers.Add("X-Pagination", AppJsonSerializer.Serialize(metadata));
        }
    }
}
