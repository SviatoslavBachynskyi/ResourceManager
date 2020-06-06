using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class EcologyClassProfile : Profile
    {
        public EcologyClassProfile()
        {
            this.CreateMap<EcologyClass, EcologyClassDto>()
                ;

            this.CreateMap<EcologyClassDto, EcologyClass>()
                ;
        }
    }
}
