using Sociussion.Domain.Entities;

namespace Sociussion.Application.Common.Interfaces;

public interface ITokenService
{
    Task<string> CreateJwtToken(ApplicationUser user);
}