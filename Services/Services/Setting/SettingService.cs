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
        public async Task<bool> EditAsync(CancellationToken cancellationToken, Setting setting)
        {
            try
            {
                Setting model = await _repository.Table.Where(c => c.Id == 1).SingleOrDefaultAsync(cancellationToken);
                model.Amount_Of_Punishment_For_Reserving_The_Book = setting.Amount_Of_Punishment_For_Reserving_The_Book;
                model.Amount_Of_Punishment_For_Returning_The_Book = setting.Amount_Of_Punishment_For_Returning_The_Book;
                model.BorrowDay = setting.BorrowDay;
                model.ReservCount = setting.ReservCount;
                model.ReservDay = setting.ReservDay;

                await _repository.UpdateAsync(model, cancellationToken);
                return true;
            }
            catch
            {

                return false;
            }

        }

        public async Task<Setting> GetAsync(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking.Where(c => c.Id == 1).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
