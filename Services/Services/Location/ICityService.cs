using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ICityService
    {
        Task<BaseResultStatus> AddAsync(CityCreateDto model, CancellationToken cancellationToken);
        Task<BaseResultStatus> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<List<CitySelectDto>> GetAllAsync(int provinceId,CancellationToken cancellationToken);
    }
}
