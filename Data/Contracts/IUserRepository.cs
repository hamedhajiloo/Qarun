using Data.Repositories;
using Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task UpdateLastLoginDateAsync(User user, CancellationToken requestAborted);
    }
}
