using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class EcologyClassService : IEcologyClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EcologyClassService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EcologyClassDto>> GetAllAsync()
        {
            var classes = await this._unitOfWork.EcologyClassRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<EcologyClassDto>>(classes);
        }
    }
}
