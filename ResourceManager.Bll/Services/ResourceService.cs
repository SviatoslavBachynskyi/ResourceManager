using ResourceManager.Core;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Dtos.FilterDtos;
using ResourceManager.Core.Models;
using ResourceManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManager.Bll.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ResourceDto> GetByIdAsync(int id)
        {
            var resource = await this._unitOfWork.ResourceRepository.GetByIdAsync(id);

            return DtoModelMapping.Mapper.Map<ResourceDto>(resource);
        }

        public async Task<IEnumerable<ResourceDto>> GetAllAsync(ResourceFilterDto resourceFilter = null)
        {
            IEnumerable<Resource> resources;

            if (resourceFilter == null)
            {
                resources = await this._unitOfWork.ResourceRepository.GetAllAsync();
            }
            else
            {
                Expression<Func<Resource, bool>> filter =
                    r =>
                     (resourceFilter.SearchText == null || (r.Name.ToLower().Contains(resourceFilter.SearchText)
                     || (r.Description != null ? r.Description.ToLower().Contains(resourceFilter.SearchText) : false)))

                     && (resourceFilter.MeasuringUnitId == null || r.MeasuringUnitId == resourceFilter.MeasuringUnitId)
                     
                     && ((resourceFilter.CategoryId == null || resourceFilter.SubCategoryId != null)
                     || r.ResourceSubCategory.ResourceCategoryId == resourceFilter.CategoryId)

                     && (resourceFilter.SubCategoryId == null || r.ResourceSubCategoryId == resourceFilter.SubCategoryId)
                     
                     && (resourceFilter.SafetyClassId == null || r.SafetyClassId == resourceFilter.SafetyClassId)
                     
                     && (resourceFilter.EcologyClassId == null || r.EcologyClassId == resourceFilter.EcologyClassId)
                     ;

                resources = await this._unitOfWork.ResourceRepository.GetAllAsync(filter);
            }

            return DtoModelMapping.Mapper.Map<IEnumerable<ResourceDto>>(resources);
        }

        public async Task DeleteAsync(int id)
        {
            var resouce = new Resource { Id = id };
            this._unitOfWork.ResourceRepository.Remove(resouce);
            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
