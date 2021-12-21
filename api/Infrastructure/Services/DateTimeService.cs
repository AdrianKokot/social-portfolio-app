using Sociussion.Application.Common.Interfaces;

namespace Sociussion.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}