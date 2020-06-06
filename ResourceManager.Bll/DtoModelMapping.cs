using AutoMapper;
using ResourceManager.Bll.Mapping;
using System;

namespace ResourceManager.Bll
{
    public static class DtoModelMapping
    {
        private static readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                cfg.AddProfile<ResourceProfile>();
                cfg.AddProfile<ResourceCategoryProfile>();
                cfg.AddProfile<ResourceSubCategoryProfile>();
                cfg.AddProfile<MeasuringUnitProfile>();
                cfg.AddProfile<SafetyClassProfile>();
                cfg.AddProfile<EcologyClassProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => _lazy.Value;
    }
}
