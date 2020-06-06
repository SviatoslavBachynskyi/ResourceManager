using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class ResourceSubCategoryProfile : Profile
    {
        public ResourceSubCategoryProfile()
        {
            this.CreateMap<ResourceSubCategory, ResourceSubCategoryDto>()
                ;

            this.CreateMap<ResourceSubCategoryDto, ResourceSubCategory>()
                ;
        }
    }
}
