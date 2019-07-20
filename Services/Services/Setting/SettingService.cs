using Data.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class SettingService : ISettingService
    {
        private readonly IRepository<Setting> _repository;

        public SettingService(IRepository<Entities.Setting> repository)
        {
            _repository = repository;
        }

        public Task<bool> EditAsync(CancellationToken cancellationToken, Setting setting)
        {
            throw new System.NotImplementedException();
        }

        public Task<Setting> GetAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
