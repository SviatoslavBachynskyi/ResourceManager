using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels;

namespace ResourceManager.Mapping
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            this.CreateMap<ResourceViewModel, ResourceDto>()
                ;

            this.CreateMap<ResourceDto, ResourceViewModel>()
                ;
        }
    }
}
