using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels.SelectViewModels;

namespace ResourceManager.Mapping
{
    public class ResourceSubCategorySelectProfile : Profile
    {
        public ResourceSubCategorySelectProfile()
        {
            this.CreateMap<ResourceSubCategorySelectViewModel, ResourceSubCategoryDto>()
                ;

            this.CreateMap<ResourceSubCategoryDto, ResourceSubCategorySelectViewModel>()
                ;
        }
    }
}
