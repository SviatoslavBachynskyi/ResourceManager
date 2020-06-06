using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels.SelectViewModels;

namespace ResourceManager.Mapping
{
    public class EcologyClassSelectProfile : Profile
    {
        public EcologyClassSelectProfile()
        {
            this.CreateMap<EcologyClassSelectViewModel, EcologyClassDto>()
                ;

            this.CreateMap<EcologyClassDto, EcologyClassSelectViewModel>()
                ;
        }
    }
}
