using System.Threading.Tasks;
using Sociussion.Data.Models;

namespace Sociussion.Services.Token
{
    public interface ITokenService
    {
        Task<string> CreateJwtToken(ApplicationUser user);
    }
}
