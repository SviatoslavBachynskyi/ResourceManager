using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class ResourceCategoryService : IResourceCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceCategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourceCategoryDto>> GetAllAsync()
        {
            var categories = await this._unitOfWork.ResourceCategoryRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<ResourceCategoryDto>>(categories);
        }
    }
}
