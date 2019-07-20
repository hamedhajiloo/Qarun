using Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ISettingService
    {
        Task<Setting> GetAsync(CancellationToken cancellationToken);
        Task<bool> EditAsync(CancellationToken cancellationToken, Setting setting);
    }
}
