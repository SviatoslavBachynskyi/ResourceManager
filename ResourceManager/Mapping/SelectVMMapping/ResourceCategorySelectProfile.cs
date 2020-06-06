using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels.SelectViewModels;

namespace ResourceManager.Mapping
{
    public class ResourceCategorySelectProfile : Profile
    {
        public ResourceCategorySelectProfile()
        {
            this.CreateMap<ResourceCategorySelectViewModel, ResourceCategoryDto>()
                ;

            this.CreateMap<ResourceCategoryDto, ResourceCategorySelectViewModel>()
                ;
        }
    }
}
