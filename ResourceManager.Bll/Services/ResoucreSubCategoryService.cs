using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class ResourceSubCategoryService : IResourceSubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceSubCategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourceSubCategoryDto>> GetAllAsync()
        {
            var subCategories = await this._unitOfWork.ResourceSubCategoryRepository.GetAllAsync();

            return DtoModelMapping.Mapper.Map<IEnumerable<ResourceSubCategoryDto>>(subCategories);
        }

        public async Task<IEnumerable<ResourceSubCategoryDto>> GetAllAsync(int resourceCategoryId)
        {
            var subCategories = await this._unitOfWork.ResourceSubCategoryRepository.GetAllAsync((s) => s.ResourceCategoryId == resourceCategoryId);

            return DtoModelMapping.Mapper.Map<IEnumerable<ResourceSubCategoryDto>>(subCategories);
        }
    }
}
