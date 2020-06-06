using AutoMapper;
using ResourceManager.Core.Dtos;
using ResourceManager.Core.Models;

namespace ResourceManager.Bll.Mapping
{
    internal class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            this.CreateMap<Resource, ResourceDto>()
                .ForMember(dst => dst.MeasuringUnit, opt => opt.MapFrom(src => src.MeasuringUnit.Name))
                .ForMember(dst => dst.Category, opt => opt.MapFrom(src => src.ResourceSubCategory.ResourceCategory.Name))
                .ForMember(dst => dst.SubCategory, opt => opt.MapFrom(src => src.ResourceSubCategory.Name))
                .ForMember(dst => dst.SubCategoryId, opt => opt.MapFrom(src => src.ResourceSubCategoryId))
                .ForMember(dst => dst.EcologyClass, opt => opt.MapFrom(src => src.EcologyClass.CodeName))
                .ForMember(dst => dst.SafetyClass, opt => opt.MapFrom(src => src.SafetyClass.CodeName))
                ;

            this.CreateMap<ResourceDto, Resource>()
                .ForMember(dst => dst.MeasuringUnit, opt => opt.Ignore())
                .ForMember(dst => dst.ResourceSubCategory, opt => opt.Ignore())
                .ForMember(dst => dst.ResourceSubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                .ForMember(dst => dst.EcologyClass, opt => opt.Ignore())
                .ForMember(dst => dst.SafetyClass, opt => opt.Ignore())
                ;
        }
    }
}
