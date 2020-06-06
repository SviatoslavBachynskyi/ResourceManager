using AutoMapper;
using ResourceManager.Core.Dtos.FilterDtos;
using ResourceManager.ViewModels.FilterViewModels;

namespace ResourceManager.Mapping
{
    public class ResourceFilterProfile : Profile
    {
        public ResourceFilterProfile()
        {
            this.CreateMap<ResourceFilterViewModel, ResourceFilterDto>()
                ;

            this.CreateMap<ResourceFilterDto, ResourceFilterViewModel>()
                ;
        }
    }
}
