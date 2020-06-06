using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;
using ResourceManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class ResourceService : IResourceService
    {
        IUnitOfWork _unitOfWork;

        public ResourceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllAsync()
        {
            var resources = await this._unitOfWork.ResourceRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<ResourceDto>>(resources);
        }
    }
}
