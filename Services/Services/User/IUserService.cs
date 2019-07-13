using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<AccessToken> TokenAsync(string username, string password, CancellationToken cancellationToken);
    }
}
