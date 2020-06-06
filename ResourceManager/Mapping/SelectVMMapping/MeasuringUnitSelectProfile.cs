using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.ViewModels.SelectViewModels;

namespace ResourceManager.Mapping
{
    public class MeasuringUnitSelectProfile : Profile
    {
        public MeasuringUnitSelectProfile()
        {
            this.CreateMap<MeasuringUnitSelectViewModel, MeasuringUnitDto>()
                ;

            this.CreateMap<MeasuringUnitDto, MeasuringUnitSelectViewModel>()
                ;
        }
    }
}
