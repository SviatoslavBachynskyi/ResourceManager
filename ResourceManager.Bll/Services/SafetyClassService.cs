using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class SafetyClassService : ISafetyClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SafetyClassService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SafetyClassDto>> GetAllAsync()
        {
            var classes = await this._unitOfWork.SafetyClassRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<SafetyClassDto>>(classes);
        }
    }
}
