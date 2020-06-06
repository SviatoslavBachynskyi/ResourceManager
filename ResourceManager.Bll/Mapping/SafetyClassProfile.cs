using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class SafetyClassProfile : Profile
    {
        public SafetyClassProfile()
        {
            this.CreateMap<SafetyClass, SafetyClassDto>()
                ;

            this.CreateMap<SafetyClassDto, SafetyClass>()
                ;
        }
    }
}
