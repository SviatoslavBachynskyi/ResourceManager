using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class ResourceCategoryProfile : Profile
    {
        public ResourceCategoryProfile()
        {
            this.CreateMap<ResourceCategory, ResourceCategoryDto>()
                ;

            this.CreateMap<ResourceCategoryDto, ResourceCategory>()
                ;
        }
    }
}
