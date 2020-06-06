using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class MeasuringUnitProfile : Profile
    {
        public MeasuringUnitProfile()
        {
            this.CreateMap<MeasuringUnit, MeasuringUnitDto>()
                ;

            this.CreateMap<MeasuringUnitDto, MeasuringUnit>()
                ;
        }
    }
}
