using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class MeasuringUnitService : IMeasuringUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeasuringUnitService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MeasuringUnitDto>> GetAllAsync()
        {
            var classes = await this._unitOfWork.MeasuringUnitRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<MeasuringUnitDto>>(classes);
        }
    }
}
