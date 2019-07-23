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
    public class CityService : ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IRepository<Province> _pRepository;

        public CityService(IRepository<City> repository,IRepository<Province> pRepository)
        {
            this._repository = repository;
            this._pRepository = pRepository;
        }
        public async Task<BaseResultStatus> AddAsync(CityCreateDto model, CancellationToken cancellationToken)
        {
            var exists = await _repository.TableNoTracking.Where(c => c.Title.Trim().Contains(model.Title.Trim(), StringComparison.OrdinalIgnoreCase)&&c.ProvinceId==model.ProvinceId).FirstOrDefaultAsync(cancellationToken);
            if (exists != null)
                return BaseResultStatus.Exists;

            var province = await _pRepository.TableNoTracking.Where(c => c.Id == model.ProvinceId).FirstOrDefaultAsync(cancellationToken);

            if (province == null)
                return BaseResultStatus.NotExists;

            var cities = model.ToEntity();
            await _repository.AddAsync(cities, cancellationToken);

            return BaseResultStatus.Ok;
        }

        public async Task<BaseResultStatus> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = await _repository.Table.Where(c => c.Id == cityId).FirstOrDefaultAsync(cancellationToken);
            if (model == null)
                return BaseResultStatus.NotExists;
            await _repository.DeleteAsync(model,cancellationToken);
            return BaseResultStatus.Ok;
        }

        public async Task<List<CitySelectDto>> GetAllAsync(int provinceId,CancellationToken cancellationToken)
        {
            var cities = await _repository.TableNoTracking.Where(c=>c.ProvinceId==provinceId).ProjectTo<CitySelectDto>().ToListAsync(cancellationToken);
            
            return cities;
        }
    }
}
