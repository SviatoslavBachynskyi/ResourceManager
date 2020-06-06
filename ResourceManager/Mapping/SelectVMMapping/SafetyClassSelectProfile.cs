using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels.SelectViewModels;

namespace ResourceManager.Mapping
{
    public class SafetyClassSelectProfile : Profile
    {
        public SafetyClassSelectProfile()
        {
            this.CreateMap<SafetyClassSelectViewModel, SafetyClassDto>()
                ;

            this.CreateMap<SafetyClassDto, SafetyClassSelectViewModel>()
                ;
        }
    }
}
