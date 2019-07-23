using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IProvinceService
    {
        Task<BaseResultStatus> AddAsync(ProvinceCreateDto model, CancellationToken cancellationToken);
        Task<BaseResultStatus> DeleteAsync(int provinceId, CancellationToken cancellationToken);
        Task<List<ProvinceSelectDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
