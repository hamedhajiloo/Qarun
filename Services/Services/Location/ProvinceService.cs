using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IRepository<Province> _repository;
        private readonly IRepository<City> _cRepository;

        public ProvinceService(IRepository<Province> repository,IRepository<City> cRepository)
        {
            this._repository = repository;
            this._cRepository = cRepository;
        }
        public async Task<BaseResultStatus> AddAsync(ProvinceCreateDto model, CancellationToken cancellationToken)
        {
            var exists = await _repository.TableNoTracking.Where(c => c.Title.Trim().Contains(model.Title.Trim(), StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(cancellationToken);
            if (exists != null)
                return BaseResultStatus.Exists;

            var province = model.ToEntity();
            await _repository.AddAsync(province,cancellationToken);

            return BaseResultStatus.Ok;
        }

        public async Task<BaseResultStatus> DeleteAsync(int provinceId, CancellationToken cancellationToken)
         {
            try
            {
                var model = await _repository.Table.Include(c=>c.Cities).Where(c => c.Id == provinceId).FirstOrDefaultAsync(cancellationToken);
                if (model == null)
                    return BaseResultStatus.NotExists;
                foreach (var item in model.Cities)
                {
                    await _cRepository.DeleteAsync(item,cancellationToken, saveNow: false);
                }
                    await _repository.DeleteAsync(model, cancellationToken);
                return BaseResultStatus.Ok;
            }
            catch (Exception ex)
            {
                StringBuilder errorMsg = new StringBuilder();
                for (Exception current = ex; current != null; current = current.InnerException)
                {
                    if (errorMsg.Length > 0)
                        errorMsg.Append("\n");


                    errorMsg.Append(current.Message.Replace("See the inner exception for details.", string.Empty));
                }
                // log
                errorMsg.ToString();
            }
            return BaseResultStatus.Bad;
        }

        public async Task<List<ProvinceSelectDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var provinces = await _repository.TableNoTracking.ProjectTo<ProvinceSelectDto>().ToListAsync(cancellationToken);
            
            return provinces;
        }
    }
}
